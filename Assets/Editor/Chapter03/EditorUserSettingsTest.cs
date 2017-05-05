using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
//Library/EditorUserSettings.asset
public class EditorUserSettingsTest {

    static void SaveConfig()
    {
        EditorUserSettings.SetConfigValue("Data 1", "text");
    }
    //[InitializeOnLoadMethod]
    static void GetConfig()
    {
        string config = EditorUserSettings.GetConfigValue("Data 1");
        StringBuilder sb = new StringBuilder();
        Debug.Log(sb.Append("config========").Append(config));
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
