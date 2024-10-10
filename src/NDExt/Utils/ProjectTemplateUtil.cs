using System.Collections.Generic;

namespace NDExt.Utils
{
    /// <summary>
    /// プロジェクトテンプレートに関するユーティリティです。
    /// </summary>
    internal static class ProjectTemplateUtil
    {
        #region 定数定義

        /// <summary>
        /// NextDesignのプロジェクトテンプレート名。
        /// </summary>
        private const string c_NextDesignProjectTemplates = "NextDesign.Extension.ProjectTemplates";

        #endregion

        #region 公開メソッド

        /// <summary>
        /// プロジェクトテンプレートのパッケージファイルの列挙を取得します。
        /// </summary>
        public static IEnumerable<string> GetTemplatePackages() => new[] { c_NextDesignProjectTemplates };

        #endregion
    }
}