using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerStats
    // These are the playerstats. Not all are used. Most are just placeholders. 
{
    [Header("Character Name")]
    public string name;
    [Header("Character Attributes")]
    public Attribute health;
    public Attribute stamina;
    [Header("Character Level")]
    public int level;
    public Attribute experience;
    // The 3 Attributes (excl. Level) are used by the Player in the game every second. Stamina is used for Sprinting. Health is used for surviving Damage.
    // Level is being tied INTO the other two Attributes and the Stats below.
    // Stats are different than Attributes.
    // Stats are more like 'Skills' - they effect the 3 base Attributes and other gameplay mechanics in unique ways. Like impacting movement speed and jump height, etc. Or how nice a character speaks to you. 

    [Header("Character Stats")]
    public List<Stat> stats = new List<Stat>
    {
        // Rather than typing out the full words, I opted for using the first 3 letters of each skill.
        // strength is STR. Intelligence is INT. Charisma is CHA. Etc. 
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
    // This is the Struct for the ATTRIBUTES
    // Health, Stamina, and Level
{
    public float currentValue;
    public float maxValue;
    public float value;
}

[Serializable]
public struct Stat
    // This is the Struct for the STATS
    // STR, Dex, etc. 
{
    public string name;
    public int statValue;
    public int value; 
}

