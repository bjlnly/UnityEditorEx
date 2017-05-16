using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class BaseEditorGUI : EditorWindow
{
    [MenuItem("Window/Example")]
    static void Open()
    {
        GetWindow<BaseEditorGUI>();
    }

    #region ChangeCheck
    private bool toggleValue;
    #endregion

    #region GUI.changed
    Stack<bool> stack = new Stack<bool>();
    #endregion

    #region FadeGroup 渐显效果
    AnimFloat animFloat = new AnimFloat(0.0001f);
    Texture tex;
    #endregion

    #region EditorGUI.MultiFloatField

    private float[] numbers = new float[]
    {
        0,
        1,
        2
    };

    GUIContent[] contents = new GUIContent[] {
        new GUIContent ("X"),
        new GUIContent ("Y"),
        new GUIContent ("Z")
    };
    #endregion

    #region EditorGUILayout.Knob
    private float angle = 0;
    #endregion

    #region 按钮风格切换
    private bool on;
    #endregion

    #region 多个按钮切换
    private bool one, two, three;
    #endregion

    #region GUILayout.Toolbar
    private int selected;
    #endregion
    void OnGUI()
    {
        #region Label
        EditorGUILayout.LabelField("Example Label");
        #endregion

        #region ChangeCheck 勾选框
        //EditorGUI.BeginChangeCheck();
        //toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        //if (EditorGUI.EndChangeCheck())
        //{
        //    if (toggleValue)
        //    {
        //        Debug.Log("toggleValue 变为true的同时打印");
        //    }
        //}
        #endregion

        #region GUI.changed 模拟changeCheck
        //// 模拟BeginChangeCheck
        //{
        //    stack.Push(GUI.changed);
        //    GUI.changed = false;
        //}

        //toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        //bool changed = GUI.changed;
        //// 模拟EndChangeCheck
        //{
        //    GUI.changed = stack.Pop();
        //}

        //if (changed)
        //{
        //    Debug.Log("toggleValue 变为true的同时打印");
        //}
        #endregion

        #region DisabledGroup 隐藏不可点
        //Display();
        //EditorGUILayout.Space();
        //EditorGUI.BeginDisabledGroup(true);
        //Display();
        //EditorGUI.EndDisabledGroup();
        #endregion

        #region GUI.enabled 模拟DisabledGroup
        //Display();
        //EditorGUILayout.Space();
        //GUI.enabled = false;
        //Display();
        //GUI.enabled = true;
        #endregion

        #region FadeGroup
        //bool on = animFloat.value == 1;

        //if (GUILayout.Button(on ? "Close" : "Open", GUILayout.Width(64)))
        //{
        //    animFloat.target = on ? 0.0001f : 1;
        //    animFloat.speed = 0.5f;

        //    var env = new UnityEvent();
        //    env.AddListener(() => Repaint());
        //    animFloat.valueChanged = env;
        //}
        //EditorGUILayout.BeginHorizontal();
        //EditorGUILayout.BeginFadeGroup(animFloat.value);
        //Display();
        //EditorGUILayout.EndFadeGroup();
        //Display();
        //EditorGUILayout.EndHorizontal();
        #endregion

        #region EditorGUI.ObjectField

        //EditorGUILayout.ObjectField(null, typeof(Object), true);
        //EditorGUILayout.ObjectField(null, typeof(Material), false);
        //EditorGUILayout.ObjectField(null, typeof(AudioClip), false);

        //var options = new[]
        //{
        //    GUILayout.Width(64), GUILayout.Height(64)
        //};
        //EditorGUILayout.ObjectField(null, typeof(Texture), false, options);
        //EditorGUILayout.ObjectField(null, typeof(Sprite), false, options);

        #endregion

        #region EditorGUI.MultiFloatField  一行显示多个float
        //EditorGUI.MultiFloatField(new Rect(30,30,200,EditorGUIUtility.singleLineHeight), 
        //                          new GUIContent("Label"), 
        //                          contents,
        //                          numbers);
        #endregion

        #region EditorGUI.IndentLevel 缩进
        //EditorGUILayout.LabelField("Parent");

        //EditorGUI.indentLevel++;
        //EditorGUILayout.LabelField("Child");
        //EditorGUILayout.LabelField("Child");

        //EditorGUI.indentLevel--;
        //EditorGUILayout.LabelField("Parent");

        //EditorGUI.indentLevel++;
        //EditorGUILayout.LabelField("Child");
        #endregion

        #region EditorGUILayout.Knob 旋转
        //angle = EditorGUILayout.Knob(Vector2.one * 64, angle, 0, 360, "度~", Color.gray, Color.red, true);
        #endregion

        #region Scope排列
        //HorizontalScope，VerticalScope，ScrollViewScope
        /*using (new BackgroundColorScope(Color.green))
        {
            GUILayout.Button("Button1");
            using (new BackgroundColorScope(Color.yellow))
            {
                GUILayout.Button("Button2");
            }
        }*/
        #endregion

        #region 按钮风格切换
        //on = GUILayout.Toggle(on, @on ? "on" : "off", "button");
        #endregion

        #region 多个按钮切换
        //using (new EditorGUILayout.HorizontalScope())
        //{
        //    one = GUILayout.Toggle(one, "1", EditorStyles.miniButtonLeft);
        //    two = GUILayout.Toggle(two, "2", EditorStyles.miniButtonMid);
        //    three = GUILayout.Toggle(three, "3", EditorStyles.miniButtonRight);
        //}
        #endregion

        #region GUILayout.Toolbar
        selected = GUILayout.Toolbar(selected, new string[] {"1", "2", "3"});
        #endregion

        #region EditorStyles.toolbarButton
        selected = GUILayout.Toolbar(selected, new string[] {"1", "2", "3"}, EditorStyles.toolbarButton);
        #endregion

        #region GUILayout.SelectionGrid
        selected = GUILayout.SelectionGrid(selected, new string[] {"1", "2", "3"}, 1, "PreferencesKeysElement");
        #endregion
    }

    void Display()
    {
        #region DisabledGroup GUI.enbaled
        //EditorGUILayout.ToggleLeft("Toggle", false);
        //EditorGUILayout.IntSlider(0, 10, 0);
        //GUILayout.Button("Button");
        #endregion

        #region FadeGroup

        //EditorGUILayout.BeginVertical();
        //EditorGUILayout.ToggleLeft("Toggle", false);
        //var options = new[] {GUILayout.Width(128), GUILayout.Height(128)};
        //tex = EditorGUILayout.ObjectField(tex, typeof(Texture), false, options) as Texture;
        //GUILayout.Button("Button");
        //EditorGUILayout.EndVertical();

        #endregion
    }
}
#region BackgroundColorScope 自制范围

public class HorizontalScope : GUI.Scope
{
    public HorizontalScope()
    {
        EditorGUILayout.BeginHorizontal();
    }

    protected override void CloseScope()
    {
        EditorGUILayout.EndHorizontal();
    }
}

public class BackgroundColorScope : GUI.Scope
{
    private readonly Color color;

    public BackgroundColorScope(Color color)
    {
        this.color = GUI.backgroundColor;
        GUI.backgroundColor = color;
    }
    protected override void CloseScope()
    {
        GUI.backgroundColor = color;
    }
}
#endregion
