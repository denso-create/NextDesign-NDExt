using System;

namespace NDExt
{
    /// <summary>
    /// ユーザーエクセプション。
    /// </summary>
    public class UserException : Exception
    {
        #region 構築・消滅

        /// <summary>
        /// メッセージのみを指定した例外インスタンスを生成します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        public UserException(string message) : base(message) { }

        /// <summary>
        /// メッセージと内部例外オブジェクトを指定した例外インスタンスを生成します。
        /// </summary>
        /// <param name="message">メッセージ。</param>
        /// <param name="exception">エクセプション。</param>
        public UserException(string message, Exception exception) : base(message, exception) { }

        #endregion

    }
}
