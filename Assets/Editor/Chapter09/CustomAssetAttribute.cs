using System;
using UnityEngine;
using System.Collections;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CustomAssetAttribute : Attribute
{
    public string[] extensions;

    public CustomAssetAttribute(params string[] extensions)
    {
        this.extensions = extensions;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
