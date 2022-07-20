using System;
using System.Collections.Generic;
using System.Text;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using NDExt.Utils;
using NDExt.Services;

namespace NDExt.Commands
{
    /// <summary>
    /// エクステンションのパッケージ化
    /// </summary>
    public class PackCommand : CommandBase
    {
        public PackCommand() : base("pack", "エクステンションをパッケージ化します。")
        {
            AddOption<string>("--project", "-p", $"対象プロジェクトのディレクトリを指定します。未指定の場合は現在のディレクトリ以下を探索して実行します。");
            AddOption<string>("--ndver", "-v", $"動作の対象となるNext Designのバージョンです。未指定の場合は `{AppSettings.DefaultNdVersion}` です。");
            AddOption<string>("--config", "-c", $"ビルド構成を指定します。`Debug`または`Release`を指定して下さい。未指定の場合は`{AppSettings.DefaultBuildTarget}` です。");
            AddOption<string>("--output", "-o", $"作成したパッケージの格納フォルダを指定します。未指定の場合は `{AppSettings.PackageOutputDir}` です。");
            AddOption<string>("--copydir", "-d", $"作成したパッケージを指定フォルダにもコピーします。");

            Handler = CommandHandler.Create<string,string,string,string,string>(Handle);
        }

        /// <summary>
        /// コマンドハンドラ
        /// </summary>
        /// <returns></returns>
        private int Handle(string project,string ndver,string config,string output,string copydir)
        {
            try
            {

                WriteLine("エクステンションをパッケージ化しています...");

                var request = new PackageRequest()
                {
                    TargetDir = project,
                    NDVersion = ndver,
                    BuildConfig = config,
                    OutputDir = output,
                    CopyDir = copydir
                };

                // 初期値をセット
                request.SetDefaults();

                // パッケージ化を実行します。
                var service = new PackageService();
                service.Package(request);
                return cSuccess;

            } catch ( Exception ex)
            {
                WriteError(ex);
                return cFail;
            }

        }
    }
}
