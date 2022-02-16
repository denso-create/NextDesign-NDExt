using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NDExt.Commands
{
    /// <summary>
    /// 新規作成コマンド
    /// </summary>
    public class NewCommand : NewCommandBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewCommand() : base("new", "現在のフォルダにNext Designのエクステンションのプロジェクトを作成します。") { }


        /// <inheritdoc/>
        protected override string TemplateName => "ndext";

        /// <inheritdoc/>
        protected override string TemplateDescription => "Next Designの標準のエクステンションです。";
    }
}
