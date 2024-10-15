using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// V3.1向けのExtensionPointsを利用したプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class New31ExtpCommand : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public New31ExtpCommand() : base("new31-extp", Strings.DescriptionNew31ExtpCommand0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc />
        protected override string TemplateName => "nd31extp";

        /// <inheritdoc />
        protected override string TemplateDescription => Strings.DescriptionTemplateExtpStandardExtensionV31_0;

        #endregion
    }
}
