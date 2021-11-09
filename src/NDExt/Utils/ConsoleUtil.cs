using System;
using System.Collections.Generic;
using System.Text;

namespace NDExt.Utils
{
    public static class ConsoleUtil
    {
        private const int cDefaultSeparatorCount = 60;

        public static void WriteCommandHeader(string message)
        {
            WriteHeader(message, '=');
            Console.WriteLine($"");
        }

        public static void WriteSeparator(char separator='=',int count= cDefaultSeparatorCount)
        {
            var line = new string(separator, count);
            Console.WriteLine($"#{line}");
        }


        public static void WriteHeader(string message, char separator = '-', int count = cDefaultSeparatorCount)
        {
            var line = new string(separator, count);
            Console.WriteLine($"");
            Console.WriteLine($"#{line}");
            Console.WriteLine($"# {message}");
            Console.WriteLine($"#{line}");
        }

        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteLine(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }


        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
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
        /// エラーの出力
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteError(Exception ex)
        {
            WriteError($"{ex.Message}");
        }
    }
}
