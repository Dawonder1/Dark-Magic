using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public PlayerStatistics playerStats;
    public PlayerStatistics startingStats;
    private string statsSavePath;

    private void OnEnable()
    {
        statsSavePath = Application.persistentDataPath + "/statsSave.txt";
        LoadPlayerStats();
    }

    private void SavePlayerStats()
    {
        string str = JsonUtility.ToJson(playerStats);
        File.WriteAllText(statsSavePath, str);
    }

    private void LoadPlayerStats()
    {
        if (File.Exists(statsSavePath)) { playerStats = startingStats; }
        else
        {
            string str = File.ReadAllText(statsSavePath);
            playerStats = JsonUtility.FromJson<PlayerStatistics>(str);
        }
    }

    private void OnDisable()
    {
        SavePlayerStats();
    }
}

[System.Serializable]
public struct  PlayerStatistics
{
    public Damage damage;
    public float attackRange;
    public int maxHealth;
}

[System.Serializable]
public struct Damage
{
    public int value;
}