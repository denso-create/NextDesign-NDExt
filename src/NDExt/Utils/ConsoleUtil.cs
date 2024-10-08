using System;

namespace NDExt.Utils
{
    /// <summary>
    /// コンソール出力のユーティリティです。
    /// </summary>
    public static class ConsoleUtil
    {
        #region 定数定義

        /// <summary>
        /// セパレータの個数。
        /// </summary>
        private const int c_DefaultSeparatorCount = 60;

        #endregion

        #region 公開メソッド

        /// <summary>
        /// コマンドヘッダを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public static void WriteCommandHeader(string message)
        {
            WriteHeader(message, '=');
            Console.WriteLine($"");
        }

        /// <summary>
        /// 指定した個数のセパレータを出力します。
        /// </summary>
        /// <param name="separator">セパレータとして利用する文字。既定値は'-'です。</param>
        /// <param name="count">セパレータの個数。既定値は<see cref="c_DefaultSeparatorCount"/>です。</param>
        public static void WriteSeparator(char separator = '=', int count = c_DefaultSeparatorCount)
        {
            var line = new string(separator, count);
            Console.WriteLine($"#{line}");
        }

        /// <summary>
        /// ヘッダを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="separator">セパレータとして利用する文字。既定値は'-'です。</param>
        /// <param name="count">セパレータの個数。既定値は<see cref="c_DefaultSeparatorCount"/>です。</param>
        public static void WriteHeader(string message, char separator = '-', int count = c_DefaultSeparatorCount)
        {
            var line = new string(separator, count);
            Console.WriteLine($"");
            Console.WriteLine($"#{line}");
            Console.WriteLine($"# {message}");
            Console.WriteLine($"#{line}");
        }

        /// <summary>
        /// メッセージを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public static void WriteLine(string message)
        {
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// メッセージを出力します。
        /// </summary>
        public static void WriteLine()
        {
            WriteLine("");
        }

        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public static void WriteError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }


        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="ex">例外オブジェクト。</param>
        public static void WriteError(string message, Exception ex)
        {
            if (ex == null)
            {
                WriteError(message);
            }
            else
            {
                WriteError($"{message}({ex.Message})");
            }
        }

        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="ex">例外オブジェクト。</param>
        public static void WriteError(Exception ex)
        {
            WriteError($"{ex.Message}");
        }

        #endregion
    }
}
