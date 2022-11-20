# Kogane Install Play Asset Delivery Android App Bundle

Play Asset Delivery を使用している Android App Bundle を Android 端末にインストールできるクラス

## 使用例

```cs
using Kogane;
using UnityEditor;
using UnityEngine;

public static class Example
{
    [MenuItem( "Tools/Hoge" )]
    public static void Hoge()
    {
        var data = new InstallPlayAssetDeliveryAndroidAppBundleData
        (
            androidAppBundlePath: "game.aab",
            isSetAndroidHomeToEnvironmentVariable: true
        );

        var result = InstallPlayAssetDeliveryAndroidAppBundle.Install( data );

        Debug.Log( result.Output );
        Debug.LogWarning( result.Error );
    }
}
```