using System.IO;
using UnityEngine;

public class SaLOptions : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/OptionsData.json"; //The Path and name of the .JSON file which will Save the data
    public OptionData optionsData = new OptionData(); 

    [Header("Options Scripts")]

    [SerializeField] VolumeManager _audioManager; //The Code/script for the Volume Manager
    [SerializeField] QualityManager _qualityManager; //The Code/script for the Quality Manager
    [SerializeField] KeybindManager _keybindManager; //The Code/script for the KeyBind Manager

    private void Awake()
    {
        if (File.Exists(_filePath)) //If the code finds "OptionsData.json" it will will run LoadOptions
        {
            LoadOptions(); 
        }
    }

    void GetDataToSave() //List of data it will save to the Json file
    {
        //optionsData.isMouseInverted = MouseSettings.IsInverted; //Not setup in the movement script or another script and causing issues when enabled so temporarily disabled
        optionsData.keyNames = _keybindManager.SendKey(); //using the KeybindManager.cs script to gather each Keybind name
        optionsData.keyValues = _keybindManager.SendValue(); //using the KeybindManager.cs script to gather each Keybind Value/Key
        optionsData.qualityLevel = _qualityManager.CurrentQualityIndex; //using the QualityManager.cs script to gather the quality level (Low, default, high) 
        optionsData.Volume = _audioManager.VolumeControl; //using the VolumeManager.cs script to gather the persentage of each audio setting (Master, Music, SFX) 
    }

    void SaveJSON(OptionData data, string path) //formats OptionData into a Json string and saves it to the file path location
    {
        string lineToSave = JsonUtility.ToJson(data); //convers the data into a Json string
        File.WriteAllText(path, lineToSave); //writes to the file
    }

    public void SaveOptions() //Called to save settings data to the files
    {
        GetDataToSave(); //Gathers the new Game Settings
        SaveJSON(optionsData, _filePath); //Saves the .Json to the file path 
    }

    OptionData LoadData() //load Saved data from the Json file 
    {
        string loadedData = File.ReadAllText(_filePath); //reads the Saved data from the Json file 
        return JsonUtility.FromJson<OptionData>(loadedData); //Converted the Saved data into the object data
    }

    void SendDataFromLoad() //sends the loaded saved data to the correct manager script
    {
        //MouseSettings.IsInverted = optionsData.isMouseInverted; //Not setup in the movement script or another script and causing issues when enabled so temporarily disabled
        _keybindManager.SetUpLoadedKey(optionsData.keyNames, optionsData.keyValues); //Loads all Saved Keybinds settings including there names and the keys connected
        _qualityManager.CurrentQualityIndex = optionsData.qualityLevel; //loads the selected resolution from the dropdown index 
        _audioManager.VolumeControl = optionsData.Volume; //loads each volume Persentage from the arry (Master, Music, SFX)
    }
    public void LoadOptions() //loads and applys Saved settings options from the .Jsom file
    {
        optionsData = LoadData(); //loads from the file path
        SendDataFromLoad(); //applys the saved data to the game
    }
}