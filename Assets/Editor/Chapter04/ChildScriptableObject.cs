using UnityEngine;
using System.Collections;
using UnityEditor;

public class ChildScriptableObject : ScriptableObject {
    const string PATH = "Assets/Editor/New ChildScriptableObject.asset";

    [MenuItem("Assets/Create ChildScriptableObject")]
    static void CreateScriptableObject()
    {
        var child = ScriptableObject.CreateInstance<ChildScriptableObject>();

        AssetDatabase.CreateAsset(child, PATH);
        AssetDatabase.ImportAsset(PATH);
    }

    [SerializeField]
    string str;

    public ChildScriptableObject()
    {
        name = "New ChildObj";
    }
}
