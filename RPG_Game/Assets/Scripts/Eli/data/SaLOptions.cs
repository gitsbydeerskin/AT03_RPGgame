using System.IO;
using UnityEngine;

public class SaLOptions : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/OptionsData.json";
    public OptionData optionsData = new OptionData();

    [Header("Options Scripts")]

    [SerializeField] VolumeManager _audioManager;
    [SerializeField] QualityManager _qualityManager;
    [SerializeField] KeybindManager _keybindManager;

    private void Awake()
    {
        if (File.Exists(_filePath))
        {
            LoadOptions();
        }
    }

    void GetDataToSave()
    {
        //optionsData.isMouseInverted = MouseSettings.IsInverted;
        optionsData.keyNames = _keybindManager.SendKey();
        optionsData.keyValues = _keybindManager.SendValue();
        optionsData.qualityLevel = _qualityManager.CurrentQualityIndex;
        optionsData.Volume = _audioManager.VolumeControl;
    }

    void SaveJSON(OptionData data, string path)
    {
        string lineToSave = JsonUtility.ToJson(data);
        File.WriteAllText(path, lineToSave);
    }

    public void SaveOptions()
    {
        GetDataToSave();
        SaveJSON(optionsData, _filePath);
    }

    OptionData LoadData()
    {
        string loadedData = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<OptionData>(loadedData);
    }

    void SendDataFromLoad()
    {
        //MouseSettings.IsInverted = optionsData.isMouseInverted;
        _keybindManager.SetUpLoadedKey(optionsData.keyNames, optionsData.keyValues);
        _qualityManager.CurrentQualityIndex = optionsData.qualityLevel;
        _audioManager.VolumeControl = optionsData.Volume;
    }
    public void LoadOptions()
    {
        optionsData = LoadData();
        SendDataFromLoad();
    }
}