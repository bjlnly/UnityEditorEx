using UnityEngine;
using System.Collections;
// 大量 共享
[CreateAssetMenu]
public class ScriptableObjectTest : ScriptableObject {
    [Range(0,10)]
    public int number = 3;

    public bool toggle = false;

    public string[] texts = new string[5];
}
