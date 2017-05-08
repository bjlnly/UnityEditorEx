using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Fuga
{
    [SerializeField] private string bar;
}
public class HogeForSer : MonoBehaviour
{

    [SerializeField] Vector3 position;

    [SerializeField] Fuga fuga;

    [SerializeField] string[] names;

}
