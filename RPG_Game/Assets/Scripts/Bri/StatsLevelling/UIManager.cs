using UnityEngine;
using UnityEngine.UI;

// This script allows select player stats to update the UI in real-time 
public class UIManager : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;
    public Image experienceBar;
    // These are the 3 main UI elements that will update in real-time based on Player input. 
    // They will be called to and manipulated by PlayerHandler.cs

    public void UpdateUI(Image displayImage, float currentValue, float maxValue)
    { 
        displayImage.fillAmount = Mathf.Clamp01(currentValue / maxValue);
        // This clamps the three UI bars between the Player's current value - ie, if they sprint and drain some Stamina, that would be their current value - and their MAX value. 
        // This way the UI bars will not 'spill over' or show more just because we're actually using maths to for the Player's stats. 
    }
}
