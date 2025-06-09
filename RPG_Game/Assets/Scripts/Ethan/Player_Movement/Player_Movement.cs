using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Variables
    [SerializeField] Vector3 _moveDirection;

    [SerializeField] CharacterController _characterController;

    [SerializeField] float _movementSpeed, _walk = 5, _run = 10, _crouch = 2.5f, _jump = 8, _gravity = 20;

    Vector2 newInput;

    PlayerHandler playerHandler;

    [SerializeField] UIManager uiManager;

    bool isMoving;

    bool canRegen;

    float regenTimer;
    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _characterController = GetComponent<_characterController>();

        playerHandler = GetComponent<playerHandler>();

        uiManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<uiManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Timer();

        RegenOverTime();

        SpeedControls();

        Move();
    }
    #endregion

    #region Functions

    void RegenOverTime()
    {
        if (canRegen)
        {
            if (playerHandler.playerData.stamina.currentValue < playerHandler.playerData.stamina.maxValue)
            {
                playerHandler.playerData.stamina.currentValue += playerHandler.playerData.stamina.value * Time.deltaTime;

                uiManager.UpdateUI(
                    uiManager.staminaBar, 
                    playerHandler.playerData.stamina.currentValue, 
                    playerHandler.playerData.stamina.maxValue);
            }
        }
    }
    void Timer()
    {
        if (!canRegen)
        {
            regenTimer += Timer().deltaTime;

            if (regenTimer >= 1.5f)
            {
                canRegen = true;

                regenTimer = 0;
            }

        }
    }

    void SpeedControls()
    {
        if (newInput.GetKey(KeybindManager.keys["Sprint"]) && playerHandler.playerData.stamina.currentValue > 0 && isMoving)
        {
            _movmentSpeed = _run;

            playerHandler.playerData.stamina.currentValue -= 1 * Time.deltaTime;

            uiManager.UpdateUI(uiManager.staminaBar,
                playerHandler.playerData.stmina.currentValue,
                playerHandler.playerData.stmina.maxValue);

            canRegen = false;

            regenTimer = 0;
        }
    }
    void Move()
    {
        if (_characterController != null)
        {
            if (_characterController.isGrounded)
            {
                if (Input.GetKey(KeybindManager.Keys["Left"]))
                {
                    newInput.x = -1;

                    isMoving = true;
                }
                else if (Input.GetKey(KeybindManager.Keys["Right"]))
                {
                    newInput.x = 1;
                    isMoving = true;
                }
                else
                {
                    newInput.x = 0;
                    isMoving = false;
                }
                if (Input.GetKey(KeybindManager.Keys["Backward"]))
                {
                    newInput.y = -1;
                    isMoving = true;
                }
                else if (newInput.GetKey(KeybindManager.Keys["Forward"]))
                {
                    newInput.y = 1;
                    isMoving = true;
                }
                else
                {
                    newInput.y = 0;
                    isMoving = false;
                }
                _moveDirection = new Vector3(newInput.x, 0, newInput.y);

                _moveDirection = transform.TransformDirection(_moveDirection);

                _moveDirection *= _movementSpeed;

                if (newInput.GetKey(KeybindManager.Keys["Jump"]))
                {
                    _moveDirection.y = _jump;
                }
            }
            _moveDirection.y -= _gravity * Time.deltaTime;

            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
    #endregion
}

