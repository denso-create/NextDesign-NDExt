using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// V3.1向けのエクステンションプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class New31Command : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public New31Command() : base("new31", Strings.DescriptionNew31Command0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc/>
        protected override string TemplateName => "nd31ext";

        /// <inheritdoc/>
        protected override string TemplateDescription => Strings.DescriptionTemplateStandardExtensionV31_0;

        #endregion
    }
}
