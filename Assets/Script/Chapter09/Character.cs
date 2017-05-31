﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [Range(0,255)]
    public int 基本攻击力;
    [Range(0,99)]
    public int 武器攻击力;
    [Range(0,99)]
    public int 角色力量;

    public int hp;
    public PropertyDrawerExample PdExample;
    public int 攻击力
    {
        get { return 基本攻击力 + Mathf.FloorToInt(基本攻击力 * (武器攻击力 + 角色力量 - 8) / 16); }
    }
}