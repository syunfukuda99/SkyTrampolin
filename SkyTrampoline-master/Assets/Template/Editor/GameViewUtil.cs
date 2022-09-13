using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;


// https://answers.unity.com/questions/956123/add-and-select-game-view-resolution.html?_ga=2.243694786.617270598.1583987075-510696173.1559639315
public class GameViewUtil
{
    static object gameViewSizesInstance;
    static MethodInfo getGroup;
    
    static GameViewUtil()
    {
        // gameViewSizesInstance  = ScriptableSingleton<GameViewSizes>.instance;
        var sizesType = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSizes");
        var singleType = typeof(ScriptableSingleton<>).MakeGenericType(sizesType);
        var instanceProp = singleType.GetProperty("instance");
        getGroup = sizesType.GetMethod("GetGroup");
        gameViewSizesInstance = instanceProp.GetValue(null, null);
    }
    
    public enum GameViewSizeType
    {
        AspectRatio, FixedResolution
    }
    
    public static void SetResolution(int w, int h)
    { 
        int idx = FindSize(GameViewSizeGroupType.Standalone, w, h);
        Debug.Log(idx);
        if (idx == -1)
        {
            AddCustomSize(GameViewSizeType.AspectRatio, GameViewSizeGroupType.Standalone,
                w, h, $"{w}x{h}");
            idx = FindSize(GameViewSizeGroupType.Standalone, w, h);
            Debug.Log(idx);
        }
        SetSize(idx);
    }    

    private static void SetSize(int index)
    {
      var gvWndType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
      var selectedSizeIndexProp = gvWndType.GetProperty("selectedSizeIndex",
              BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      var gvWnd = EditorWindow.GetWindow(gvWndType);
      selectedSizeIndexProp.SetValue(gvWnd, index, null);
    }
    
    // [MenuItem("Test/SizeDimensionsQuery")]
    // public static void SizeDimensionsQueryTest()
    // {
    //   Debug.Log(SizeExists(GameViewSizeGroupType.Standalone, 123, 456));
    // }
    
    private static void AddCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
    {
      // GameViewSizes group = gameViewSizesInstance.GetGroup(sizeGroupTyge);
      // group.AddCustomSize(new GameViewSize(viewSizeType, width, height, text);
    
      var group = GetGroup(sizeGroupType);
      var addCustomSize = getGroup.ReturnType.GetMethod("AddCustomSize"); // or group.GetType().
      var gvsType = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSize");
      // UnityEditor.GameViewSize
      var ctor = gvsType.GetConstructor(new Type[] { typeof(GameViewSizeType), typeof(int), typeof(int), typeof(string) });
      ctor = gvsType.GetConstructors()[0];
      var newSize = ctor.Invoke(new object[] {(int)viewSizeType, width, height, text });
      addCustomSize.Invoke(group, new object[] { newSize });
    }
    
    private static int FindSize(GameViewSizeGroupType sizeGroupType, int width, int height)
    {
      // goal:
      // GameViewSizes group = gameViewSizesInstance.GetGroup(sizeGroupType);
      // int sizesCount = group.GetBuiltinCount() + group.GetCustomCount();
      // iterate through the sizes via group.GetGameViewSize(int index)

        var group = GetGroup(sizeGroupType);
        var groupType = group.GetType();
        var getBuiltinCount = groupType.GetMethod("GetBuiltinCount");
        var getCustomCount = groupType.GetMethod("GetCustomCount");
        int sizesCount = (int)getBuiltinCount.Invoke(group, null) + (int)getCustomCount.Invoke(group, null);
        var getGameViewSize = groupType.GetMethod("GetGameViewSize");
        var gvsType = getGameViewSize.ReturnType;
        var widthProp = gvsType.GetProperty("width");
        var heightProp = gvsType.GetProperty("height");
        var indexValue = new object[1];
        for(int i = (int)getBuiltinCount.Invoke(group, null); i < sizesCount; i++)
        {
          indexValue[0] = i;
          var size = getGameViewSize.Invoke(group, indexValue);
          int sizeWidth = (int)widthProp.GetValue(size, null);
          int sizeHeight = (int)heightProp.GetValue(size, null);
          if (sizeWidth == width && sizeHeight == height)
              return i + 2;
        }
        return -1;
    }
    
    private static object GetGroup(GameViewSizeGroupType type)
    {
      return getGroup.Invoke(gameViewSizesInstance, new object[] { (int)type });
    }
    
}
