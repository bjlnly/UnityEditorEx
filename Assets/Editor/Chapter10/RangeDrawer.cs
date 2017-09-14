﻿using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomPropertyDrawer(typeof(Range2Attribute))]
public class RangeDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Range2Attribute range2 = (Range2Attribute)attribute;

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.IntSlider(position, property, range2.min, range2.max, label);
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
