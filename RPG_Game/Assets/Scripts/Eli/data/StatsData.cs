using UnityEngine;
using System;


[Serializable]
public class StatsData
{
    [Header("Character Name")] //header for the Charaters Name for the Save and Load Script
    public string name; //a string/text for the players name  

    [Header("Character Attributes")] //header for the attributes for the Save and Load Script
    public Attribute health; //an index for the charaters/Players health 
    public Attribute stamina; //an index for the charaters/Players Stamina

    [Header("Character Level")] //header for the level for the Save and Load Script
    public int level; //an index for the charaters/Players level
    public Attribute experience; //an index for the charaters/Players XP
}