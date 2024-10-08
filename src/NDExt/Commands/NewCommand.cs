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
        public NewCommand() : base("new", "現在のフォルダにNext Designのエクステンションのプロジェクトを作成します。") { }

        #endregion

        #region プロパティ

        /// <inheritdoc/>
        protected override string TemplateName => "ndext";

        /// <inheritdoc/>
        protected override string TemplateDescription => "Next Designの標準のエクステンションです。";

        #endregion
    }
}
