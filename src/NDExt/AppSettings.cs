using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NDExt
{
    /// <summary>
    /// アプリケーションのコンフィグ情報
    /// IConfigurationRootをラップしたオブジェクトです。
    /// </summary>
    public static class AppSettings
    {
        private static IConfigurationRoot Config;

        /// <summary>
        /// Configオブジェクトで初期化
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(IConfigurationRoot config)
        {
            Config = config;
        }

        
        /// <summary>
        /// 値を取得します
        /// </summary>
        /// <param name="defaultValue">エントリがない場合のデフォルト値</param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetValue(string defaultValue,[CallerMemberName] string name=null)
        {
            var val = Config[name];
            if (string.IsNullOrEmpty(val))
            {
                return defaultValue;
            }
            return val;
        }

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
    }
}
