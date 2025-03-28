﻿using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// ExtensionPointsを利用したプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class NewExtpCommand : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public NewExtpCommand() : base("new-extp", Strings.DescriptionNewExtpCommand0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc />
        protected override string TemplateName => "ndextp";

        /// <inheritdoc />
        protected override string TemplateDescription => Strings.DescriptionTemplateExtpStandardExtension0;

        #endregion
    }
}
