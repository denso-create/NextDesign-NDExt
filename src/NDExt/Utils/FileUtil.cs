using System;
using System.IO;
using System.Linq;

namespace NDExt.Utils
{
    /// <summary>
    /// ファイル処理のユーティリティです。
    /// </summary>
    public static class FileUtil
    {
        #region 公開メソッド

        /// <summary>
        /// 指定されたディレクトリを削除し、再作成します。
        /// </summary>
        /// <param name="path">ディレクトリのパス。</param>
        public static void RecreateDirectory(string path)
        {
            DeleteDirectory(path);
            CreateDirectory(path);
        }

        /// <summary>
        /// 指定されたファイルを削除します。
        /// </summary>
        /// <param name="path">削除するファイルのパス。</param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    // do nothing
                }
            }
        }

        /// <summary>
        /// 指定されたパスにディレクトリを作成します。パスがファイルを含む場合は、その親ディレクトリを作成します。
        /// </summary>
        /// <param name="path">作成するディレクトリのパス。</param>
        public static void CreateDirectory(string path)
        {
            var ext = GetExtension(path);
            var dirPath = string.IsNullOrEmpty(ext) ? path : Path.GetDirectoryName(path);


            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        /// <summary>
        /// 指定されたディレクトリからファイルを検索し、コピー先にコピーします。
        /// </summary>
        /// <param name="source">コピー元のディレクトリ。</param>
        /// <param name="searchPattern">ファイル検索パターン。</param>
        /// <param name="dest">コピー先のディレクトリ。</param>
        public static void CopyFiles(string source, string searchPattern, string dest)
        {
            var files = Directory.EnumerateFiles(source, searchPattern);

            foreach (var file in files)
            {
                var destFileName = Path.GetFileName(file);

                try
                {
                    File.Copy(file, Path.Combine(dest, destFileName), true);
                }
                catch
                {
                    // do nothing
                }
            }
        }

        /// <summary>
        /// 指定されたパスの拡張子を取得します。
        /// </summary>
        /// <param name="path">ファイルのパス。</param>
        /// <returns>拡張子を返します。</returns>
        public static string GetExtension(string path)
        {
            var ret = "";
            
            string ext;
            do
            {
                ext = Path.GetExtension(path);
                if (!string.IsNullOrEmpty(ext))
                {
                    path = path.Substring(0, path.Length - ext.Length);
                    ret = ext + ret;
                }
            }
            while (!string.IsNullOrEmpty(ext));

            return ret;
        }


        /// <summary>
        /// 指定されたディレクトリを削除します。
        /// </summary>
        /// <param name="path">削除するディレクトリのパス。</param>
        /// <param name="shouldRootDelete">ルートディレクトリ自体を削除するかどうか。</param>
        public static void DeleteDirectory(string path, bool shouldRootDelete = true)
        {
            if (!Directory.Exists(path)) return;

            var deleteDirectories = Directory.GetDirectories(path).ToList();
            deleteDirectories.ForEach(d => DeleteDirectory(d));

            if (!shouldRootDelete) return;

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }

        /// <summary>
        /// 指定されたディレクトリをコピーします。
        /// </summary>
        /// <param name="sourceFolder">コピー元のディレクトリ。</param>
        /// <param name="destFolder">コピー先のディレクトリ。</param>
        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            // コピー元、コピー先が存在しない場合は何もしない
            if (string.IsNullOrEmpty(sourceFolder) || string.IsNullOrEmpty(destFolder)) return;

            // コピー元フォルダが存在しない場合は何もしない
            if (!Directory.Exists(sourceFolder)) return;

            // コピー先フォルダが存在しない場合は新規作成
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            // ファイルをコピー
            var files = Directory.GetFiles(sourceFolder);
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var copyTarget = Path.Combine(destFolder, fileName);
                File.Copy(file, copyTarget, true);
            }

            // フォルダを再帰的にコピー
            var folders = Directory.GetDirectories(sourceFolder);
            foreach (var folder in folders)
            {
                var copyTarget = Path.Combine(destFolder, Path.GetFileName(folder));
                CopyDirectory(folder, copyTarget);
            }
        }

        #endregion
    }
}
