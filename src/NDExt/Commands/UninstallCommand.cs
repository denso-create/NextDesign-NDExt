using NDExt.Properties;
using NDExt.Utils;
using System;
using System.CommandLine.Invocation;

namespace NDExt.Commands
{
    /// <summary>
    /// テンプレートのアンインストールを実行するコマンドクラスです。
    /// </summary>
    public class UninstallCommand : CommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UninstallCommand() : base("uninstall", Strings.DescriptionUninstallCommand0)
        {
            this.Handler = CommandHandler.Create(Handle);
        }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// アンインストール処理を実行するハンドラメソッド。
        /// </summary>
        /// <returns>終了コード。成功時は<see cref="CommandBase.Success"/>、失敗時は<see cref="CommandBase.Fail"/>を返します。</returns>
        public int Handle()
        {
            try
            {
                ConsoleUtil.WriteHeader(Strings.HeaderTemplateUninstalling0);

                // インストール
                var templates = ProjectTemplateUtil.GetTemplatePackages();
                foreach (var template in templates)
                {
                    ExecuteProcess("dotnet", @$"new -u ""{template}""");
                }

                WriteLine(Strings.LogCompletion0);
                WriteLine("");

                return Success;

            }
            catch (Exception ex)
            {
                WriteError(ex);
                return Fail;
            }
        }

        #endregion
    }
}
