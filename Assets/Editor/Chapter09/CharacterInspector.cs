using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;

#region CanEditMultipleObjects 多个组件的同时编辑
[CanEditMultipleObjects]
#endregion
[CustomEditor(typeof(Character))]
public class CharacterInspector : Editor
{
    //private Character character = null;
    //private SerializedProperty hpProperty;
    Character[] characters;
    void OnEnable()
    {
        //character = (Character) target;
        //hpProperty = serializedObject.FindProperty("hp");
        characters = targets.Cast<Character>().ToArray();
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        #region 显示property
        //EditorGUILayout.LabelField("攻击力", character.攻击力.ToString());
        #endregion

        #region property设置
        //serializedObject.Update();
        //EditorGUILayout.IntSlider(hpProperty, 0, 100);
        //serializedObject.ApplyModifiedProperties();
        #endregion

        #region Undo.RecordObject EditorUtility.SetDirty
        //EditorGUI.BeginChangeCheck();
        //var hp = EditorGUILayout.IntSlider("hp", character.hp, 0, 100);
        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObject(character, "Change hp");
        //    character.hp = hp;
        //    EditorUtility.SetDirty(character);
        //}
        #endregion


    }
}
