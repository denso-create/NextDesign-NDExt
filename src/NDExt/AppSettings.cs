using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NDExt
{
    /// <summary>
    /// アプリケーションのコンフィグ情報
    /// </summary>
    public static class AppSettings
    {
        private static IConfigurationRoot Config;

        public static void Initialize(IConfigurationRoot config)
        {
            Config = config;
        }

        
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
        /// ターゲットのビルドフォルダ
        /// </summary>
        public static string DefaultTargetFramweorkBuildFolder => GetValue("netcoreapp3.1");

        /// <summary>
        /// デフォルトのビルドターゲット
        /// </summary>
        public static string DefaultBuildTarget => GetValue("Debug");

        /// <summary>
        /// デフォルトのNDのバージョン
        /// </summary>
        public static string DefaultNdVersion => GetValue("1.3.11");

    }
}
