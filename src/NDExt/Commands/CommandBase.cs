using NDExt.Utils;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Reflection;
using System.Text;

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
        public const int cSuccess = 0;

        /// <summary>
        /// 失敗
        /// </summary>
        public const int cFail = 1;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public CommandBase(string name) : base(name) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CommandBase(string name, string description) : base(name, description) { }

        #endregion

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
        protected static int ExcecuteProcess(string filename,string args)
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
        protected Argument AddArgument<T>(string name,string description)
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
        protected Option AddOption<T>(string name,string alias, string description)
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
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected static void WriteLine(string message)
        {
            ConsoleUtil.WriteLine(message);
        }

        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected static void WriteError(string message, Exception ex = null)
        {
            ConsoleUtil.WriteError(message, ex);
        }


        /// <summary>
        /// エラーの出力
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected static void WriteError(Exception ex)
        {
            ConsoleUtil.WriteError(ex);
        }

        #endregion
    }
}
