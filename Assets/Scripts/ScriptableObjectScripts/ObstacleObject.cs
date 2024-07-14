using UnityEngine;
[CreateAssetMenu(fileName = "ObstacleObject", menuName = "ScriptableObjects/ObstacleObject")]
public class ObstacleObject : ScriptableObject
{
    public int despawnCount;
    public float despawnTime;
    public float initialDelay;
}
