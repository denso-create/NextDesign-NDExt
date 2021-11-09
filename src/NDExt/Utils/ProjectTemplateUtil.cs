using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NDExt.Utils
{
    /// <summary>
    /// プロジェクトテンプレートに関するユーティリティです。
    /// </summary>
    internal static class ProjectTemplateUtil
    {
        /// <summary>
        /// プロジェクトテンプレートのパッケージファイル
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetTemplatePackages()
        {
            var packages = new string[] { "NextDesign.Extension.ProjectTemplates" };
            return packages;
        }

    }
}
