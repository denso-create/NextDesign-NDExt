using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NDExt.Utils
{
    /// <summary>
    /// プロセス実行のユーティリティです。
    /// </summary>
    internal static class ProcessUtil
    {
        /// <summary>
        /// プロセスを実行します。
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Start(string filename,string args)
        {
            //ConsoleUtil.WriteLine($"Command: {filename} {args}");

            // git pull実行
            var startInfo = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = args,
                //CreateNoWindow = false,
                //UseShellExecute = false,
            };

            var process = Process.Start(startInfo);
            process.WaitForExit();


            if (process.ExitCode != 0)
            {
                throw new UserException($"コマンド `{filename} {args}`の実行に失敗しました。 ");
            }

            return process.ExitCode;
        }
    }
}
