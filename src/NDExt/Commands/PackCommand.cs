using NDExt.Services;
using System;
using System.CommandLine.Invocation;
using NDExt.Properties;

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
        public PackCommand() : base("pack", Strings.DescriptionPackCommand0)
        {
            AddOption<string>("--project", "-p", Strings.DescriptionPackCommandProjectDir0);
            AddOption<string>("--ndver", "-v", string.Format(Strings.DescriptionPackCommandNDVersion1, AppSettings.NdVersion));
            AddOption<string>("--config", "-c", string.Format(Strings.DescriptionPackCommandBuildConfig1, AppSettings.BuildTarget));
            AddOption<string>("--output", "-o", string.Format(Strings.DescriptionPackCommandOutputDir1, AppSettings.PackageOutputDir));
            AddOption<string>("--copydir", "-d", Strings.DescriptionPackCommandCopyDir0);

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
        /// <see cref="copydir">作成したパッケージのコピー先フォルダ。</see>
        /// <returns>終了コード。成功時は<see cref="CommandBase.Success"/>、失敗時は<see cref="CommandBase.Fail"/>を返します。</returns>
        private int Handle(string project, string ndver, string config, string output, string copydir)
        {
            try
            {
                WriteLine(Strings.StatusPackagingExtension0);

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
