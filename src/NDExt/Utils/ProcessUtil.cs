using System.Diagnostics;

namespace NDExt.Utils
{
    /// <summary>
    /// プロセス実行のユーティリティです。
    /// </summary>
    internal static class ProcessUtil
    {
        #region 公開メソッド

        /// <summary>
        /// 指定されたプロセスを実行します。
        /// </summary>
        /// <param name="filename">実行するファイル名。</param>
        /// <param name="args">コマンドに渡す引数。</param>
        /// <returns>プロセスの終了コードを返します。</returns>
        /// <exception cref="UserException">プロセスが失敗した場合にスローされます。</exception>
        public static int Start(string filename, string args)
        {
            var startInfo = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = args,
                // CreateNoWindow = false,
                // UseShellExecute = false,
            };

            // プロセスを開始し、終了まで待機
            var process = Process.Start(startInfo);
            process.WaitForExit();

            // 終了コードが0以外の場合は例外をスロー
            if (process.ExitCode != 0)
            {
                throw new UserException($"コマンド `{filename} {args}`の実行に失敗しました。 ");
            }

            return process.ExitCode;
        }

        #endregion
    }
}
