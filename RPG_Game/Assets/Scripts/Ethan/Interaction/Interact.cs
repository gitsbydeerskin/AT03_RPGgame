using UnityEngine;
using UnityEngine.UI; //allows the script to manipulate UI elements

public class Interact : MonoBehaviour
{
    public Text toolTip;
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
            //Checks to see if 
            if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable displayToolTip))
            {
                toolTip.text = displayToolTip.ToolTip();
            }

            if (Input.GetKeyDown(KeybindManager.Keys["Interact"]))
            {
                if (hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable interact))
                {
                    interact.OnInteraction();
                }
            }
        }
        else
        {
            if (toolTip.text != "")
            {
                toolTip.text = "";
            }
        }
    }
}
