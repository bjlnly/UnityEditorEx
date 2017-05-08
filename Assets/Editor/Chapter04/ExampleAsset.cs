using UnityEngine;
using System.Collections;
using UnityEditor;

//#region  CreateAssetMenu
//[CreateAssetMenu(menuName = "Example/Create ExampleAsset Instance")]
//#endregion
public class ExampleAsset : ScriptableObject {
    #region 实例化
    //ScriptableObject.CreateInstance
    [MenuItem("Example/Create ExampleAsset Instance")]
    static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();
    }

    [MenuItem("Example/Create ExampleAsset")]
    static void CreateExampleAsset()
    {
        var exampleAsset = CreateInstance<ExampleAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/Editor/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }
    #endregion

    #region 属性
    [SerializeField]
    private string str;

    [SerializeField, Range(0, 10)]
    private int number;
    #endregion
}