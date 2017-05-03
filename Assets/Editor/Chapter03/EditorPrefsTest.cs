using UnityEngine;
using UnityEditor;

public class EditorPrefsTest : EditorWindow
{
    [MenuItem("Window/EditorPrefsTest")]
    static void Open()
    {
        GetWindow<EditorPrefsTest>();
    }
    #region SaveTime
    //int intervalTime = 60;
    //const string AUTO_SAVE_INTERVAL_TIME = "AutoSave interval time (sec)";
    //void OnEnable()
    //{
    //    intervalTime = EditorPrefs.GetInt(AUTO_SAVE_INTERVAL_TIME, 60);
    //}

        //不推荐
    //void OnGUI()
    //{
    //    EditorGUI.BeginChangeCheck();

    //    //自動保存間隔（秒）
    //    intervalTime = EditorGUILayout.IntSlider("间隔（秒）", intervalTime, 1, 3600);

    //    if (EditorGUI.EndChangeCheck())
    //        EditorPrefs.SetInt(AUTO_SAVE_INTERVAL_TIME, intervalTime);
    //}
    #endregion

    #region 窗口大小
    const string SIZE_WIDTH_KEY = "ExampleWindow size width";
    const string SIZE_HEIGHT_KEY = "ExampleWindow size height";

    private void OnEnable()
    {
        var width = EditorPrefs.GetFloat(SIZE_WIDTH_KEY, 600);
        var height = EditorPrefs.GetFloat(SIZE_HEIGHT_KEY, 400);
        position = new Rect(position.x, position.y, width, height);
    }

    // 推荐
    private void OnDisable()
    {
        EditorPrefs.SetFloat(SIZE_WIDTH_KEY, position.x);
        EditorPrefs.SetFloat(SIZE_HEIGHT_KEY, position.y);
    }
    #endregion
}