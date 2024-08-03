using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public EventTagObject eventTags;

    [Header("Particle Effects")]
    public GameObject obstacleCollisionParticle;
    public GameObject soldierDespawnParticle;
    public GameObject soldierSpawnParticle;
    public GameObject coinPickUpParticle;

    [Header("Transforms")]
    public Transform kingPosition;

    public void InstantiateCollisionParticles(Component sender, object data, string tag)
    {
        if(tag == eventTags.collisionParticleTag)
            GameObject.Instantiate(obstacleCollisionParticle, kingPosition);
    }

    public void InstantiateDespawnParticles(Component sender, object data, string tag)
    {
        if (tag == eventTags.soldierDespawnParticleTag)
        {
            GameObject despawnParticle = GameObject.Instantiate(soldierDespawnParticle);
            Transform soldierTransform = data as Transform;
            despawnParticle.transform.position = soldierTransform.position;
        }
    }

    public void InstantiateSpawnParticles(Component sender, object data, string tag)
    {
        if (tag == eventTags.soldierSpawnParticleTag)
            GameObject.Instantiate(soldierSpawnParticle, data as Transform);
    }

    public void InstantiateCoinPickUpParticles(Component sender, object data, string tag)
    {
        if (tag == eventTags.coinPickupTag)
        {
            GameObject coinParticle = GameObject.Instantiate(coinPickUpParticle);
            Transform coinTransfrom = sender.transform;
            coinParticle.transform.position = coinTransfrom.position;
        }

    }

}
