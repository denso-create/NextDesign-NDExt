using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace NDExt
{
    /// <summary>
    /// アプリケーションのコンフィグ情報
    /// IConfigurationRootをラップしたオブジェクトです。
    /// </summary>
    public static class AppSettings
    {
        #region フィールド

        /// <summary>
        /// コンフィグ情報。
        /// </summary>
        private static IConfigurationRoot s_Config;

        #endregion

        #region プロパティ

        /// <summary>
        /// パッケージのデフォルト出力フォルダ名
        /// </summary>
        public static string PackageOutputDir => GetValue("ndpackages");

        /// <summary>
        /// パッケージ化するコンテンツのフォルダ名
        /// </summary>
        public static string PackageContentsDir => GetValue("pkgContents");

        /// <summary>
        /// パッケージのビルド結果
        /// </summary>
        public static string PackageBuildDir => GetValue("ndpackage");

        /// <summary>
        /// デフォルトのビルドターゲット
        /// </summary>
        public static string DefaultBuildTarget => GetValue("Release");

        /// <summary>
        /// デフォルトのNext Designのバージョン
        /// </summary>
        public static string DefaultNdVersion => GetValue("3.0");

        #endregion

        #region 公開メソッド

        /// <summary>
        /// Configオブジェクトで初期化
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(IConfigurationRoot config)
        {
            s_Config = config;
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// 値を取得します
        /// </summary>
        /// <param name="defaultValue">エントリがない場合のデフォルト値</param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetValue(string defaultValue, [CallerMemberName] string name = null)
        {
            var val = s_Config[name];
            if (string.IsNullOrEmpty(val))
            {
                return defaultValue;
            }
            return val;
        }

        #endregion
    }
}
