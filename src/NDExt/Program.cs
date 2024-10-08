namespace NDExt
{
    /// <summary>
    /// エントリポイント
    /// </summary>
    class Program
    {
        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="args"></param>
        static int Main(string[] args)
        {
            var app = new NDExtApp();
            return app.Start(args);
        }
    }
}
