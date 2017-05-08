using UnityEngine;
using System.Collections;

public class SerializeFiledTest : MonoBehaviour {

    #region SerializeField
    [SerializeField]
    private string m_strtest;
    public string str
    {
        get { return m_strtest; }
        set { m_strtest = value; }
    }
    #endregion
}
