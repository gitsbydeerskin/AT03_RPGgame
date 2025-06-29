using UnityEngine;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour
{
    [SerializeField] Dropdown _qualityDropdown; //Reference to the UI dropdown object that allows the player to select the quality

    int _CurrentQualityIndex = 0; //tracks the current quality index

    public int CurrentQualityIndex //sets or gets the index of the current quality in the dropdown
    {
        set { _CurrentQualityIndex = value; }
        get { return _CurrentQualityIndex; }
    }

    public void ChangeQuality(int qualityIndex) //updates the game quality based of the index provided
    {
        CurrentQualityIndex = qualityIndex; //Update the quality index with the new value when the player changes it 
        QualitySettings.SetQualityLevel(CurrentQualityIndex); //Sets the new quality in the game using the index in the quality settings
    }

    private void Start() //runs on the first frame update 
    {
        _qualityDropdown.value = CurrentQualityIndex; //Sets the dropdown value to the current quality settings
        QualitySettings.SetQualityLevel(CurrentQualityIndex); //sets the quality to the current setting when the game stats 
    }
}
