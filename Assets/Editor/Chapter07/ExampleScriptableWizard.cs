#region ScriptableWizard

using UnityEditor;
using UnityEngine;

public class ExampleScriptableWizard : ScriptableWizard
{
    public string gameObjectName;
    [MenuItem("Window/ExampleScriptableWizard")]
    static void Open()
    {
        //DisplayWizard<ExampleScriptableWizard>("Example Wizard");

        #region OnWizardOtherButton 添加另一个按钮
        DisplayWizard<ExampleScriptableWizard>("Example Wizard", "Create", "Find");
        #endregion
    }

    #region OnWizardCreate 给创建按钮添加事件
    void OnWizardCreate()
    {
        new GameObject(gameObjectName);
    }
    #endregion

    #region OnWizardOtherButton 添加另一个按钮
    void OnWizardOtherButton()
    {
        var gameObject = GameObject.Find(gameObjectName);
        if (gameObject == null)
        {
            Debug.Log("找不到Gameobject");
        }
    }
    #endregion

    #region OnWizardUpdate 有值变化时候调用
    void OnWizardUpdate()
    {
        Debug.Log("Update");
    }
    #endregion

    #region DrawWizardGUI 自定义ui
    //protected override bool DrawWizardGUI()
    //{
    //    EditorGUILayout.LabelField("Label");
    //    return true;
    //}
    #endregion

    #region OnGUI会重写效果
    //void OnGUI()
    //{

    //}
    #endregion

    #region PreferenceItem 添加到偏好菜单
    [PreferenceItem("Example")]
    static void OnPreferenceGUI()
    {

    }
    #endregion
}
#endregion

#region IHasCustomMenu添加菜单

public class ExampleCustomMenu : EditorWindow, IHasCustomMenu
{
    // 添加菜单
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("example"), false, () =>
        {
            
        });

        menu.AddItem(new GUIContent("example2"), false, () =>
        {

        });
        Transform trl;
    }

    [MenuItem("Window/ExampleCustomMenu")]
    static void Open()
    {
        #region EditorWindow.titleContent
        //var window = GetWindow<ExampleCustomMenu>();
        //// 固定窗口大小
        //window.maxSize = window.minSize = new Vector2(300, 300);

        //// 图标添加到窗口
        //var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Example.jpg");
        //window.titleContent = new GUIContent("Hoge", icon);
        #endregion

        #region FindObjectsOfTypeAll
        //var sceneViews = Resources.FindObjectsOfTypeAll<SceneView>();
        #endregion
    }

    #region EditorWindow也是个ScriptableObject
    [MenuItem("Assets/Save EditorWindow")]
    static void SaveEditorWindow()
    {
        AssetDatabase.CreateAsset(CreateInstance<ParentScriptableObject>(), "Assets/Editor/Chapter07/Example.asset");
        AssetDatabase.Refresh();
    }

    [SerializeField]
    string text;

    [SerializeField]
    bool boolean;
    #endregion
}
#endregion