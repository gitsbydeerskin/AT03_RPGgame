using UnityEngine;
using System;

[Serializable]
public class OptionData
{
    [Header("Audio")] //header for the audio settings for the Save and Load Script
    public float[] Volume; //an arry for each volume type (Master, Music, SFX)

    [Header("Quality")] //header for the Quality settings for the Save and Load Script
    public int qualityLevel; //an index for each quality level (low, Default, High)

    [Header("Controls")] //header for the Controls for the Save and Load Script 
    public string[] keyNames; //a string of each name of Keybinds 
    public string[] keyValues; // a string of each key for the keybinds 
    public bool isMouseInverted; //an switch to change whether the mouses Y-Axis is inverted.
}
