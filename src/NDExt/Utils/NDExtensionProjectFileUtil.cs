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
        #region 公開メソッド

        /// <summary>
        /// エクステンションのプロジェクトファイルのあるディレクトリを探します。
        /// </summary>
        /// <param name="targetDir">探索対象のルートディレクトリのパス。</param>
        /// <returns>エクステンションのプロジェクトファイルのあるディレクトリの列挙。</returns>
        public static IEnumerable<string> FindExtensionProjectDirs(string targetDir)
        {
            var ret = new HashSet<string>();
            var csProjFiles = Directory.EnumerateFiles(targetDir, "*.csproj", SearchOption.AllDirectories);

            foreach (var csProjFile in csProjFiles)
            {
                // csprojの親ディレクトリ
                var parentDir = Directory.GetParent(csProjFile).FullName;

                // マニフェストファイルがあれば対象とみなします
                if (Directory.EnumerateFiles(parentDir, "manifest.json", SearchOption.AllDirectories).Any())
                {
                    ret.Add(parentDir);
                }
            }

            return ret;
        }

        /// <summary>
        /// プロジェクトファイルのパスを取得します
        /// </summary>
        /// <param name="projectDir"></param>
        /// <returns></returns>
        public static string GetProjectFilePath(string projectDir)
        {
            var csProjFile = Directory.EnumerateFiles(projectDir, "*.csproj", SearchOption.AllDirectories).FirstOrDefault();
            return csProjFile;
        }

        /// <summary>
        /// プロジェクトファイルが存在するかを確認します。
        /// </summary>
        /// <param name="projectDir"></param>
        /// <returns>プロジェクトファイルが存在するか。存在する場合はtrue、それ以外はfalseです。</returns>
        public static bool ProjectFileExists(string projectDir)
        {
            var csProjFile = GetProjectFilePath(projectDir);
            return !string.IsNullOrEmpty(csProjFile);
        }

        /// <summary>
        /// NDのエクステンションのプログラムを指定フォルダにコピーします。
        /// 不要なNextDesign.Core.dllのようなDLLを削除します。
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destDir"></param>
        public static void CopyExtensionFolder(string sourceDir, string destDir)
        {
            FileUtil.CopyDirectory(sourceDir, destDir);

            FileUtil.DeleteFile(Path.Combine(destDir, "NextDesign.Core.dll"));
            FileUtil.DeleteFile(Path.Combine(destDir, "NextDesign.Desktop.dll"));
        }

        #endregion
    }
}
