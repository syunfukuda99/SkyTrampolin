using UnityEngine;
using System.Runtime.InteropServices;

namespace System.Net
{
    public class Vibrator
    {
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
        public static AndroidJavaClass unityPlayer;
        public static AndroidJavaObject currentActivity;
        public static AndroidJavaObject vibrator;
#endif

        public static void Tap()
        {
                if (isAndroid()) VibrateAndroid(5);
                else if (isIOS()) VibrateIOS(1519);
                else Handheld.Vibrate();
        }

        private static void VibrateAndroid(long milliseconds)
        { 
                vibrator.Call("vibrate", milliseconds);
         
        }
        
#if UNITY_IOS && !UNITY_EDITOR
        [DllImport ("__Internal")]
        static extern void playSystemSound(int n);
#endif

        private static void VibrateIOS(int n) //引数にIDを渡す
        {
#if UNITY_IOS && !UNITY_EDITOR
            playSystemSound(n);
#endif
        }        
        private static bool isAndroid()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }

        private static bool isIOS()
        {
#if UNITY_IOS
            return true;
#else
            return false;
#endif
        }          
    }
}