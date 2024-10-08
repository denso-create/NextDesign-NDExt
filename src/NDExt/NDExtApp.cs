using Microsoft.Extensions.Configuration;
using NDExt.Commands;
using NDExt.Utils;
using System;
using System.CommandLine;
using System.Reflection;

namespace NDExt
{
    /// <summary>
    /// アプリケーション
    /// </summary>
    internal class NDExtApp
    {
        #region 公開メソッド

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="args"></param>
        public int Start(string[] args)
        {
            try
            {
                // 初期化
                Configure();

                // ヘッダ出力
                WriteAppHeader();

                var rootCommand = new RootCommand("NDExt")
                {
                    Description = "Next Designのエクステンションを作成できるユーティリティです。"
                };

                // サブコマンドの登録
                rootCommand.AddCommand(new InstallCommand());
                rootCommand.AddCommand(new NewCommand());
                rootCommand.AddCommand(new NewExtpCommand());
                rootCommand.AddCommand(new PackCommand());
                rootCommand.AddCommand(new UninstallCommand());

                // 実行
                rootCommand.InvokeAsync(args);

            }
            catch (Exception ex)
            {
                ConsoleUtil.WriteError(ex);
            }
            ConsoleUtil.WriteLine();

            return 0;
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// 設定の初期化
        /// </summary>
        private void Configure()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("settings.json")
                .AddEnvironmentVariables()
                .Build();

            AppSettings.Initialize(config);

        }

        /// <summary>
        /// ヘッダの出力
        /// </summary>
        private void WriteAppHeader()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            ConsoleUtil.WriteLine($"# ===============================================================");
            ConsoleUtil.WriteLine($"#");
            ConsoleUtil.WriteLine($"# Next Design Extension Utility - Version {version}");
            ConsoleUtil.WriteLine($"#");
            ConsoleUtil.WriteLine($"# ===============================================================");
        }

        #endregion
    }
}
