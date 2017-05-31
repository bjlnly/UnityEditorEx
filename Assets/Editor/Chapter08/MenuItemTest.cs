using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuItemTest{
    #region 创建一个纯粹的自定义窗口
    //[MenuItem("CustomMenu/Example")]
    #endregion

    #region 添加一个子菜单到现有的菜单
    //[MenuItem("Assets/Example")]
    #endregion

    #region 修改显示顺序
    [MenuItem("Assets/Example", false, 1)]
    #endregion

    #region 快捷键
    //command(ctrl) + shift + g
    [MenuItem("CustomMenu/Example %#g")]
    #endregion
    static void Example()
    {
        #region 勾选子选项
        //var menuPath = "CustomMenu/Example";
        //var @checked = Menu.GetChecked(menuPath);
        //Menu.SetChecked(menuPath, !@checked);
        #endregion
    }

    #region 从子菜单另外创建一个菜单
    //[MenuItem("CustomMenu/Example/Child1")]
    //static void Example1()
    //{
    //}

    //[MenuItem("CustomMenu/Example/Child2")]
    //static void Example2()
    //{
    //}
    #endregion

    #region 创建不能被执行菜单项 
    // 返回值意味着是否可以执行
    //[MenuItem("CustomMenu/Example/Child2", true)]
    //static bool ValidateExample2()
    //{
    //    return false;
    //}
    #endregion

    #region 优先展示样式
    //[MenuItem("CustomMenu/Example1", false, 1)]
    //static void Example1()
    //{
    //}

    //[MenuItem("CustomMenu/Example2", false, 1)]
    //static void Example2()
    //{
    //}

    //[MenuItem("CustomMenu/Example3", false, 40)]
    //static void Example3()
    //{
    //}
    #endregion

    #region 组件的上下文菜单
    //[MenuItem("CONTEXT/Transform/Example1")]
    //static void Example1() { }

    //[MenuItem("CONTEXT/Component/Example2")]
    //static void Example2() { }

    //[MenuItem("CONTEXT/InspectorChange/Example3")]
    //static void Example3() { }
    #endregion

    #region MenuCommand 获取组件信息
    [MenuItem("CONTEXT/Transform/Example1")]
    static void Example1(MenuCommand menuCommand)
    {
        Debug.Log(menuCommand.context);
    }
    #endregion
}
