using NDExt.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NDExt.Services
{
    /// <summary>
    /// パッケージの実行要求オブジェクトです
    /// </summary>
    public class PackageRequest
    {
        /// <summary>
        /// 実行対象のディレクトリ
        /// </summary>
        public string TargetDir { get; set; } 

        /// <summary>
        /// Debug/Release
        /// </summary>
        public string BuildConfig { get; set; }

        /// <summary>
        /// ターゲットのビルドフォルダ
        /// </summary>
        public string TargetFramweorkBuildFolder { get; set; } 

        /// <summary>
        /// パッケージの出力先ディレクトリ名
        /// </summary>
        public string OutputDir { get; set; }

        /// <summary>
        /// コピー先ディレクトリ
        /// </summary>
        public string CopyDir { get; set; }

        /// <summary>
        /// 対応するNDのバージョン
        /// "2.0"など
        /// </summary>
        public string NDVersion { get; set; } 

        /// <summary>
        /// 初期値をセット
        /// </summary>
        public void SetDefaults()
        {
            if (string.IsNullOrEmpty(NDVersion)) NDVersion = AppSettings.DefaultNdVersion;
            if (string.IsNullOrEmpty(TargetFramweorkBuildFolder)) TargetFramweorkBuildFolder = AppSettings.DefaultTargetFramweorkBuildFolder;
            if (string.IsNullOrEmpty(BuildConfig)) BuildConfig = AppSettings.DefaultBuildTarget;
            if (string.IsNullOrEmpty(OutputDir)) OutputDir = AppSettings.PackageOutputDir;
            if (string.IsNullOrEmpty(TargetDir)) TargetDir = Env.CurrentDir;
        }
    }
}
