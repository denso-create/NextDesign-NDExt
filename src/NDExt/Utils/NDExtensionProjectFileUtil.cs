using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NDExt.Utils
{
    /// <summary>
    /// NextDesignのエクステンションのプロジェクトに関するユーティリティです。
    /// </summary>
    public class NDExtensionProjectFileUtil
    {
        #region 定数定義

        /// <summary>
        /// C#プロジェクトファイルの検索パターン。
        /// </summary>
        private const string c_CsprojFilePattern = "*.csproj";

        /// <summary>
        /// エクステンションのマニフェストファイル名。
        /// </summary>
        private const string c_ManifestFileName = "manifest.json";

        /// <summary>
        /// NextDesign.Core.dll のファイル名。
        /// </summary>
        private const string c_NextDesignCoreDll = "NextDesign.Core.dll";

        /// <summary>
        /// NextDesign.Desktop.dll のファイル名。
        /// </summary>
        private const string c_NextDesignDesktopDll = "NextDesign.Desktop.dll";

        #endregion

        #region 公開メソッド

        /// <summary>
        /// エクステンションのプロジェクトファイルのあるディレクトリを探します。
        /// </summary>
        /// <param name="targetDir">探索対象のルートディレクトリのパス。</param>
        /// <returns>エクステンションのプロジェクトファイルのあるディレクトリの列挙。</returns>
        public static IEnumerable<string> FindExtensionProjectDirs(string targetDir)
        {
            var ret = new HashSet<string>();
            var csProjFiles = Directory.EnumerateFiles(targetDir, c_CsprojFilePattern, SearchOption.AllDirectories);

            foreach (var csProjFile in csProjFiles)
            {
                // csprojの親ディレクトリ
                var parentDir = Directory.GetParent(csProjFile).FullName;

                // マニフェストファイルがあれば対象とみなします
                if (Directory.EnumerateFiles(parentDir, c_ManifestFileName, SearchOption.AllDirectories).Any())
                {
                    ret.Add(parentDir);
                }
            }

            return ret;
        }

        /// <summary>
        /// プロジェクトファイルのパスを取得します
        /// </summary>
        /// <param name="projectDir">プロジェクトファイルのディレクトリ。</param>
        /// <returns>プロジェクトファイルのパス。存在しない場合はnullを返します。</returns>
        public static string GetProjectFilePath(string projectDir)
        {
            var csProjFile = Directory.EnumerateFiles(projectDir, c_CsprojFilePattern, SearchOption.AllDirectories).FirstOrDefault();
            return csProjFile;
        }

        /// <summary>
        /// プロジェクトファイルが存在するかを確認します。
        /// </summary>
        /// <param name="projectDir">プロジェクトファイルのディレクトリ。</param>
        /// <returns>プロジェクトファイルが存在するか。存在する場合はtrue、それ以外はfalseです。</returns>
        public static bool ProjectFileExists(string projectDir)
        {
            var csProjFile = GetProjectFilePath(projectDir);
            return !string.IsNullOrEmpty(csProjFile);
        }

        /// <summary>
        /// NDのエクステンションのプログラムを指定フォルダにコピーします。
        /// コピー後、不要なNextDesign.Core.dllやNextDesign.Desktop.dllを削除します。
        /// </summary>
        /// <param name="sourceDir">コピー元のディレクトリ。</param>
        /// <param name="destDir">コピー先のディレクトリ。</param>
        public static void CopyExtensionFolder(string sourceDir, string destDir)
        {
            FileUtil.CopyDirectory(sourceDir, destDir);

            FileUtil.DeleteFile(Path.Combine(destDir, c_NextDesignCoreDll));
            FileUtil.DeleteFile(Path.Combine(destDir, c_NextDesignDesktopDll));
        }

        #endregion
    }
}
