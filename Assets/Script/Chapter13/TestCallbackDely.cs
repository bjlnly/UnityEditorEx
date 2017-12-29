using UnityEngine;
using System.Collections;

#region EditorApplication.delayCall
// 可以做一些违反函数执行顺序的操作
public class TestCallbackDely : MonoBehaviour {
    void Start()
    {
        //MessageBox.Show("你显示的信息", "标题", MessageBoxButtons.类型, MessageIcon.类型);
        string memoryc = "12313";
        memoryc.showAsToast();
    }
    public GameObject go;

#if UNITY_EDITOR
    void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += () => {
            DestroyImmediate(go);
            go = null;
        };
    }
#endif
}

#endregion

