using UnityEngine;
using System.Collections;
using UnityEditor;

public class ExampleUndo
{
    [MenuItem("Example/Create Cube")]
    static void CreateCube()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Undo.RegisterCreatedObjectUndo(cube, "Create Cube");
    }


    [MenuItem("Example/Random Rotate")]
    static void RandomRotate()
    {
        var transform = Selection.activeTransform;
        if (transform)
        {
            //Undo.RecordObject(transform,"Rotate " + transform.name);
            //Undo.RegisterCompleteObjectUndo(transform, "Rotate " + transform.name);
            transform.rotation = Random.rotation;
        }
    }
}
