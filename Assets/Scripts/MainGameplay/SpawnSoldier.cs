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
    public float[] columnOffsets = new float[] { 0f, -.25f, .25f, -.5f, .5f };// Offsets for the columns

    private List<GameObject> soldiers = new List<GameObject>();
    

    void Start()
    {
        InvokeRepeating(nameof(SpawnTroop), 5, 3);
    }

    /// <summary>
    /// Spawns 1 troop
    /// </summary>
    void SpawnTroop()
    {
        playerStatus.soldierCount++;
        soldierCountText.text = playerStatus.soldierCount.ToString();

        // Calculate the index for the next soldier
        int soldierIndex = soldiers.Count % columnOffsets.Length;
        float offset = columnOffsets[soldierIndex];

        // Calculate the spawn position for the new soldier
        Vector3 kingPosition = kingPrefab.transform.position;
        Vector3 spawnPosition = kingPosition - ((soldiers.Count / columnOffsets.Length) + 1) * soldierSpacing * kingPrefab.transform.forward + kingPrefab.transform.right * offset * soldierSpacing;

        GameObject newSoldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
        newSoldier.transform.parent = soldierVesselPrefab.transform;
        soldiers.Add(newSoldier);
    }
}
