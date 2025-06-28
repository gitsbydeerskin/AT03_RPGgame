using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;
    [Header("Volume Control Sliders")]
    [SerializeField] Slider[] _slider = new Slider[3];
<<<<<<< Updated upstream:RPG_Game/Assets/Scripts/Eli/VolumeManager.cs
    [SerializeField] Text[] _percentText = new Text[3];
=======
>>>>>>> Stashed changes:RPG_Game/Assets/Scripts/Eli/settings/VolumeManager.cs
    [SerializeField] float[] _Volume = new float[3];
    [SerializeField] string[] _channelName = new string[3];


    public float[] VolumeControl
    {
        set
        {
            _Volume = value;
        }
        get
        {
            return _Volume;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _slider.Length; i++)
        {
            _slider[i].value = VolumeControl[i];

            audioMixer.SetFloat(_channelName[i], VolumeControl[i]);
<<<<<<< Updated upstream:RPG_Game/Assets/Scripts/Eli/VolumeManager.cs

            _percentText[i].text = $"{Mathf.Clamp01((VolumeControl[i] + 80) / 100):P0}";
=======
>>>>>>> Stashed changes:RPG_Game/Assets/Scripts/Eli/settings/VolumeManager.cs
        }
    }

    public void ChangeVolume(int volumeID)
    {
        VolumeControl[volumeID] = _slider[volumeID].value;
        audioMixer.SetFloat(_channelName[volumeID], _Volume[volumeID]);
<<<<<<< Updated upstream:RPG_Game/Assets/Scripts/Eli/VolumeManager.cs
        _percentText[volumeID].text = $"{Mathf.Clamp01((VolumeControl[volumeID] + 80) / 100):P0}";
=======
>>>>>>> Stashed changes:RPG_Game/Assets/Scripts/Eli/settings/VolumeManager.cs
    }
}
