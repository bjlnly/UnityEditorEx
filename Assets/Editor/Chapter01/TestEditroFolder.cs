using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class TestEditroFolder : MonoBehaviour {
    void OnEnable()
    {
#if UNITY_EDITOR
        EditorWindow.GetWindow<ExampleWindow>();
#endif
    }

}
