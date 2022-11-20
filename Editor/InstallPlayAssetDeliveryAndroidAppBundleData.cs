namespace Kogane
{
    /// <summary>
    /// Play Asset Delivery を使用している Android App Bundle を Android 端末にインストールする時の設定を管理する構造体
    /// </summary>
    public readonly struct InstallPlayAssetDeliveryAndroidAppBundleData
    {
        //================================================================================
        // プロパティ
        //================================================================================
        public string AndroidAppBundlePath                  { get; } // .aab のパス
        public bool   IsSetAndroidHomeToEnvironmentVariable { get; } // ANDROID_HOME を環境変数に設定する場合 true

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InstallPlayAssetDeliveryAndroidAppBundleData
        (
            string androidAppBundlePath,
            bool   isSetAndroidHomeToEnvironmentVariable
        )
        {
            AndroidAppBundlePath                  = androidAppBundlePath;
            IsSetAndroidHomeToEnvironmentVariable = isSetAndroidHomeToEnvironmentVariable;
        }
    }
}