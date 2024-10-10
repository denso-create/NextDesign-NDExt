using NDExt.Utils;
using System.IO;
using System.Linq;

namespace NDExt.Services
{
    /// <summary>
    /// パッケージ化サービスです。
    /// </summary>

    public class PackageService
    {
        #region 定数定義

        /// <summary>
        /// Nuspecファイルの拡張子。
        /// </summary>
        private const string c_NuspecFileExtension = ".nuspec";

        /// <summary>
        /// NuGetパッケージファイルの検索パターン。
        /// </summary>
        private const string c_NugetPackageFilePattern = "*.nupkg";

        #endregion

        #region プロパティ

        /// <summary>
        /// パッケージ化のリクエスト情報。
        /// </summary>
        private PackageRequest Request { get; set; }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 指定されたリクエストに基づき、パッケージ化を実行します。
        /// </summary>
        /// <param name="request">パッケージ化のリクエスト情報。</param>
        /// <exception cref="UserException">プロジェクトファイルが見つからない場合にスローされます。</exception>
        public void Package(PackageRequest request)
        {
            Request = request;
            var projectDirs = NDExtensionProjectFileUtil.FindExtensionProjectDirs(request.TargetDir);

            // プロジェクトファイルが存在しない
            if (!projectDirs.Any())
            {
                throw new UserException($"エクステンションのプロジェクトファイル(csproj)が見つかりませんでした。");
            }

            // 見つかったプロジェクトファイルに対して実行
            foreach (var projectDir in projectDirs)
            {
                PackageProject(projectDir);
            }
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// 指定されたディレクトリ内のプロジェクトファイルをパッケージ化します。
        /// </summary>
        /// <param name="projectDir">プロジェクトファイルが格納されているディレクトリ。</param>
        private void PackageProject(string projectDir)
        {
            #region ディレクトリ

            var projectFilePath = NDExtensionProjectFileUtil.GetProjectFilePath(projectDir);
            var projectFileName = Path.GetFileName(projectFilePath);

            ConsoleUtil.WriteLine();
            ConsoleUtil.WriteLine();
            ConsoleUtil.WriteLine("==========> Packaging Project <=========================");
            ConsoleUtil.WriteLine($"[in] TargetProject: {projectFileName}");
            ConsoleUtil.WriteLine($"[in] Build Target: {Request.BuildConfig}");
            ConsoleUtil.WriteLine($"[in] ND Version: {Request.NDVersion}");
            ConsoleUtil.WriteLine("========================================================");
            ConsoleUtil.WriteLine();

            #endregion

            #region プロジェクトのビルド

            ConsoleUtil.WriteHeader("Build Project");

            // projectDirのbinからpublishフォルダがあるディレクトリを取得
            var binDir = Path.Combine(projectDir, "bin", Request.BuildConfig);

            // binDirのディレクトリとそのサブディレクトリを削除
            FileUtil.DeleteDirectory(binDir);

            // ビルドを実行
            ProcessUtil.Start("dotnet", $"publish {projectFilePath} -c {Request.BuildConfig}");

            // publishフォルダがあるディレクトリを取得
            var buildDir = Directory.EnumerateDirectories(binDir)
                .LastOrDefault(x => Directory.EnumerateDirectories(x).Any(y => y.Contains("publish")));

            var buildPublishDir = Path.Combine(buildDir, "publish");
            var packageBuildDir = Path.Combine(buildDir, AppSettings.PackageBuildDir);
            var packageContentsDir = Path.Combine(projectDir, AppSettings.PackageContentsDir);
            var packageOutputDir = Path.Combine(Directory.GetCurrentDirectory(), Request.OutputDir);

            #endregion

            #region パッケージ化

            ConsoleUtil.WriteHeader("Packaging");

            // パッケージのビルド用フォルダを作成（存在していれば削除して作成）
            FileUtil.RecreateDirectory(packageBuildDir);

            // nuspecファイルを保存
            var nuspec = NdPackageNuspecInfo.CreateFromProjectFile(projectFilePath);
            nuspec.CheckErrors();
            var nuspecFilePath = Path.Combine(packageBuildDir, $"{nuspec.Id}{c_NuspecFileExtension}");
            nuspec.SaveToFile(nuspecFilePath);

            // publishした結果をパッケージのビルド用フォルダにコピー
            var extensionBinDir = Path.Combine(packageBuildDir, "extensions", Request.NDVersion, nuspec.Id);
            NDExtensionProjectFileUtil.CopyExtensionFolder(buildPublishDir, extensionBinDir);

            // パッケージのコンテンツフォルダがあればその内容もコピー
            if (Directory.Exists(packageContentsDir))
            {
                FileUtil.CopyDirectory(packageContentsDir, packageBuildDir);
            }

            // パッケージの実行
            var nugetArgs = @$"pack ""{nuspecFilePath}""  -PackagesDirectory ""{packageBuildDir}""  -NoPackageAnalysis -OutputDirectory ""{packageOutputDir}"" ";

            try
            {
                ProcessUtil.Start("nuget.exe", nugetArgs);
            }
            catch
            {
                throw new UserException("nuget.exe が見つからないため、パッケージ処理が実行できませんでした。https://www.nuget.org/downloads から nuget.exe をダウンロードし、適切なフォルダーに保存して、そのフォルダーを PATH 環境変数に追加してください。");
            }

            #endregion

            #region パッケージをフォルダにコピー

            if (!string.IsNullOrEmpty(Request.CopyDir))
            {
                ConsoleUtil.WriteHeader("Copy nupkg");
                FileUtil.CopyFiles(packageOutputDir, c_NugetPackageFilePattern, Request.CopyDir);
            }

            #endregion

            ConsoleUtil.WriteHeader("Done");
            ConsoleUtil.WriteLine("パッケージ化を完了しました。");
            ConsoleUtil.WriteLine();

        }

        #endregion
    }
}
