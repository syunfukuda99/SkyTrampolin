using System;
using System.IO;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class ScreenShooter
{
    [MenuItem("Tools/ScreenShot/Current")]
    static void ScreenShot()
    {
        var name = DateTime.Now.ToString("yyyyMMddHHmmss") + "ScreenShot" + ".png";
        Exec(name);        
    }
    
    [MenuItem("Tools/ScreenShot/1242x2208")]
    static void ScreenShotsFor1242x2208()
    {
        Exec(1242, 2208);
    }

    [MenuItem("Tools/ScreenShot/1242x2688")]
    static void ScreenShotsFor1242x2688()
    {
        Exec(1242, 2688);
    }

    [MenuItem("Tools/ScreenShot/2048x2732")]
    static void ScreenShotsFor2048x2732()
    {
        Exec(2048, 2732);
    }
    
    private static void Exec(int w, int h)
    {
        GameViewUtil.SetResolution(w, h);
        Exec($"{w}x{h}.png");
    }

    private static void Exec(string name)
    {
        var path = Application.dataPath + "/../Screenshot/";
        ScreenCapture.CaptureScreenshot(path + name);
        Debug.Log("Saved: " + path + name);
    }
    
}
