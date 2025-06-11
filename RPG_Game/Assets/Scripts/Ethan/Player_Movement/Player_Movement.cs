using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region Variables
    //this stores the direction in which the player moves
    [SerializeField] Vector3 _moveDirection;
    //This stores a reference to the CharacterController component within Unity
    [SerializeField] CharacterController _characterController;
    //This stores the different speed in which the player walks, runs, crouches and jumps as well as the gravity the game has
    [SerializeField] float _movementSpeed, _walk = 5, _run = 10, _crouch = 2.5f, _jump = 8, _gravity = 20;
    //This stores the x and y input for moving
    Vector2 newInput;
    //This references the playerhandler script
    PlayerHandler playerHandler;
    //reference to the UImanager script
    [SerializeField] UIManager uiManager;
    //variable to check whether the player is moving or not
    bool isMoving;
    //variable to check whether the player can regen stamina or not
    bool canRegen;
    //Adds delay to stamina regen after using stamina
    float regenTimer;
    #endregion

    #region Unity Callbacks
    //this function calls once the script is loaded
    private void Awake()
    {
        //stores the charactercontrolelr component into a variable
        _characterController = GetComponent<CharacterController>();
        //stores the playerhandler component into the variable
        playerHandler = GetComponent<PlayerHandler>();
        //find the component with the game manager taf and then stores the UImanager in the variable
        uiManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
    }


    // Update is called once per frame
    void Update()
    {
        //calls upon the timer function, which tells the script when stamina can start to regen
        Timer();
        //Calls upon the RegenOverTime function, which regenerates the stamina over time
        RegenOverTime();
        //calls upon the SpeedControls function, which controls the speed of the player based on whether the player is walking, sprinting or crouching, as well as the stamina bar
        SpeedControls();
        //calls upon the move function, which controls player movement
        Move();
    }
    #endregion

    #region Functions
    //states whether the stamina can regen or not, and if it can, controls the regeneration of the stamina
    void RegenOverTime()
    {
        //checks if the player can regen stamina
        if (canRegen)
        {
            //checks if the current stamina amount is less than the maximum allowed
            if (playerHandler.playerData.stamina.currentValue < playerHandler.playerData.stamina.maxValue)
            {
                //increases stamina over time, which is based on the regen rage and time
                playerHandler.playerData.stamina.currentValue += playerHandler.playerData.stamina.value * Time.deltaTime;
                //updates the UI  to reflect stamina bar
                uiManager.UpdateUI(
                    uiManager.staminaBar, 
                    playerHandler.playerData.stamina.currentValue, 
                    playerHandler.playerData.stamina.maxValue);
            }
        }
    }
    //controls the timer that delays the stamina regen after having sprinted
    void Timer()
    {
        //checks if the player can or cannot regen
        if (!canRegen)
        {
            //increases the regen tiemr by 1 every second it is called
            regenTimer += Time.deltaTime;
            //checks if the regen timer has reached 1.5 seconds
            if (regenTimer >= 1.5f)
            {
                //allows the player to regenerate stamina
                canRegen = true;
                //resets the regentimer to 0
                regenTimer = 0;
            }

        }
    }
    //controls the speed of the player
    void SpeedControls()
    {
        // checks if the player is pressing the sprint key, if they still have some stamina left and is moving
        //if (Input.GetKey(KeybindManager.keys["Sprint"]) && playerHandler.playerData.stamina.currentValue > 0 && isMoving)
        if (Input.GetKey(KeyCode.LeftShift) && playerHandler.playerData.stamina.currentValue > 0 && isMoving)

        {
            //if they are, then they start to move at the speed of running
            _movementSpeed = _run;
            //decreases the stamina by 1 per second
            playerHandler.playerData.stamina.currentValue -= 1 * Time.deltaTime;
            //updates the stamina bar
            uiManager.UpdateUI(uiManager.staminaBar,
                playerHandler.playerData.stamina.currentValue,
                playerHandler.playerData.stamina.maxValue);
            //makes it so that the player cannot regen
            canRegen = false;
            //sets the timer for which the player can regen to 0
            regenTimer = 0;
        }
        //checks if the player is pressing the crouch button
        //else if (Input.GetKey(KeybindManager.Keys["Crouch"])) 
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            //if so, the speed of the player when moving is the value that is set as crouch speed
            _movementSpeed = _crouch;
        }
        //if the player is not sprinting or courching, then this happens
        else
        {
            //The movement speed is set to a walking speed
            _movementSpeed = _walk;
        }
    }
    //controls player movement
    void Move()
    {
        //checks if the character controller is attached to anything
        if (_characterController != null)
        {
            //Checks if the player is on the ground or any surface
            if (_characterController.isGrounded)
            {
                //checks if the player is pressing the button that makes them move left
                //if (Input.GetKey(KeybindManager.Keys["Left"]))
                if (Input.GetKey(KeyCode.A))
                {
                    //makes the player move left
                    newInput.x = -1;
                    //makes the variable show that the player is moving
                    isMoving = true;
                }
                //checks if the player pressed the button that makes them move right
                //else if (Input.GetKey(KeybindManager.Keys["Right"]))
                else if (Input.GetKey(KeyCode.D))
                {
                    //makes the player move right
                    newInput.x = 1;
                    //makes the variable show that the player is moving
                    isMoving = true;
                }
                else
                {
                    //if the player did not press any movement button, then the player does not move at all
                    newInput.x = 0;
                    //makes the variable show that the player is not moving
                    isMoving = false;
                }
                //checks if the player pressed the button that makes the player move backwards
                //if (Input.GetKey(KeybindManager.Keys["Backward"]))
                if(Input.GetKey(KeyCode.S))
                {
                    //makes the player move backward
                    newInput.y = -1;
                    //makes the variable show that the player is moving
                    isMoving = true;
                }
                //checks to see if the player pressed the button that makes them move forward
                //else if (Input.GetKey(KeybindManager.Keys["Forward"]))
                else if(Input.GetKey(KeyCode.W))
                {
                    //makes the player move forward
                    newInput.y = 1;
                    //makes the variable show that the player is moving
                    isMoving = true;
                }
                else
                {
                    //makes it so that the player does not move
                    newInput.y = 0;
                    //shows that the player is not moving
                    isMoving = false;
                }
                //applies movement based on the above movement inputs
                _moveDirection = new Vector3(newInput.x, 0, newInput.y);
                //changes movement direction according to player rotation
                _moveDirection = transform.TransformDirection(_moveDirection);
                //adjusts movement direction according to the movement speed of the player
                _moveDirection *= _movementSpeed;
                //checks to see if the player wants to jump
                //if (Input.GetKey(KeybindManager.Keys["Jump"]))
                if(Input.GetKey(KeyCode.Space))
                {
                    //makes the player jump
                    _moveDirection.y = _jump;
                }
            }
            //applies gravity to the player
            _moveDirection.y -= _gravity * Time.deltaTime;
            //move the player based on the direction of movement
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
    #endregion
}

