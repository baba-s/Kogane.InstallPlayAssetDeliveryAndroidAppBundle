namespace Kogane
{
    /// <summary>
    /// Play Asset Delivery を使用している Android App Bundle を Android 端末にインストールした時の結果を管理する構造体
    /// </summary>
    public readonly struct InstallPlayAssetDeliveryAndroidAppBundleResult
    {
        //================================================================================
        // プロパティ
        //================================================================================
        public string Output { get; } // .command 実行時に出力されたテキスト
        public string Error  { get; } // .command 実行時に出力されたエラー

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InstallPlayAssetDeliveryAndroidAppBundleResult
        (
            string output,
            string error
        )
        {
            Output = output;
            Error  = error;
        }
    }
}