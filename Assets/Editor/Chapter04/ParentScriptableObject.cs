using UnityEngine;
using System.Collections;
using UnityEditor;

public class ParentScriptableObject : ScriptableObject
{
    const string PATH = "Assets/Editor/New ParentScriptableObject.asset";
    const string childPATH = "Assets/Editor/New ChildScriptableObject.asset";

    [SerializeField]
    ChildScriptableObject child;


    [MenuItem("Assets/Create ParentScriptableObject")]
    static void CreateScriptableObject()
    {
        var parent = ScriptableObject.CreateInstance<ParentScriptableObject>();
        parent.child = ScriptableObject.CreateInstance<ChildScriptableObject>();
        // 增加子资产
        AssetDatabase.AddObjectToAsset(parent.child, PATH);

        AssetDatabase.CreateAsset(parent, PATH);
        AssetDatabase.ImportAsset(PATH);

        //var child = ScriptableObject.CreateInstance<ChildScriptableObject>();

        //AssetDatabase.CreateAsset(child, childPATH);
        //AssetDatabase.ImportAsset(childPATH);
    }
}
