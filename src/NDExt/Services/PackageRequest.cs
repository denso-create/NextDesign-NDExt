using NDExt.Utils;

namespace NDExt.Services
{
    /// <summary>
    /// パッケージの実行要求オブジェクトです。
    /// </summary>
    public class PackageRequest
    {
        #region プロパティ

        /// <summary>
        /// 実行対象のディレクトリを取得または設定します。
        /// </summary>
        public string TargetDir { get; set; }

        /// <summary>
        /// Debug/Releaseを取得または設定します。
        /// </summary>
        public string BuildConfig { get; set; }

        /// <summary>
        /// パッケージの出力先ディレクトリ名を取得または設定します。
        /// </summary>
        public string OutputDir { get; set; }

        /// <summary>
        /// コピー先ディレクトリを取得または設定します。
        /// </summary>
        public string CopyDir { get; set; }

        /// <summary>
        /// 対応するNDのバージョンを取得または設定します。
        /// "3.0"など
        /// </summary>
        public string NDVersion { get; set; }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 初期値をセットします。
        /// </summary>
        public void SetDefaults()
        {
            if (string.IsNullOrEmpty(NDVersion)) NDVersion = AppSettings.DefaultNdVersion;
            if (string.IsNullOrEmpty(BuildConfig)) BuildConfig = AppSettings.DefaultBuildTarget;
            if (string.IsNullOrEmpty(OutputDir)) OutputDir = AppSettings.PackageOutputDir;
            if (string.IsNullOrEmpty(TargetDir)) TargetDir = Env.CurrentDir;
        }

        #endregion
    }
}
