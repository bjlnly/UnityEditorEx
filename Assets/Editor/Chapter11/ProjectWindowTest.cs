using UnityEngine;
using UnityEditor;

public class ProjectWindowTest{
    [MenuItem("Assets/Create ExampleAssets")]
    static void CreateExampleAssets()
    {
        var material = new Material(Shader.Find("Standard"));
        ProjectWindowUtil.CreateAsset(material, "New Material.mat");
    }
}
