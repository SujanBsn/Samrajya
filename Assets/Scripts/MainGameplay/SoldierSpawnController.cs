using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SoldierSpawnController : MonoBehaviour
{
    [Header("UI")]
    public SoldierPositionObject soldierPosition;

    [Header("King")]
    public GameObject kingPrefab;
    public GameObject soldierVesselPrefab;

    [Header("Soldier")]
    public GameObject soldierPrefab;

    [Header("Events")]
    public GameEvent soldierSpawnEvent;
    public GameEvent soldierDespawnEvent;

    float soldierSpacing;// Space between soldiers
    float[] columnOffsets;// Offsets for the columns

    readonly private List<GameObject> soldiers = new();

    private void Start()
    {
        soldierPosition.soldierCount = 0;
        SpawnTroopPassive(soldierPosition.maxPassiveGenerationCount);
    }
     
    public void SpawnTroopPassive(int spawnCount)
    {
       StartCoroutine(SpawnTroops(spawnCount, soldierPosition.soldierSpawnSpeed, soldierPosition.soldierInitialSpawnDelay));
    }

    public void SpawnTroopsActive(int spawnCount, float spawnTime)
    {
        StartCoroutine(SpawnTroops(spawnCount, spawnTime, 0));
    }
    
    public void SpawnTroopsActive(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.AddSoldierTag)
        {
            float[] soldierSpawnData = data as float[];
            StartCoroutine(SpawnTroops((int)soldierSpawnData[0], soldierSpawnData[1], 0));
        }
    }

    public void DespawnSoldiers(int despawnCount, float despawnTime, float initialDelay)
    {
        StartCoroutine(DespawnTroops(despawnCount, despawnTime, initialDelay));
    }

    public void DespawnSoldiers(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.soldierDespawnTag)
        {
            float[] receivedData = data as float[];

            int despawnCount = (int)receivedData[0];
            float despawnTime = receivedData[1];
            float initialDelay = receivedData[2];

            StartCoroutine(DespawnTroops(despawnCount, despawnTime, initialDelay));
        }
    }

    IEnumerator SpawnTroops(int spawnCount, float spawnTime, float initialSpawnDelay)
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        int spawnedSoldiers = 0;
        while (spawnedSoldiers < spawnCount)
        {
            yield return new WaitForSeconds(spawnTime);
            soldierSpacing = soldierPosition.soldierSpacing;    
            columnOffsets = soldierPosition.columnOffsets;

            soldierPosition.soldierCount++;
            soldierSpawnEvent.Raise(this, soldierPosition.soldierCount, EventTags.soldierCountTag);

            // Calculate the index for the next soldier
            int soldierIndex = soldiers.Count % columnOffsets.Length;
            float offset = columnOffsets[soldierIndex];

            // Calculate the spawn position for the new soldier
            Vector3 kingPosition = kingPrefab.transform.position;
            Vector3 spawnPosition = kingPosition - ((soldiers.Count / columnOffsets.Length) + 1) * soldierSpacing * kingPrefab.transform.forward + offset * soldierSpacing * kingPrefab.transform.right;

            GameObject newSoldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
            newSoldier.transform.parent = soldierVesselPrefab.transform;
            soldiers.Add(newSoldier);
            soldierSpawnEvent.Raise(this, newSoldier.transform, EventTags.soldierSpawnParticleTag);
            spawnedSoldiers++;
        }
    }

    IEnumerator DespawnTroops(int despawnCount, float despawnTime, float initialDelay)
    {
        yield return new WaitForSeconds(initialDelay);

        int despawnedSoldiers = 0;
        while (despawnedSoldiers < despawnCount)
        {
            yield return new WaitForSeconds(despawnTime);

            if (soldierPosition.soldierCount == 0)
                break;

            soldierPosition.soldierCount--;
            soldierSpawnEvent.Raise(this, soldierPosition.soldierCount, EventTags.soldierCountTag);

            GameObject lastSoldier = soldiers[^1];
            soldiers.RemoveAt(soldiers.Count - 1);
            lastSoldier.SetActive(false);

            soldierDespawnEvent.Raise(null, lastSoldier.transform, EventTags.soldierDespawnParticleTag);
            GameObject.Destroy(lastSoldier);

            despawnedSoldiers++;
        }
    }
}
