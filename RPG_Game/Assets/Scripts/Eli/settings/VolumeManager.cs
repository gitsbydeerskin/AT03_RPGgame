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
        set //sets the percentage of the volume for each audio mixer
        {
            _Volume = value; //an arrey of values that is assigned to the private _volume array 
        }
        get //gets the current percentage of the volume for each audio mixer
        {
            return _Volume; //returns the _valume array for each audio mixer
        }
    }

    private void Start() //On start the volume percentage for each channel will update with UI and starts 
    {
        for (int i = 0; i < _slider.Length; i++) //On start the volume percentage for each channel will update with UI and starts 
        {
            _slider[i].value = VolumeControl[i]; //sets the volume sliders to the saved volume percentage

            audioMixer.SetFloat(_channelName[i], VolumeControl[i]); //updates the audio mixer based on the Volume
        }
    }

    public void ChangeVolume(int volumeID) //Called when the player edits the volume with the volume slider
    {
        VolumeControl[volumeID] = _slider[volumeID].value; //Updates the volume percentage based on the sliders
        audioMixer.SetFloat(_channelName[volumeID], _Volume[volumeID]); //sets the audio mixer matching the slider to the new volume
    }
}
