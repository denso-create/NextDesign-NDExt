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
        /// パッケージのデフォルトの出力フォルダ名。
        /// </summary>
        private const string c_PackageOutputDirDefault = "ndpackages";

        /// <summary>
        /// パッケージ化するコンテンツのデフォルトのフォルダ名。
        /// </summary>
        private const string c_PackageContentsDirDefault = "pkgContents";

        /// <summary>
        /// パッケージのビルド結果を格納するデフォルトのフォルダ名。
        /// </summary>
        private const string c_PackageBuildDirDefault = "ndpackage";

        /// <summary>
        /// デフォルトのビルド構成。
        /// </summary>
        private const string c_DefaultBuildTargetDefault = "Release";

        /// <summary>
        /// エクステンションの動作の対象となるNext Designのバージョンのデフォルト値。
        /// </summary>
        private const string c_DefaultNdVersionDefault = "3.1";

        #endregion

        #region フィールド

        /// <summary>
        /// コンフィグ情報のルートオブジェクト。
        /// </summary>
        private static IConfigurationRoot s_Config;

        #endregion

        #region プロパティ

        /// <summary>
        /// パッケージの出力フォルダ名の設定値を取得します。
        /// </summary>
        public static string PackageOutputDir => GetValue(c_PackageOutputDirDefault);

        /// <summary>
        /// パッケージ化するコンテンツのフォルダ名の設定値を取得します。
        /// </summary>
        public static string PackageContentsDir => GetValue(c_PackageContentsDirDefault);

        /// <summary>
        /// パッケージのビルド結果の設定値を取得します。
        /// </summary>
        public static string PackageBuildDir => GetValue(c_PackageBuildDirDefault);

        /// <summary>
        /// ビルド構成の設定値を取得します。
        /// </summary>
        public static string BuildTarget => GetValue(c_DefaultBuildTargetDefault);

        /// <summary>
        /// エクステンションの動作の対象となるNext Designのバージョンの設定値を取得します。
        /// </summary>
        public static string NdVersion => GetValue(c_DefaultNdVersionDefault);

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
