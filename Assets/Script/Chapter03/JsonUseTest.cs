using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

public class JsonUseTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        //Debug.Log(JsonUtility.ToJson(new JsonTest(), true));

        // List
        //var list = new List<JsonTest>
        //{
        //    new JsonTest(),
        //    new JsonTest()
        //};
        //   Debug.Log(JsonUtility.ToJson(list));

        //自定义list
        var serializedList = new SerializableList<JsonTest>
        {
            new JsonTest(),
            new JsonTest()
        };
        //Debug.Log(JsonUtility.ToJson(serializedList));
        //Debug.Log(serializedList.ToJson());
        var json = serializedList.ToJson();
        var serializableList = SerializableList<JsonTest>.FromJson(json);
        Debug.Log(serializableList.Count == 2);
    }

    // Update is called once per frame
    void Update () {
	
	}
}

public class SerializableList<T> : Collection<T>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<T> items;
    public void OnBeforeSerialize()
    {
        items = (List<T>)Items;
    }

    public void OnAfterDeserialize()
    {
        Clear();
        foreach (var item in items)
        {
            Add(item);
        }
    }
    public string ToJson()
    {
        var result = "[]";
        var json = JsonUtility.ToJson(this);
        var regex = new Regex("^{\"items\":(?<array>.*)}$");
        var match = regex.Match(json);
        if (match.Success)
            result = match.Groups["array"].Value;

        return result;
    }
    public static SerializableList<T> FromJson(string arrayString)
    {
        var json = "{\"items\":" + arrayString + "}";
        return JsonUtility.FromJson<SerializableList<T>>(json);
    }
}