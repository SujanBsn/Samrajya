using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataObject", menuName = "ScriptableObjects/PlayerDataObject")]
public class PlayerDataObject : ScriptableObject
{
    [SerializeField]
    private PlayerData playerData; // The PlayerData instance

    public PlayerData PlayerData => playerData; // Read-only access

    /// <summary>
    /// Initialize the PlayerData instance.
    /// </summary>
    public void Initialize()
    {
        playerData = SaveSystem.LoadPlayer();
    }
    public void UpdatePlayerDataAndSave(PlayerData newPlayerData = null, Action<PlayerData> updateAction = null)
    {
        if (newPlayerData != null)
        {
            playerData = newPlayerData;
        }

        if (updateAction != null)
        {
            updateAction(playerData);
        }

        SaveSystem.SavePlayer(playerData);
    }
}
