using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Android;

namespace Kogane
{
    /// <summary>
    /// Play Asset Delivery を使用している Android App Bundle を Android 端末にインストールできるクラス
    /// 参考サイト様：https://developer.android.com/guide/playcore/asset-delivery/test?hl=ja#steps-native-java
    /// </summary>
    public static class InstallPlayAssetDeliveryAndroidAppBundle
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// インストールします
        /// </summary>
        public static InstallPlayAssetDeliveryAndroidAppBundleResult Install( in InstallPlayAssetDeliveryAndroidAppBundleData data )
        {
            if ( data.IsSetAndroidHomeToEnvironmentVariable )
            {
                SetAndroidHomeToEnvironmentVariable.Set( EnvironmentVariableTarget.Process );
            }

            const string commandGuids = "3a1c4ae396bbf49e4b53cdcaea4a872c";

            var commandFullPath             = Path.GetFullPath( AssetDatabase.GUIDToAssetPath( commandGuids ) ).Replace( "\\", "/" );
            var aabFullPath                 = Path.GetFullPath( data.AndroidAppBundlePath ).Replace( "\\", "/" );
            var aabDirectoryName            = Path.GetDirectoryName( aabFullPath ).Replace( "\\", "/" );
            var aabFileNameWithoutExtension = Path.GetFileNameWithoutExtension( aabFullPath );
            var apksFullPath                = $"{aabDirectoryName}/{aabFileNameWithoutExtension}.apks";
            var jdkFullPath                 = $"{AndroidExternalToolsSettings.jdkRootPath}/bin/java";
            var bundleToolFullPath          = $"{EditorApplication.applicationPath.Replace( "Unity.app", "" )}/PlaybackEngines/AndroidPlayer/Tools/bundletool-all-1.6.0.jar";

            var info = new ProcessStartInfo( "/bin/bash" )
            {
                Arguments              = $@"""{commandFullPath}"" ""{aabFullPath}"" ""{apksFullPath}"" ""{jdkFullPath}"" ""{bundleToolFullPath}""",
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
                UseShellExecute        = false,
                CreateNoWindow         = false,
            };

            using var process = Process.Start( info );

            process.WaitForExit();

            return new
            (
                process.StandardOutput.ReadToEnd(),
                process.StandardError.ReadToEnd()
            );
        }
    }
}