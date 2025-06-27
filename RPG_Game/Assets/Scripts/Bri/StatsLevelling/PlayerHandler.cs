using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    #region Variables
    public PlayerStats playerData = new PlayerStats();
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timerValue;
    [SerializeField] bool canHeal = true;
    public UIManager uiManager;
    public GameObject playerObject;
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
        if (canHeal)
        {
            if (playerData.health.currentValue < playerData.health.maxValue && playerData.health.currentValue > 0)
            {
                playerData.health.currentValue += playerData.health.value * Time.deltaTime;
                uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
            }
        }
    }

    void Timer()
    {
        if (!canHeal)
        {
            timerValue += Time.deltaTime;
            if (timerValue > 1.5f)
            {
                canHeal = true;
                timerValue = 0;
            }
        }
    }

    void Respawn()
    {
        if (playerData.health.currentValue > 0)
        {
            return;
        }
        else
        { 
            playerObject.GetComponent<CharacterController>().enabled = false;
            playerObject.transform.position = spawnPoint.position;
            playerData.health.currentValue = playerData.health.maxValue;
            playerData.stamina.currentValue = playerData.stamina.maxValue;
            canHeal = true;
            uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
            uiManager.UpdateUI(uiManager.staminaBar, playerData.stamina.currentValue, playerData.stamina.maxValue);
            playerObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log("Respawning!");
        }
    }
    #endregion

    #region Callbacks
    private void Start()
    {
      //  uiManager = GameObject.FindGameObjectsWithTag("GameManager").GetComponent<UIManager>();

        uiManager.UpdateUI(uiManager.healthBar, playerData.health.currentValue, playerData.health.maxValue);
        uiManager.UpdateUI(uiManager.staminaBar, playerData.stamina.currentValue, playerData.stamina.maxValue);
        uiManager.UpdateUI(uiManager.experienceBar, playerData.experience.currentValue, playerData.experience.maxValue);
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Heal")
        {
            playerData.health.value *= 2;
            Debug.Log("Healing!");
        }
        if (other.gameObject.CompareTag("Damage"))
        {
            DamagePlayer(10);
            Debug.Log("OWIE");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Heal")
        { 
            playerData.health.value /= 2;    
        }
        if (other.tag == "SpawnPoint")
        {
            spawnPoint = other.transform;
        }
    }

    private void LateUpdate()
    {
        int i = 0;

        if (currentHitTags.Count > 0)
        {
            foreach (string tag in currentHitTags)
            {
                if (hitTags.Contains(tag))
                {
                    i = 1;
                }
            }
        }
        if (i == 0)
        {
            hitTags.Clear();
        }
        currentHitTags.Clear();
        Respawn();
    }
    private void Update()
    {
        HealOverTime();
        Timer();
    }
    #endregion

}
