using NDExt.Services;
using System;
using System.CommandLine.Invocation;

namespace NDExt.Commands
{
    /// <summary>
    /// エクステンションのパッケージ化を実行するコマンドクラスです。
    /// </summary>
    public class PackCommand : CommandBase
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public PackCommand() : base("pack", "エクステンションをパッケージ化します。")
        {
            AddOption<string>("--project", "-p", $"対象プロジェクトのディレクトリを指定します。未指定の場合は現在のディレクトリ以下を探索して実行します。");
            AddOption<string>("--ndver", "-v", $"動作の対象となるNext Designのバージョンです。未指定の場合は `{AppSettings.DefaultNdVersion}` です。");
            AddOption<string>("--config", "-c", $"ビルド構成を指定します。`Debug`または`Release`を指定して下さい。未指定の場合は`{AppSettings.DefaultBuildTarget}` です。");
            AddOption<string>("--output", "-o", $"作成したパッケージの格納フォルダを指定します。未指定の場合は `{AppSettings.PackageOutputDir}` です。");
            AddOption<string>("--copydir", "-d", $"作成したパッケージを指定フォルダにもコピーします。");

            Handler = CommandHandler.Create<string, string, string, string, string>(Handle);
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// エクステンションのパッケージ化処理を実行するハンドラメソッド。
        /// </summary>
        /// <see cref="project">対象プロジェクトのディレクトリ。</see>
        /// <see cref="ndver">動作の対象となるNext Designのバージョン。</see>
        /// <see cref="config">ビルド構成。</see>
        /// <see cref="output">作成したパッケージの格納フォルダ。</see>
        /// <see cref="copydir">作成したパッケージを指定フォルダにもコピーするか。</see>
        /// <returns>終了コード。成功時は<see cref="CommandBase.Success"/>、失敗時は<see cref="CommandBase.Fail"/>を返します。</returns>
        private int Handle(string project, string ndver, string config, string output, string copydir)
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
