using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerStats
{
    [Header("Character Name")]
    public string name;
    [Header("Character Attributes")]
    public Attribute health;
    public Attribute stamina;
    [Header("Character Level")]
    public int level;
    public Attribute experience;
    [Header("Character Stats")]
    public List<Stat> stats = new List<Stat>
    {
    new Stat { name = "STR", statValue = 12, value = 0 },
    new Stat { name = "DEX", statValue = 14, value = 0 },
    new Stat { name = "CON", statValue = 13, value = 0 },
    new Stat { name = "INT", statValue = 10, value = 0 },
    new Stat { name = "WIS", statValue = 11, value = 0 },
    new Stat { name = "CHA", statValue = 8, value = 0 },
    };
}

[Serializable]
public struct Attribute
{
    public float currentValue;
    public float maxValue;
    public float value;
}

[Serializable]
public struct Stat
{
    public string name;
    public int statValue;
    public int value; 
}

