using System;
using UnityEngine;
using System.Collections;

public class Hoge : MonoBehaviour
{
    [SerializeField, Range2(0, 10)]
    private int hp;
    [SerializeField, Range2(0, 10)]
    int hpRange;
    [SerializeField, Range2(0, 10)]
    float str;
}