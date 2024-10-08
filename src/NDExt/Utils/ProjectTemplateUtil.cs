using System.Collections.Generic;

namespace NDExt.Utils
{
    /// <summary>
    /// プロジェクトテンプレートに関するユーティリティです。
    /// </summary>
    internal static class ProjectTemplateUtil
    {
        #region 公開メソッド

        /// <summary>
        /// プロジェクトテンプレートのパッケージファイル
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetTemplatePackages()
        {
            var packages = new string[] { "NextDesign.Extension.ProjectTemplates" };
            return packages;
        }

        #endregion
    }
}
