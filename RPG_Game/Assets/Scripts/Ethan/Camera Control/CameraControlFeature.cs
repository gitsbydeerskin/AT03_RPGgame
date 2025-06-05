using UnityEngine;
using UnityEngine.Profiling;

public class CameraControlFeature : MonoBehaviour
{
    //The variable for the sensitivity of camera movement, aka how fast the camera moves when you move the mouse around
    [Header("Sensitivity Settings")]
    public static float sensitivity = 15;
    
    [Header("Rotation Clamping")]
    //This clamps the vertical rotation so that you dont look up and down in a full 360 degree movement
    [SerializeField] Vector2 rotationClamp = new Vector2(-60,60);
    [Header("Camera Transition Settings")]
    //How fast the camera transitions into third person
    public float transitionSpeed = 5;
    //checks to see if the camera is transitioning from one perspective to another
    public bool isLerping;

    [Header("Zoom Settings")]
    //States the minimum distance a camera can zoom into(aka first person)
    [SerializeField] float minZoom = 0;
    //states the maximum distance the camera can zoom out of
    [SerializeField] float maxZoom = 5;
    // States the speed in which the zoom occurs, allowing to be able to set the perspective at something more comfortable instead of a static third person
    [SerializeField] float zoomSpeed = 2;
    //Keeps track of the current perspective and position of the camera
    private float currentZoom = 0;

    [Header("Camera Setup")]
    //This makes it so that we can attach the script to the player camera and manipulate its position
    public Transform playerCamera;
    //This makes it so that we can attach the script to the player to be able to manipulate the rotation of the camera
    public Transform player;
    //This makes it so that we can manipulate the position of the first person snap(aka where the camera goes for first person)
    public Transform firstPersonSnap;
    //This makes it so that we can manipulate the position of the third person snap(aka the max distance the camera goes from the player for third person)
    public Transform thirdPersonSnap;
    //This makes it so that we can manipulate the position of the parent for third person(aka the distance the camera can zoom back into)
    public Transform thirdPersonParent;
    //This stores the current rotation of the camera
    float tempRotation;
    //This stores the rotation that actually gets applied to the camera
    float verticalRotation;
    //This handles looking around using the camera
    void HandleMouseLook()
    {
        //This makes it so that the camera moves left and right when you move the mouse left and right
        player.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        //This makes it so that the camera moves up and down when you move the mouse up and down
        tempRotation += Input.GetAxis("Mouse Y") * sensitivity;
        //This clamps the vertical rotation based off the current cameras rotation
        tempRotation = Mathf.Clamp(tempRotation, rotationClamp.x, rotationClamp.y);
// Note MouseInvertManager is a script within James code, the name of the script containing the isinverted variable would be somewhere within Elijahs scripts
        
        //if(MouseInvertManager.IsInverted)
        //{
        //    verticalRotation = tempRotation;
        //}
        //else
        //{
              //This makes the rotation normal instead of inverted
              verticalRotation = -tempRotation;
        //}
        //This applies the vertical rotation in both first and third person perspective
        firstPersonSnap.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        thirdPersonParent.localEulerAngles = new Vector3(verticalRotation, 0, 0);
    }
    //This handles zooming in and out with the camera
    private void HandleZoom()
    {
        //This retrieves the input of the mouse scrollWheel to be able to manipulate the zooming
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        //Clamps the zoom distance, and adjusts zoom level based off of the input receive from the above variable
        currentZoom = Mathf.Clamp(currentZoom - scrollInput * zoomSpeed, minZoom, maxZoom);
        //This makes the target position for the first and third camera based on the current zoom level
        Vector3 targetPosition = Vector3.Lerp(firstPersonSnap.position, thirdPersonSnap.position, currentZoom / maxZoom);
        //This makes transition from moving to a still position more smooth
        playerCamera.position = Vector3.Lerp(playerCamera.position, targetPosition, Time.deltaTime * transitionSpeed);
        //This makes it so that the FOV(Field Of View) changes when you zoom out, and lower FOV when zoomed in
        playerCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(40, 80, currentZoom / maxZoom);
    }
    // Update is called once per frame
    void Update()
    {
        //This calls on the HandleMouseLook function every frame
        HandleMouseLook();
        //This calls on the HandleZoom function every frame
        HandleZoom();
    }
}
