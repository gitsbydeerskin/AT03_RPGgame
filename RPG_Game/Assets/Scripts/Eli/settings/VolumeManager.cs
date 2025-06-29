using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{

    [Header("Audio Mixer")]
    public AudioMixer audioMixer; //connects to the AudioMixer
    [Header("Volume Control Sliders")]
    [SerializeField] Slider[] _slider = new Slider[3]; //the order of the sliders (attached) 
    [SerializeField] float[] _Volume = new float[3]; //the default Volume of each audio mixer
    [SerializeField] string[] _channelName = new string[3]; //the channel name of each audio mixer 


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
        }
    }

    public void ChangeVolume(int volumeID)
    {
        VolumeControl[volumeID] = _slider[volumeID].value;
        audioMixer.SetFloat(_channelName[volumeID], _Volume[volumeID]);
    }
}
