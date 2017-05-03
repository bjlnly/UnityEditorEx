using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Serialization;
/// <summary>
/// inspector整理
/// </summary>
/// 

#region RequireComponent
[RequireComponent(typeof(Animator))]
#endregion
#region DisallowMultipleComponent
[DisallowMultipleComponent]
#endregion
#region AddComponentMenu
[AddComponentMenu("Myui/InspectorManage")]
#endregion
#region ExecuteInEditMode
[ExecuteInEditMode]
#endregion
#region SelectionBase
[SelectionBase]
#endregion
public class InspectorManage : MonoBehaviour {
    #region Header
    [Header("Player Settings")]
    public Player player;
    [Serializable]
    public class Player
    {
        public string name;
        [Range(1,100)]
        public int hp;
    }

    [Header("Game Settings")]
    public Color background;
    #endregion

    #region Space
    [Space(16)]
    public string str1;

    [Space(48)]
    public string str2;
    #endregion

    #region Tooltip
    [Tooltip("测试提示")]
    public long tooltip;
    #endregion

    #region HideInInspector
    public string str1h;
    [HideInInspector]
    public string str2h;
    #endregion

    #region FormerlySerializedAs
    //[FormerlySerializedAs("hoga")]
    public string foga;
    #endregion

    #region ExecuteInEditMode
    void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
            print("You clicked the button!");
    }
    #endregion

    #region ContextMenu
    public int number;
    [ContextMenu("RandomNumber")]
    void RandomRumber()
    {
        number = UnityEngine.Random.Range(0, 100);
    }
    [ContextMenu("ResetNumber")]
    private void ResetNumber()
    {
        number = 0;
    }
    #endregion
}
