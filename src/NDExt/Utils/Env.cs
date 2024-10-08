using System;
using System.IO;
using System.Reflection;

namespace NDExt.Utils
{
    /// <summary>
    /// 環境設定
    /// </summary>
    internal static class Env
    {
        #region プロパティ

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
        public static string CurrentDir => Environment.CurrentDirectory;

        #endregion
    }
}
