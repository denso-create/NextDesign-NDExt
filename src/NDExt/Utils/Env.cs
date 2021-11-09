using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NDExt.Utils
{
    /// <summary>
    /// 環境設定
    /// </summary>
    internal static class Env
    {
        /// <summary>
        /// アプリケーションのベースディレクトリを取得します
        /// </summary>
        /// <returns></returns>
        public static string AppDir
        {
            get
            {
                var appBaseDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
                return appBaseDir;
            }
        }

        /// <summary>
        /// 現在のディレクトリ
        /// </summary>
        public static string CurrentDir
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

    }
}
