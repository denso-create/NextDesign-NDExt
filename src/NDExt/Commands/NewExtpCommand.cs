using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NDExt.Commands
{
    /// <summary>
    /// ExtensionPointsを利用した新規作成コマンド
    /// </summary>
    public class NewExtpommand : NewCommandBase
    {
        public NewExtpommand() : base("new-extp", "現在のフォルダにExtensionPointsライブラリを用いたエクステンションのプロジェクトを作成します。") { }

        protected override string TemplateName => "ndextp";

        protected override string TemplateDescription => "ExtensionPointsライブラリを用いたエクステンションです（推奨）。";
    }
}
