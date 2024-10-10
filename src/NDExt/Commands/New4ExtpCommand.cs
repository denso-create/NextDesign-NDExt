using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// V4.0向けのExtensionPointsを利用したプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class New4ExtpCommand : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public New4ExtpCommand() : base("new4-extp", Strings.DescriptionNew4ExtpCommand0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc />
        protected override string TemplateName => "nd4extp";

        /// <inheritdoc />
        protected override string TemplateDescription => Strings.DescriptionTemplateExtpStandardExtensionV4_0;

        #endregion
    }
}
