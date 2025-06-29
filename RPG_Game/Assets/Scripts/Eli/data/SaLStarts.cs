using System.IO;
using UnityEngine;

public class SaLStats : MonoBehaviour
{
    string _filePath = $"{Application.dataPath}/PlayerStatsData.json"; //The Path and name of the .JSON file which will Save the data 
    public PlayerStats playerStats = new PlayerStats();

    private void Awake()
    {
        if (File.Exists(_filePath)) //If the code finds "PlayerStatsData.json" it will will run LoadPlayerStats
        {
            LoadPlayerStats(); 
        }
    }

    void GetStatDataToSave()  //List of data it will save to the Json file
    {
        GameObject player = GameObject.FindWithTag("Player"); //finds a gameobject with the tag player
        var StatsData = player.GetComponent<PlayerStats>(); //reads the player stats on the player game object

        playerStats.name = StatsData.name; //Saves the player/Charactors name
        playerStats.level = StatsData.level; //Saves the players current level
        playerStats.health = StatsData.health; //saves the players current health
        playerStats.stamina = StatsData.stamina; //saves the players current stanima 
        playerStats.experience = StatsData.experience; //saves the players current XP
        playerStats.stats = StatsData.stats; //saves the players stats
    }


    void SaveJSON(PlayerStats data, string path) //formats Stats Data into a Json string and saves it to the file path location
    {
        string lineToSave = JsonUtility.ToJson(data, true); //convers the data into a Json string
        File.WriteAllText(path, lineToSave); //writes to the file
    }

    public void SavePlayerStats() //Called to save player stats data to the file
    {
        GetStatDataToSave(); //Gathers the new player stats
        SaveJSON(playerStats, _filePath); //Saves the .Json to the file path 
    }

    PlayerStats LoadData() //load Saved data from the Json file 
    {
        string loadedData = File.ReadAllText(_filePath); //reads the Saved data from the Json file 
        return JsonUtility.FromJson<PlayerStats>(loadedData); //Converted the Saved data into the object data
    }

    void SendDataFromLoad() //sends the loaded saved data to the correct manager script
    {
        GameObject player = GameObject.FindWithTag("Player"); //finds a gameobject with the tag player
        var StatsData = player.GetComponent<PlayerStats>(); //reads the player stats on the player game object

        StatsData.name = playerStats.name; //loads the players/charactors name 
        StatsData.level = playerStats.level; //loads the players level
        StatsData.health = playerStats.health; //loads the players current health 
        StatsData.stamina = playerStats.stamina; //loads the players current stamina
        StatsData.experience = playerStats.experience; //loads the players current XP
        StatsData.stats = playerStats.stats; //loads the players current stats
    }

    public void LoadPlayerStats() //loads and applys Saved settings options from the .Jsom file 
    {
        playerStats = LoadData(); //loads from the file path
        SendDataFromLoad(); //applys the saved data to the game
    }
}
