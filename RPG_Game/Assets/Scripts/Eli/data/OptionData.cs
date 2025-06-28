using UnityEngine;
using System;

[Serializable]
public class OptionData
{
    [Header("Audio")]
    public float[] Volume;

    [Header("Quality")]
    public int qualityLevel;

    [Header("Controls")]
    public string[] keyNames;
    public string[] keyValues;
    public bool isMouseInverted;
}
