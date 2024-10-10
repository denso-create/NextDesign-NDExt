using NDExt.Utils;
using System;
using System.CommandLine;

namespace NDExt.Commands
{
    /// <summary>
    /// コマンドのベース
    /// </summary>
    public abstract class CommandBase : Command
    {
        #region 定数

        /// <summary>
        /// 成功
        /// </summary>
        public const int Success = 0;

        /// <summary>
        /// 失敗
        /// </summary>
        public const int Fail = 1;

        #endregion

        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">コマンド名。</param>
        protected CommandBase(string name) : base(name) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">コマンド名。</param>
        /// <param name="description">コマンドの説明。</param>
        protected CommandBase(string name, string description) : base(name, description) { }

        #endregion

        #region 内部メソッド

        #region 情報の取得

        /// <summary>
        /// アプリケーションのベースディレクトリを取得します。
        /// </summary>
        protected static string AppDir => Env.AppDir;

        /// <summary>
        /// 現在のディレクトリを取得します。
        /// </summary>
        protected static string CurrentDir => Env.CurrentDir;

        #endregion

        #region プロセスの実行

        /// <summary>
        /// 外部プロセスを実行します。
        /// </summary>
        /// <param name="filename">実行するファイル名。</param>
        /// <param name="args">プロセスに渡す引数。</param>
        /// <returns>プロセスの実行結果を表す終了コード。</returns>
        protected static int ExecuteProcess(string filename, string args)
        {
            return ProcessUtil.Start(filename, args);
        }

        #endregion

        #region パラメータ作成

        /// <summary>
        /// コマンドにArgumentを追加します。
        /// </summary>
        /// <typeparam name="T">引数の型。</typeparam>
        /// <param name="name">引数名。</param>
        /// <param name="description">引数の説明。</param>
        /// <returns>追加された引数のオブジェクト。</returns>
        protected Argument AddArgument<T>(string name, string description)
        {
            var arg = new Argument<T>(name)
            {
                Description = description
            };
            AddArgument(arg);
            return arg;
        }

        /// <summary>
        /// コマンドにOptionを追加します。
        /// </summary>
        /// <typeparam name="T">オプションの型。</typeparam>
        /// <param name="name">オプション名。</param>
        /// <param name="alias">オプションのエイリアス。</param>
        /// <param name="description">オプションの説明。</param>
        /// <returns>追加されたオプションのオブジェクト。</returns>
        protected Option AddOption<T>(string name, string alias, string description)
        {
            var opt = new Option<T>(name)
            {
                Description = description
            };
            opt.AddAlias(alias);
            AddOption(opt);
            return opt;
        }

        #endregion

        #region メッセージ出力

        /// <summary>
        /// メッセージを標準出力に書き込みます。
        /// </summary>
        /// <param name="message">出力するメッセージ。</param>
        protected static void WriteLine(string message)
        {
            ConsoleUtil.WriteLine(message);
        }

        /// <summary>
        /// エラーメッセージを標準エラー出力に書き込みます。
        /// </summary>
        /// <param name="message">エラーメッセージ。</param>
        /// <param name="ex">例外オブジェクト（省略可能）。</param>
        protected static void WriteError(string message, Exception ex = null)
        {
            ConsoleUtil.WriteError(message, ex);
        }

        /// <summary>
        /// 例外の詳細を標準エラー出力に書き込みます。
        /// </summary>
        /// <param name="ex">例外オブジェクト。</param>
        protected static void WriteError(Exception ex)
        {
            ConsoleUtil.WriteError(ex);
        }

        #endregion

        #endregion
    }
}
