using Microsoft.Extensions.Configuration;
using NDExt.Commands;
using NDExt.Properties;
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
        #region 定数定義

        /// <summary>
        /// アプリケーション名。
        /// </summary>
        private const string c_AppName = "NDExt";

        /// <summary>
        /// 設定ファイル名。
        /// </summary>
        private const string c_SettingFileName = "settings.json";

        #endregion

        #region 公開メソッド

        /// <summary>
        /// アプリケーションのエントリポイント。アプリケーションの開始を処理します。
        /// </summary>
        /// <param name="args">コマンドライン引数。</param>
        /// <returns>アプリケーションの実行結果コード。</returns>
        public int Start(string[] args)
        {
            try
            {
                // 初期化
                Configure();

                // ヘッダ出力
                WriteAppHeader();

                var rootCommand = new RootCommand(c_AppName)
                {
                    Description = Strings.DescriptionCreateExtensionUtility0
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
        /// アプリケーションの設定を初期化します。
        /// </summary>
        private void Configure()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(c_SettingFileName)
                .AddEnvironmentVariables()
                .Build();

            AppSettings.Initialize(config);

        }

        /// <summary>
        /// アプリケーションのヘッダ情報をコンソールに出力します。
        /// </summary>
        private void WriteAppHeader()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            ConsoleUtil.WriteCommandHeader(string.Format(Strings.TitleAppHeaderVersionInfo1, version));
        }

        #endregion
    }
}
