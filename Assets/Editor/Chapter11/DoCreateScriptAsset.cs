using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

public class DoCreateScriptAsset : EndNameEditAction {
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var text = File.ReadAllText(resourceFile);
        var className = Path.GetFileNameWithoutExtension(pathName);

        // 剔除半角空格
        className = className.Replace(" ", "");

        text = text.Replace("#SCRIPTNAME#", className);

        text += "//追加";

        UTF8Encoding ecoding = new UTF8Encoding(true,false);
        File.WriteAllText(pathName,text, ecoding);

        AssetDatabase.ImportAsset(pathName);

        var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
        ProjectWindowUtil.ShowCreatedAsset(asset);
    }
    [MenuItem("Assets/Create C#Assets")]
    static void CreateExampleAssets()
    {
        var resourceFile = Path.Combine(EditorApplication.applicationContentsPath,
            "Resources/ScriptTemplates/81-C# Script-NewBehaviourScript.cs.txt");

        Texture2D csIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        var endNameEditAction = ScriptableObject.CreateInstance<DoCreateScriptAsset>();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,endNameEditAction,"NewBehaviourScript.cs", csIcon, resourceFile);
    }
}
