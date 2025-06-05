using UnityEngine;
using UnityEngine.Profiling;

public class CameraControlFeature : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    public static float sensitivity = 15;

    [Header("Rotation Clamping")]
    [SerializeField] Vector2 rotationClamp = new Vector2(-60,60);
    [Header("Camera Transition Settings")]
    public float transitionSpeed = 5;
    public bool isLerping;

    [Header("Zoom Settings")]
    [SerializeField] float minZoom = 0;
    [SerializeField] float maxZoom = 5;
    [SerializeField] float zoomSpeed = 2;
    private float currentZoom = 0;

    [Header("Camera Setup")]
    public Transform playerCamera;
    public Transform player;
    public Transform firstPersonSnap;
    public Transform thirdPersonSnap;
    public Transform thirdPersonParent;

    float tempRotation;
    float verticalRotation;

    void HandleMouseLook()
    {
        player.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        tempRotation += Input.GetAxis("Mouse Y") * sensitivity;
        tempRotation = Mathf.Clamp(tempRotation, rotationClamp.x, rotationClamp.y);
// Note MouseInvertManager is a script within James code, the name of the script containing the isinverted variable would be somewhere within Elijahs scripts
        //if(MouseInvertManager.IsInverted)
        //{
        //    verticalRotation = tempRotation;
        //}
        //else
        //{
              verticalRotation = -tempRotation;
        //}
        firstPersonSnap.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        thirdPersonParent.localEulerAngles = new Vector3(verticalRotation, 0, 0);
    }
    private void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoom = Mathf.Clamp(currentZoom - scrollInput * zoomSpeed, minZoom, maxZoom);
        Vector3 targetPosition = Vector3.Lerp(firstPersonSnap.position, thirdPersonSnap.position, currentZoom / maxZoom);
        playerCamera.position = Vector3.Lerp(playerCamera.position, targetPosition, Time.deltaTime * transitionSpeed);
        playerCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(40, 80, currentZoom / maxZoom);
    }
    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();
        HandleZoom();
    }
}
