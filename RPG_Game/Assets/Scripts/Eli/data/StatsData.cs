using UnityEngine;// Required for using Unity-specific types and functions.
using System;// Required to make custom data types savable and visible in the Inspector with [Serializable].


[Serializable]
public class StatsData
{
    [Header("Character Name")]
    public string name;

    [Header("Character Attributes")]
    public Attribute health;
    public Attribute stamina;

    [Header("Character Level")]
    public int level;
    public Attribute experience;
}