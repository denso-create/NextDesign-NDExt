using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace NDExt
{
    /// <summary>
    /// アプリケーションのコンフィグ情報を提供するクラスです。
    /// IConfigurationRootをラップし、設定値を提供します。
    /// </summary>
    public static class AppSettings
    {
        #region 定数

        /// <summary>
        /// パッケージのデフォルト出力フォルダ名のデフォルト値。
        /// </summary>
        private const string c_PackageOutputDirDefault = "ndpackages";

        /// <summary>
        /// パッケージ化するコンテンツのフォルダ名のデフォルト値。
        /// </summary>
        private const string c_PackageContentsDirDefault = "pkgContents";

        /// <summary>
        /// パッケージのビルド結果のデフォルト値。
        /// </summary>
        private const string c_PackageBuildDirDefault = "ndpackage";

        /// <summary>
        /// デフォルトのビルドターゲットのデフォルト値。
        /// </summary>
        private const string c_DefaultBuildTargetDefault = "Release";

        /// <summary>
        /// デフォルトのNext Designのバージョンのデフォルト値。
        /// </summary>
        private const string c_DefaultNdVersionDefault = "3.0";

        #endregion

        #region フィールド

        /// <summary>
        /// コンフィグ情報のルートオブジェクト。
        /// </summary>
        private static IConfigurationRoot s_Config;

        #endregion

        #region プロパティ

        /// <summary>
        /// パッケージのデフォルト出力フォルダ名を取得します。
        /// </summary>
        public static string PackageOutputDir => GetValue(c_PackageOutputDirDefault);

        /// <summary>
        /// パッケージ化するコンテンツのフォルダ名を取得します。
        /// </summary>
        public static string PackageContentsDir => GetValue(c_PackageContentsDirDefault);

        /// <summary>
        /// パッケージのビルド結果を取得します。
        /// </summary>
        public static string PackageBuildDir => GetValue(c_PackageBuildDirDefault);

        /// <summary>
        /// デフォルトのビルドターゲットを取得します。
        /// </summary>
        public static string DefaultBuildTarget => GetValue(c_DefaultBuildTargetDefault);

        /// <summary>
        /// デフォルトのNext Designのバージョンを取得します。
        /// </summary>
        public static string DefaultNdVersion => GetValue(c_DefaultNdVersionDefault);

        #endregion

        #region 公開メソッド

        /// <summary>
        /// コンフィグオブジェクトを使用して設定を初期化します。
        /// </summary>
        /// <param name="config">アプリケーションのコンフィグ情報。</param>
        public static void Initialize(IConfigurationRoot config)
        {
            s_Config = config;
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// コンフィグ値を取得します。設定が存在しない場合は、指定されたデフォルト値を返します。
        /// </summary>
        /// <param name="defaultValue">エントリがない場合のデフォルト値。</param>
        /// <param name="name">設定項目名。既定値は呼び出し元メソッド名。</param>
        /// <returns>設定された値、またはデフォルト値。</returns>
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
