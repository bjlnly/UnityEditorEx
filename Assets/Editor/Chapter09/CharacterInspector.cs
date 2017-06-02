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
    //Character[] characters;
    SerializedProperty exampleProperty;
    void OnEnable()
    {
        //character = (Character) target;
        //hpProperty = serializedObject.FindProperty("hp");
        //characters = targets.Cast<Character>().ToArray();
        exampleProperty = serializedObject.FindProperty("PdExample");
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
        //    characters[0].hp = hp;
        //    EditorUtility.SetDirty(character);
        //}
        #endregion

        #region EditorGUI.showMixedValue 多个同时编辑
        //EditorGUI.BeginChangeCheck();
        //EditorGUI.showMixedValue = characters.Select(x => x.hp).Distinct().Count() > 1;
        //var hp = EditorGUILayout.IntSlider("Hp", characters[0].hp, 0, 100);
        //EditorGUI.showMixedValue = false;
        //if (EditorGUI.EndChangeCheck())
        //{
        //    Undo.RecordObjects(characters, "Change hp");

        //    foreach (var character in characters)
        //    {
        //        character.hp = hp;
        //    }
        //}
        #endregion

        #region PropertyDrawer
        serializedObject.Update();

        EditorGUILayout.PropertyField(exampleProperty);

        serializedObject.ApplyModifiedProperties();
        #endregion
    }


    public override bool HasPreviewGUI()
    {
        return true;
    }
}
