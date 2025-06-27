using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    #region Variables
    //Allows access to the playerstats from the PlayerStats Script
    //PlayerStats is a public STRUCT
    public PlayerStats playerData = new PlayerStats();
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timerValue;

    //To be used for damage = turned on and off as needed in this script
    [SerializeField] bool canHeal = true;

    public UIManager uiManager;

    //Below is used for Respawn mechanic

    //Access to the player Capsule itself
    public GameObject playerObject;
    //Used for damage. Counts how many times something with this tag hits the playerObject in either Update or LateUpdate.
    private List<string> hitTags = new List<string>();
    private List<string> currentHitTags = new List<string>();
    #endregion

    #region Public Methods
    public void DamagePlayer(float damageValue)
    {
        timerValue = 0;
        canHeal = false;
        playerData.health.currentValue -= damageValue;
        uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
    }
    #endregion

    #region Private Methods
    void HealOverTime()
    {
        // If canHeal = true
        // = IF the Player is in a spot where they CAN Heal = 
        if (canHeal)
        {
            // and Player Health is less than the max Value and greater than 0 (so they're wounded, but not dead)
            // = IF the Player has taken damage, but hasn't died
            if (playerData.health.currentValue < playerData.health.maxValue && playerData.health.currentValue > 0)
            {
                // Player's Health goes up incrementally - calculation is their own health value x TIME. 
                playerData.health.currentValue += playerData.health.value * Time.deltaTime;
                // And this is shown to the Player by updating the UI (the healthBar specifically), which is a physical game object (Image). 
                // The healthBar can display any value between 0 and the Player's 'maxValue'. 
                uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
            }
        }
    }

    void Timer()
        // Timer is used for Healing mainly
    {
        if (!canHeal)
            // If the player cannnot currently Heal
        {
            // The timer's Value is replaced with the delta time
            timerValue += Time.deltaTime;
            if (timerValue > 1.5f)
                // IF the timer's value is greater than 1.5f
            {
                canHeal = true;
                // Can Heal is set to TRUE
                timerValue = 0;
                // and the timer's Value is reset to 0
                // This creates a loop.
                // The timer ticks up to 1.5f, then resets to 0
                // Whenever the player can Heal.
                // Otherwise, the Timer won't be called.
            }
        }
    }

    void Respawn()
    {
        if (playerData.health.currentValue > 0)
        // If the Player's health is over 0
        // ie, if the Player is alive
        {
            return;
            // return - don't run
        }
        // Otherwise, the Player is dead: 
        else
        { 
            playerObject.GetComponent<CharacterController>().enabled = false;
            // Find the Character Controller. Disable it.
            playerObject.transform.position = spawnPoint.position;
            // the Player's position now equals the spawnPoint's position (ie, return the Player to the spawnPoint).
            playerData.health.currentValue = playerData.health.maxValue;
            // The Player's current health now equals the player's MAX health.
            playerData.stamina.currentValue = playerData.stamina.maxValue;
            // the Player's stamina now equals the Player's MAX stamina.
            canHeal = true;
            // The Player can Heal
            uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
            uiManager.UpdateUI(uiManager.staminaBar, playerData.stamina.currentValue, playerData.stamina.maxValue);
            // Update UI with the Stamina and Health values. 
            playerObject.GetComponent<CharacterController>().enabled = true;
            // Turn the Player Character Controller BACK ON. 
            Debug.Log("Respawning!");
            // Debug Log to ensure Respawn function is working. 
        }
    }
    #endregion

    #region Callbacks
    private void Start()
    {
        // This line of code is to make sure the uiManager can find the GameManager on its own, however, it was throwing an error and I'm too sick to deal with it right now, so I have left it commented out for now. '
        // It was complaining that GameObject has no definition for GetComponent or something like that. Not sure why, since I'm asking it to perform a function/call or whatever, and not asking for it to LOOK for something called 'GetComponent' like it's a variable. 
        // This code theoretically should just work like the other code in this .cs that does similar, but idk 

      //  uiManager = GameObject.FindGameObjectsWithTag("GameManager").GetComponent<UIManager>();


        uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
        uiManager.UpdateUI(uiManager.staminaBar, playerData.stamina.currentValue, playerData.stamina.maxValue);
        uiManager.UpdateUI(uiManager.experienceBar, playerData.experience.currentValue, playerData.experience.maxValue);
        // These are setting up the UiManager script to update three UI elements for XP, Stamina, and HP, shown in the game. 
        playerObject = GameObject.FindGameObjectWithTag("Player");
        // This is declaring and finding the in-game Player - the object tagged 'Player' - in this case a Capsule. 
    }

    private void OnTriggerEnter(Collider other)
        // This function is used for when the Player enters the HP and DMG Spheres. 
        // It could be expanded to include more tags and functionalities.
    {
        if (other.tag == "Heal")
            // If an object is tagged with "Heal" 
        {
            playerData.health.value *= 2;
            // It multiples the healing value by x 2
            Debug.Log("Healing!");
            // and the Debug.Log prints this message (for testing)
        }
        if (other.gameObject.CompareTag("Damage"))
            // If the object is tagged with "Damage"
        {
            DamagePlayer(10);
            // It does -10 Damage from the Players HP
            Debug.Log("OWIE");
            // and the Dbug.Log prints this message
        }
    }

    private void OnTriggerExit(Collider other)
        // This function is used for when the Player exits the HP and Sphere
        // It could be expanded to include more Tags and functionality.
    {
        if (other.tag == "Heal")
            // If the Player LEAVES an item tagged "Heal"
        { 
            playerData.health.value /= 2;    
            // Their health value is halved by 2, returning their healing to normal. 
            // This means the HP Sphere is a unique Healing zone. 
        }
        if (other.tag == "SpawnPoint")
            // IF the Sphere is tagged as a Spawnpoint.
        {
            spawnPoint = other.transform;
            // It stores the transform (ie location) of the spawnPoint.
            // When we Respawn the Player later, they will be called back to this location. 
        }
    }

    private void LateUpdate()
        // This is for processing damage to the player
        // Specifically, it's for handling physics and making sure it's been processed properly
    {
        int i = 0;
        // i = 0 means no matching tag was found

        if (currentHitTags.Count > 0)
            // This checks if there are any current hit tags for this frame
        {
            foreach (string tag in currentHitTags)
                // This loops through all tags the player is currently in contact with this frame.
            {
                if (hitTags.Contains(tag))
                    // This checks if the tags are the same (ie, if the tag was already processed for damage)
                {
                    i = 1;
                    // If there's at least ONE match between currentHitTags and hitTags
                    // we set i to 1, meaning a match was found
                }
            }
        }
        if (i == 0)
            // If no matching tags were found
            // i == 0
        {
            hitTags.Clear();
            // we clear hitTags entirely
            // Meaning the player isn't in contact with any relevant colliders most likely
            // And the persistant list of hitTags should be reset
            // To allow for future damage
        }
        currentHitTags.Clear();
        // We clear the currentHitTags every frame
        // This resets it so it's only populated with new collissions during the NEXT frame
        // Ensures fresh processing
        Respawn();
        // Call respawn at the end of LateUpdate
        // If Player was killed and should be Respawned, Player will Respawn.
        // If Player wasn't killed, Respawn has built-in failsafe.
    }
    private void Update()
        // Called every frame
    {
        HealOverTime();
        // Player by default Heals slowly over time unless they are being damaged or at full Health. 
        Timer();
        // Timer is called on Update to allow player to Heal. 
        // If Timer isn't called here, no Healing functions work. 
    }
    #endregion

}
