using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Reflection;

public class ExampleWindow : EditorWindow
{
    // 运行时候调用editor脚本    [InitializeOnLoadMethod]

    static void Initialize()
    {
        ExampleWindow window = (ExampleWindow)EditorWindow.GetWindow(typeof(ExampleWindow), true, "ExampleWindow");
        Debug.Log(window);
    }
    [InitializeOnLoadMethod]
    static void GetBultinAssetNames()
    {
        // 读取default中的文件
        var tex = EditorGUIUtility.Load("logo.jpg") as Texture;
        //Debug.Log(tex);
        // 加载内置资源
        //var flags = BindingFlags.Static | BindingFlags.NonPublic;
        //var info = typeof(EditorGUIUtility).GetMethod("GetEditorAssetBundle", flags);
        //var bundle = info.Invoke(null, new object[0]) as AssetBundle;

        //foreach (var n in bundle.GetAllAssetNames())
        //{
        //    Debug.Log(n);
        //}
    }
}