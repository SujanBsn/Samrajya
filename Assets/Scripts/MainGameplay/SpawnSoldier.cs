using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class SpawnSoldier : MonoBehaviour
{
    [Header("UI")]
    public PlayerStatusObject playerStatus;

    [Header("King")]
    public GameObject kingPrefab;
    public GameObject soldierVesselPrefab;

    [Header("Soldier")]
    public GameObject soldierPrefab;
    public TextMeshPro soldierCountText;

    [Header("Positioning")]
    public float soldierSpacing = 1.5f; // Space between soldiers
    public float[] columnOffsets;// Offsets for the columns



    readonly private List<GameObject> soldiers = new();
    

    void Start()
    {
        playerStatus.soldierCount = 0;
        playerStatus.maxSoldierCount = 12;
        InvokeRepeating(nameof(SpawnTroop), 3f, 3f);
    }

    /// <summary>
    /// Spawns 1 troop
    /// </summary>
    void SpawnTroop()
    {
        if (playerStatus.soldierCount < playerStatus.maxSoldierCount)
        {
            playerStatus.soldierCount++;
            soldierCountText.text = playerStatus.soldierCount.ToString();

            // Calculate the index for the next soldier
            int soldierIndex = soldiers.Count % columnOffsets.Length;
            float offset = columnOffsets[soldierIndex];

            // Calculate the spawn position for the new soldier
            Vector3 kingPosition = kingPrefab.transform.position;
            Vector3 spawnPosition = kingPosition - ((soldiers.Count / columnOffsets.Length) + 1) * soldierSpacing * kingPrefab.transform.forward + offset * soldierSpacing * kingPrefab.transform.right;

            GameObject newSoldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
            newSoldier.transform.parent = soldierVesselPrefab.transform;
            soldiers.Add(newSoldier);
        }
    }
}
