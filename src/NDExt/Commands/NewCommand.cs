using NDExt.Properties;

namespace NDExt.Commands
{
    /// <summary>
    /// エクステンションプロジェクトの新規作成を実行するコマンドクラスです。
    /// </summary>
    public class NewCommand : NewCommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewCommand() : base("new", Strings.DescriptionNewCommand0) { }

        #endregion

        #region プロパティ

        /// <inheritdoc/>
        protected override string TemplateName => "ndext";

        /// <inheritdoc/>
        protected override string TemplateDescription => Strings.DescriptionTemplateStandardExtensionV4_0;

        #endregion
    }
}
