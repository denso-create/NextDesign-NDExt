using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// V4.0向けのエクステンションプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class New4Command : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public New4Command() : base("new4", Strings.DescriptionNew4Command0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc/>
        protected override string TemplateName => "nd4ext";

        /// <inheritdoc/>
        protected override string TemplateDescription => Strings.DescriptionTemplateStandardExtensionV4_0;

        #endregion
    }
}
