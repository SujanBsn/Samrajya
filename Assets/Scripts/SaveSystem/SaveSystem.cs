using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static readonly string SavePath = Application.persistentDataPath + "/player.json";

    /// <summary>
    /// Saves player data to a JSON file.
    /// </summary>
    public static void SavePlayer(PlayerData player)
    {
        string json = JsonUtility.ToJson(player, true); // Convert player data to JSON
        File.WriteAllText(SavePath, json);             // Write JSON to file
        Debug.Log("Player data saved to: " + SavePath);
    }

    /// <summary>
    /// Loads player data from the JSON file. Returns default data if no file exists.
    /// </summary>
    public static PlayerData LoadPlayer()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);       // Read JSON from file
            PlayerData data = JsonUtility.FromJson<PlayerData>(json); // Convert JSON back to PlayerData
            Debug.Log("Player data loaded from: " + SavePath);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found. Returning default player data.");
            return new PlayerData(); // Return default data if save file is missing
        }
    }

    /// <summary>
    /// Deletes the player's save file.
    /// </summary>
    public static void DeletePlayerData()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath); // Delete the save file
            Debug.Log("Player data deleted from: " + SavePath);
        }
        else
        {
            Debug.LogWarning("No save file found to delete.");
        }
    }
}
