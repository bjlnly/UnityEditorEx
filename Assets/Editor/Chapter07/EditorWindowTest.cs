using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorWindowTest : EditorWindow
{
    #region 唯一化窗口
    private static EditorWindowTest exampleWindow;
    #endregion

    #region PopupWindow
    ExamplePopupContent popupContent = new ExamplePopupContent();
    #endregion
    [MenuItem("Window/EditorWindowTest")]
    static void Open()
    {
        #region 生成多个窗口
        //var exampleWindow = CreateInstance<EditorWindowTest>();
        #endregion

        #region 唯一化窗口
        if (exampleWindow == null)
        {
            exampleWindow = CreateInstance<EditorWindowTest>();
        }
        #endregion

        //exampleWindow.Show();

        #region GetWindow
        //GetWindow<EditorWindowTest>();
        #endregion

        #region 添加EditorWindow到DockArea
        //GetWindow<EditorWindowTest>(typeof(SceneView));
        #endregion

        #region ShowUtility 浮动工具窗口，永远在普通窗口的最前面
        //exampleWindow.ShowUtility();
        #endregion

        #region ShowPopup 没有按钮关闭窗口标题窗口
        // 使用 SpriteEditor如切片菜单按钮以显示从弹出
        //exampleWindow.ShowPopup();
        #endregion

        #region PopupWindow 弹出窗口
        //exampleWindow.Show();
        #endregion

        #region ShowAuxWindow 不能作为标签的窗口，外观上和ShowUtility接近
        //exampleWindow.ShowAuxWindow();
        #endregion

        #region ShowAsDropDown 类似下滑栏的效果
        var buttonRect = new Rect(100, 100, 300, 100);
        var windowSize = new Vector2(300, 300);
        exampleWindow.ShowAsDropDown(buttonRect, windowSize);
        #endregion


    }

    void OnGUI()
    {
        #region ShowPopup 没有按钮关闭窗口标题窗口
        if (Event.current.keyCode == KeyCode.Escape)
        {
            exampleWindow.Close();
        }
        #endregion

        #region PopupWindow

        //if (GUILayout.Button("PopupContent", GUILayout.Width(128)))
        //{
        //    var activatorRect = GUILayoutUtility.GetLastRect();
        //    PopupWindow.Show(activatorRect, popupContent);
        //}
        #endregion
    }
}
#region PopupWindow 弹出子窗口

public class ExamplePopupContent : PopupWindowContent
{
    public override void OnGUI(Rect rect)
    {
        EditorGUILayout.LabelField("Lebel");
    }

    public override void OnOpen()
    {
        Debug.Log("表示弹出");
    }

    public override void OnClose()
    {
        Debug.Log("关闭弹出");
    }

    public override Vector2 GetWindowSize()
    {
        return new Vector2(300, 100);
    }
}

#endregion
