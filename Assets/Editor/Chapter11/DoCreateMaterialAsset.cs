﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

public class DoCreateMaterialAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var mat = (Material)EditorUtility.InstanceIDToObject(instanceId);

        mat.color = Color.red;

        AssetDatabase.CreateAsset(mat, pathName);
        AssetDatabase.ImportAsset(pathName);
        ProjectWindowUtil.ShowCreatedAsset(mat);
    }

    [MenuItem("Assets/Create ExampleMaterailAssets")]
    static void CreateExampleMaterialAssets()
    {
        var material = new Material(Shader.Find("Standard"));
        var instanceID = material.GetInstanceID();

        var icon = AssetPreview.GetMiniThumbnail(material);

        var endNameEditAction = ScriptableObject.CreateInstance<DoCreateMaterialAsset>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(instanceID, endNameEditAction, "New Material.mat",icon, "");
    }

}
