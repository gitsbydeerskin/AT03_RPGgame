using UnityEngine;
using UnityEngine.UI;

// This script allows select player stats to update the UI in real-time 
public class UIManager : MonoBehaviour
{
    public Image healthBar;
    public Image staminaBar;
    public Image experienceBar;

    public void UpdateUI(Image displayImage, float currentValue, float maxValue)
    { 
        displayImage.fillAmount = Mathf.Clamp01(currentValue / maxValue);
    }
}
