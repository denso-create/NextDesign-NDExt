using NDExt.Properties;
using NDExt.Utils;
using System;
using System.CommandLine.Invocation;

namespace NDExt.Commands
{
    /// <summary>
    /// テンプレートのインストールを実行するコマンドクラスです。
    /// </summary>
    public class InstallCommand : CommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public InstallCommand() : base("install", Strings.DescriptionInstallCommand0)
        {
            Handler = CommandHandler.Create(Handle);
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// インストール処理を実行するハンドラメソッド。
        /// </summary>
        /// <returns>終了コード。成功時は<see cref="CommandBase.Success"/>、失敗時は<see cref="CommandBase.Fail"/>を返します。</returns>
        private int Handle()
        {
            try
            {
                ConsoleUtil.WriteHeader(Strings.HeaderInstallingTemplates0);

                // インストール
                var templates = ProjectTemplateUtil.GetTemplatePackages();
                foreach (var template in templates)
                {
                    ExecuteProcess("dotnet", @$"new install ""{template}""");
                }

                WriteLine(Strings.LogInstallationCompleted0);
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
