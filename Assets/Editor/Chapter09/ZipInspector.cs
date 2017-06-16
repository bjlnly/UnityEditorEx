using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomEditor(typeof(UnityEditor.SceneAsset))]
[CustomAsset(".zip")]
public class ZipInspector : Editor
{

    public override void OnInspectorGUI()
    {
        GUILayout.Label("例: zip の中身をプレビューとして階層表示");
    }
}

[CustomAsset(".xlsx", ".xlsm", ".xls")]
public class ExcelInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label("例: ScriptableObject に変換するボタンを追加");
    }
}