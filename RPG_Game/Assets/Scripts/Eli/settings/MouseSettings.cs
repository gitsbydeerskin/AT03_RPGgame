using UnityEngine;
using UnityEngine.UI;

public class MouseSettings : MonoBehaviour
{
    private static bool isInverted; //varianle to store the state of the mouse
    [SerializeField] Toggle _invertedMouseToggle; //serialized field to reference the UI toggle for the inverted mouse


    public static bool IsInverted //variable for enabeling or disabeling the mouse inverted 
    {
        set //sets the inverted stat
        {
            isInverted = value; //the values are assigned to the _isInverted
        }

        get //gets the inverted stat
        {
            return isInverted; //returns the _isInverted value
        }
    }

    public void SetMouseInvertState(bool toggleValue) //sets the State of the mouse inverted toggle
    {
        IsInverted = toggleValue; //assign the toggle value to the IsInverted static
    }

    public void Start() //runs when the program or unity egain runs.
    {
        _invertedMouseToggle.isOn = isInverted; //updates the toggle UI to the current mouse inverted state
    }

}
