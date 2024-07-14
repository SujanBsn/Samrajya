using UnityEngine;

[CreateAssetMenu(fileName = "SoldierPositionObject", menuName = "ScriptableObjects/SoldierPositionObject")]
public class SoldierPositionObject : ScriptableObject
{
    public int soldierCount;
    public int maxPassiveGenerationCount;
    public int maxSoldierCount;

    public float soldierSpawnSpeed;
    public float soldierInitialSpawnDelay;
    public float soldierSpacing = 1.5f; // Space between soldiers
    public float[] columnOffsets; // Offsets for the columns
    public float maxSpeed = 8f; // Maximum speed for soldiers
    public float distanceFactor = 4.5f; // Factor to determine speed based on distance
    public LayerMask groundLayer; // Layer mask to identify the ground
}
