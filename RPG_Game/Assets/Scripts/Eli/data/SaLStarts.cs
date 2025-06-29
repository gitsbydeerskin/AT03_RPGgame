using System.IO;
using UnityEngine;

public class SaLStats : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/PlayerStatsData.json";
    public PlayerStats playerStats = new PlayerStats();

    private void Awake()
    {
        if (File.Exists(_filePath))
        {
            LoadPlayerStats();
        }
    }

    void GetDataToSaveFromGame()
    {
        GameObject player = GameObject.FindWithTag("Player");
        var statsComponent = player.GetComponent<PlayerStats>(); // Or whatever your script is

        playerStats.name = statsComponent.name;
        playerStats.level = statsComponent.level;
        playerStats.health = statsComponent.health;
        playerStats.stamina = statsComponent.stamina;
        playerStats.experience = statsComponent.experience;
        playerStats.stats = statsComponent.stats;
    }


    void SaveJSON(PlayerStats data, string path)
    {
        string lineToSave = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, lineToSave);
    }

    PlayerStats LoadData()
    {
        string loadedData = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<PlayerStats>(loadedData);
    }

    public void SavePlayerStats()
    {
        GetDataToSaveFromGame();
        SaveJSON(playerStats, _filePath);
    }

    public void LoadPlayerStats()
    {
        playerStats = LoadData();
        SendDataFromLoad();
    }

    void SendDataFromLoad()
    {
        GameObject player = GameObject.FindWithTag("Player");
        var statsComponent = player.GetComponent<PlayerStats>();

        statsComponent.name = playerStats.name;
        statsComponent.level = playerStats.level;
        statsComponent.health = playerStats.health;
        statsComponent.stamina = playerStats.stamina;
        statsComponent.experience = playerStats.experience;
        statsComponent.stats = playerStats.stats;
    }
}
