using System;
using System.Collections.Generic;
using System.Text;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using NDExt.Utils;

namespace NDExt.Commands
{
    /// <summary>
    /// テンプレートのアンインストール
    /// </summary>
    public class UninstallCommand : CommandBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UninstallCommand() : base("uninstall","プロジェクトのテンプレートをアンインストールします。")
        {
            this.Handler = CommandHandler.Create(Handle);
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <returns></returns>
        public int Handle()
        {

            try
            {
                WriteLine("テンプレートをアンインストールしています...");

                // インストール
                var templates = ProjectTemplateUtil.GetTemplatePackages();
                foreach (var template in templates)
                {
                    ExcecuteProcess("dotnet", @$"new -u ""{template}""");
                }

                WriteLine("完了しました。");
                WriteLine("");

                return cSuccess;

            }
            catch (Exception ex)
            {
                WriteError(ex);
                return cFail;
            }        
        }
    }
}
