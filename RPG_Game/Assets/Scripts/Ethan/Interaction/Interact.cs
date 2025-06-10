using UnityEngine;
using UnityEngine.UI; //allows the script to manipulate UI elements

public class Interact : MonoBehaviour
{
    #region Variables
    public Text toolTip;
    #endregion
    #region Unity Callback
    // Update is called once per frame
    void Update()
    {
        Ray interactionRay; //this creates a ray, which is a line that interacts with colliders
        //This shoots the ray forward from the centre of the camera
        interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        //holds information for the stuff in which the player interacts with
        RaycastHit hitInfo;
        //checks to see if the interaction ray hit an object within player distance
        if (Physics.Raycast(interactionRay, out hitInfo, 10))
        {
            //Checks to see if the ray comes into contact with an object within player distance or layer
            if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable displayToolTip))
            {
                toolTip.text = displayToolTip.ToolTip();
            }
            //checks to see if the interaction button was pressed
            if (Input.GetKeyDown(KeybindManager.Keys["Interact"]))
            {
                //checks to see if the interact script is attached to the object 
                if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interact))
                {
                    //runs the OnInteraction function 
                    interact.OnInteraction();
                }
            }
        }
        else
        {
            //if the raycast did not hit an object within player distance, then it does not display any text
            if (toolTip.text != "")
            {
                toolTip.text = "";
            }
        }
    }
    #endregion
}