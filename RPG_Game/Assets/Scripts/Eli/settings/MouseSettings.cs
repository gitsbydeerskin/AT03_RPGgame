using UnityEngine;
using UnityEngine.UI;

public class MouseSettings : MonoBehaviour
{
    private static bool isInverted;
    [SerializeField] Toggle _invertedMouseToggle;


    public static bool IsInveted
    {
        set
        {
            isInverted = value;
        }

        get
        {
            return isInverted;
        }
    }

    public void SetMouseInvertState(bool toggleValue)
    {
        IsInveted = toggleValue;
    }

    public void Start()
    {
        _invertedMouseToggle.isOn = isInverted;
    }

}
