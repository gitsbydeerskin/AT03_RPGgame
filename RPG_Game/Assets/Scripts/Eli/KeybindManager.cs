using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class KeybindManager : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public void SetUpLoadedKey(string[] key, string[] value)
    {
        keys.Clear();

        for (int i = 0; i < key.Length; i++)
        {
            keyCode parsedKey = (KeyCode)Enum.Parse(typeof(KeyCode), value[i]);
            keys.Add(key[i], parsedKey);
        }
    }



    // Update is called once per frame
    public string[] SendKey()
    {
        string[] tempKey = new string[keys.Count];

        int i = 0;
        foreach (keyValuePair<string, keyCode> key in keys)
        {
            tempKey[i] = key.key;
            i++;
        }
        return tempKey;
    }


    public string[] SendValue()
    {
        string[] tempValue = new string[keys.count];

        int i = 0;
        foreach (keyValuePair<string, keyCode> key in keys)
        {
            tempValue[i] = key.Value.ToString();

            i++;
        }
        return tempValue;
    }
}
