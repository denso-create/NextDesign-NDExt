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
    /// テンプレートのインストール
    /// </summary>
    public class InstallCommand : CommandBase
    {
        public InstallCommand() : base("install", "プロジェクトのテンプレートをインストールします。最初に実行して下さい。")
        {
            Handler = CommandHandler.Create(Handle);
        }

        private int Handle()
        {
            try
            {
                ConsoleUtil.WriteHeader("テンプレートをインストールしています...");

                // インストール
                var templates = ProjectTemplateUtil.GetTemplatePackages();
                foreach (var template in templates)
                {
                    ExcecuteProcess("dotnet", @$"new -i ""{template}""");
                }

                WriteLine("完了しました。");
                WriteLine("* `ndext new` `ndext new-*`  コマンドでNext Designのエクステンションが作成できます。");
                WriteLine("* `dotnet new`コマンドでもエクステンションが作成できます。");
                WriteLine("");

                return cSuccess;

            } catch ( Exception ex)
            {
                WriteError(ex);
                return cFail;
            }
        }
    }
}
