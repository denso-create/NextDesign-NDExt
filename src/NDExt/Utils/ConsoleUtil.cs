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

        /// <summary>
        /// セパレータに使用する文字列。
        /// </summary>
        private const char c_DefaultSeparatorChar = '-';

        /// <summary>
        /// コマンドヘッダのセパレータに使用する文字列。
        /// </summary>
        private const char c_CommandHeaderSeparatorChar = '=';

        #endregion

        #region 公開メソッド

        /// <summary>
        /// コマンドのヘッダを出力します。
        /// </summary>
        /// <param name="message">ヘッダメッセージ。</param>
        public static void WriteCommandHeader(string message)
        {
            WriteHeader(message, c_CommandHeaderSeparatorChar, includePadding: true);
            WriteLine("");
        }

        /// <summary>
        /// 指定した個数のセパレータを出力します。
        /// </summary>
        /// <param name="separator">使用するセパレータ文字。既定値は<see cref="c_DefaultSeparatorChar"/>です。</param>
        /// <param name="count">出力するセパレータの個数。既定値は<see cref="c_DefaultSeparatorCount"/>です。</param>
        public static void WriteSeparator(char separator = c_DefaultSeparatorChar, int count = c_DefaultSeparatorCount)
        {
            var line = new string(separator, count);
            WriteLine($"#{line}");
        }

        /// <summary>
        /// ヘッダメッセージをセパレータで囲んで出力します。
        /// </summary>
        /// <param name="message">ヘッダとして出力するメッセージ。</param>
        /// <param name="separator">セパレータとして使用する文字。既定値は<see cref="c_DefaultSeparatorChar"/>です。</param>
        /// <param name="count">セパレータの個数。既定値は<see cref="c_DefaultSeparatorCount"/>です。</param>
        /// <param name="includePadding">メッセージの前後に空行を挿入するかどうか。デフォルトは<see langword="false"/>です。</param>
        public static void WriteHeader(string message, char separator = c_DefaultSeparatorChar, int count = c_DefaultSeparatorCount, bool includePadding = false)
        {
            WriteLine("");
            WriteSeparator(separator, count);
            if (includePadding)
            {
                WriteLine("#");
            }

            // メッセージを改行で分割し、それぞれの行に対して処理
            var lines = message.Split('\n');
            foreach (var line in lines)
            {
                WriteLine($"# {line.Trim()}");
            }

            WriteLine($"# {message}");
            if (includePadding)
            {
                WriteLine("#");
            }
            WriteSeparator(separator, count);
        }

        /// <summary>
        /// 指定されたメッセージをコンソールに出力します。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 空行を出力します。
        /// </summary>
        public static void WriteLine()
        {
            WriteLine("");
        }

        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="message">出力するエラーメッセージ。</param>
        public static void WriteError(string message)
        {
            WriteLine($"Error: {message}");
        }


        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        /// <param name="ex">発生した例外オブジェクト。</param>
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
        /// <param name="ex">発生した例外オブジェクト。</param>
        public static void WriteError(Exception ex)
        {
            WriteError(ex.Message);
        }

        #endregion
    }
}
