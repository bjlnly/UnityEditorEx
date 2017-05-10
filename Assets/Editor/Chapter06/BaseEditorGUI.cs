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