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
        /// <param name="name"></param>
        protected CommandBase(string name) : base(name) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected CommandBase(string name, string description) : base(name, description) { }

        #endregion

        #region 内部メソッド

        #region 情報の取得

        /// <summary>
        /// アプリケーションのベースディレクトリを取得します
        /// </summary>
        /// <returns></returns>
        protected static string AppDir => Env.AppDir;

        /// <summary>
        /// 現在のディレクトリ
        /// </summary>
        protected static string CurrentDir => Env.CurrentDir;

        #endregion

        #region プロセスの実行

        /// <summary>
        /// プロセスの実行
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected static int ExecuteProcess(string filename, string args)
        {
            return ProcessUtil.Start(filename, args);
        }

        #endregion

        #region パラメータ作成

        /// <summary>
        /// Argumentの追加
        /// </summary>
        /// <typeparam name="T">引数の型</typeparam>
        /// <param name="name">引数名</param>
        /// <param name="description">説明</param>
        /// <returns></returns>
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
        /// Optionの追加
        /// </summary>
        /// <typeparam name="T">オプションの型</typeparam>
        /// <param name="name">オプション名</param>
        /// <param name="alias">エイリアス</param>
        /// <param name="description">説明</param>
        /// <returns></returns>
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
        /// メッセージを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        protected static void WriteLine(string message)
        {
            ConsoleUtil.WriteLine(message);
        }

        /// <summary>
        /// エラーを出力します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="ex">例外オブジェクト。既定値はnullです。</param>
        protected static void WriteError(string message, Exception ex = null)
        {
            ConsoleUtil.WriteError(message, ex);
        }

        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="ex">例外オブジェクト。既定値はnullです。</param>
        protected static void WriteError(Exception ex)
        {
            ConsoleUtil.WriteError(ex);
        }

        #endregion

        #endregion
    }
}
