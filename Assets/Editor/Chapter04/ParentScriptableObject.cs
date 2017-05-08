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
        // 隐藏子资产
        parent.child.hideFlags = HideFlags.HideInHierarchy;

        // 增加子资产
        AssetDatabase.AddObjectToAsset(parent.child, PATH);

        AssetDatabase.CreateAsset(parent, PATH);
        AssetDatabase.ImportAsset(PATH);

        //var child = ScriptableObject.CreateInstance<ChildScriptableObject>();

        //AssetDatabase.CreateAsset(child, childPATH);
        //AssetDatabase.ImportAsset(childPATH);
    }

    #region 释放资源结构
    [MenuItem("Assets/Set to HideFlags.None")]
    static void SetHideFlags()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);

        foreach (var item in AssetDatabase.LoadAllAssetsAtPath(path))
        {
            item.hideFlags = HideFlags.None;
        }

        AssetDatabase.ImportAsset(path);
    }
    #endregion

    #region 删除子资产
    [MenuItem("Assets/Remove ChildScriptableObject")]
    static void Remove()
    {
        var parent = AssetDatabase.LoadAssetAtPath<ParentScriptableObject>(PATH);
        Object.DestroyImmediate(parent.child, true);
        parent.child = null;
        AssetDatabase.ImportAsset(PATH);
    }

    #endregion
}
