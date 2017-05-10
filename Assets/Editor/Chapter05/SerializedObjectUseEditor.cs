using UnityEngine;
using System.Collections;
using UnityEditor;
/// <summary>
/// 更新
/// </summary>
[CustomEditor(typeof(SerializedObjectUse))]
public class SerializedObjectUseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var hoge = GameObject.Find("HogeForSer").GetComponent<HogeForSer>();

        var serializedObject = new SerializedObject(hoge);
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("position"));
        serializedObject.ApplyModifiedProperties();
    }
}