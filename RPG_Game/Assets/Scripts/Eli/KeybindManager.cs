using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class KeybindManager : MonoBehaviour
{


    [Serializable]
    public struct ActionMapData
    {
        public string actionName;
        public Text keycodeDisplay;

        public string defaultKey;

    }

    [Header("Action Mapping")]
    [SerializeField] ActionMapData[] _actionMapData;
    [Header("UI Feedback")]
    [SerializeField] GameObject _currentSelectedKey;

    public static Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();


    [SerializeField] private Color32 _selectedKey = new Color32(239, 116, 36, 225);
    [SerializeField] private Color32 _changedKey = new Color32(39, 171, 249, 225);



    public void SetUpLoadedKey(string[] key, string[] value)
    {
        Keys.Clear();


        for (int i = 0; i < key.Length; i++)
        {
            // keys.Add(key[i], (KeyCode)Enum.Parse(typeof(KeyCode), value[i])));

            Keys.Add(key[i], (KeyCode)Enum.Parse(typeof(KeyCode), value[i]));

        }
    }


    // Update is called once per frame
    public string[] SendKey()
    {

        string[] tempKey = new string[Keys.Count];

        int i = 0;
        foreach (KeyValuePair<string, KeyCode> key in Keys)

        {
            tempKey[i] = key.Key;
            i++;
        }
        return tempKey;
    }


    public string[] SendValue()
    {

        string[] tempValue = new string[Keys.Count];

        int i = 0;
        foreach (KeyValuePair<string, KeyCode> key in Keys)
        {
            tempValue[i] = Keys.Values.ToString();

            i++;
        }
        return tempValue;
    }

    private void Start()
    {
        for (int i = 0; i < _actionMapData.Length; i++)
        {

            if (!Keys.ContainsKey(_actionMapData[i].actionName))
            {
                Keys.Add(_actionMapData[i].actionName, (KeyCode)Enum.Parse(typeof(KeyCode), _actionMapData[i].defaultKey));
            }

            _actionMapData[i].keycodeDisplay.text = Keys[_actionMapData[i].actionName].ToString();
        }

    }

    public void ChangeKey(GameObject clickedKey)
    {
        _currentSelectedKey = clickedKey;

        if (_currentSelectedKey != null)
        {
            _currentSelectedKey.GetComponent<Image>().color = _selectedKey;
        }

    }

    private void OnGUI()
    {
        Event changeKeyEvent = Event.current;

        if (_currentSelectedKey != null && changeKeyEvent.isKey)
        {
            Keys[_currentSelectedKey.name] = changeKeyEvent.keyCode;

            _currentSelectedKey.GetComponentInChildren<Text>().text = changeKeyEvent.keyCode.ToString();
            _currentSelectedKey.GetComponent<Image>().color = _changedKey;
            _currentSelectedKey = null;

        }
    }
}