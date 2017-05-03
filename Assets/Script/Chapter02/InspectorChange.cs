using UnityEngine;
using System.Collections;

// inspector基础
public class InspectorChange : MonoBehaviour
{
    #region Range
    [Range(0,10)]
    public int num1;

    [Range(0, 10)]
    public float num2;

    [Range(0, 10)]
    public long num3;

    [Range(0, 10)]
    public double num4;
    #endregion

    #region 多行文本
    [Multiline(5)] public string multiline;
    [TextArea(3, 5)] public string textArea;
    #endregion

    #region Item右键
    [ContextMenuItem("Random", "RandomNumber")]
    [ContextMenuItem("Reset", "ResetNumber")]
    public int number;

    void RandomNumber()
    {
        number = Random.Range(0, 100);
    }

    void ResetNumber()
    {
        number = 0;
    }
    #endregion

    #region ColorUsage

    public Color color1;
    [ColorUsage(false)]
    public Color color2;
    [ColorUsage(true, true, 0, 8, 0.125f, 3)]
    public Color color3;

    #endregion
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
