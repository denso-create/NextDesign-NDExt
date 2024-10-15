namespace NDExt
{
    /// <summary>
    /// アプリケーションのエントリポイントクラスです。
    /// </summary>
    class Program
    {
        /// <summary>
        /// アプリケーションの開始メソッド。コマンドライン引数を受け取り、アプリケーションを実行します。
        /// </summary>
        /// <param name="args">コマンドライン引数。</param>
        /// <returns>アプリケーションの終了コード。</returns>
        static int Main(string[] args)
        {
            var app = new NDExtApp();
            return app.Start(args);
        }
    }
}
