using UnityEngine;

[CreateAssetMenu(fileName = "EventTagObject", menuName = "ScriptableObjects/EventTagObject")]
public class EventTagObject : ScriptableObject
{
    public string soldierSpawnTag = "soldierSpawnTag";
    public string soldierDespawnTag = "soldierDespawnTag";

    public string soldierCountTag = "soldierCountTag";

    [Header("Particle Effect Tags")]
    public string collisionParticleTag = "collisionParticleTag";
    public string soldierSpawnParticleTag = "soldierSpawnParticleTag";
    public string soldierDespawnParticleTag = "soldierDespawnParticleTag";
}
