using UnityEngine;
using System.Collections;
using System.Text;
using UnityEditor;

public class SerializedObjectUse : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        var hoge = GameObject.Find("HogeForSer").GetComponent<HogeForSer>();

        var serializedObject = new SerializedObject(hoge);
        var vector3Value = serializedObject.FindProperty("position").vector3Value;
        StringBuilder tempBuilder = new StringBuilder();
        Debug.Log(tempBuilder.Append("測試获取property：").Append(vector3Value));

        tempBuilder = new StringBuilder();
        var serializedFuga = serializedObject.FindProperty("fuga.bar").stringValue;
        Debug.Log(tempBuilder.Append("serializedFuga：").Append(serializedFuga));

        tempBuilder = new StringBuilder();
        var serializedName = serializedObject.FindProperty("names").GetArrayElementAtIndex(1).stringValue;
        Debug.Log(tempBuilder.Append("serializedName：").Append(serializedName));
    }
}
