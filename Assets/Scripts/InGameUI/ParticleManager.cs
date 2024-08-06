using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Particle Effects")]
    public GameObject addSoldierParticle;
    public GameObject obstacleCollisionParticle;
    public GameObject soldierDespawnParticle;
    public GameObject soldierSpawnParticle;
    public GameObject coinPickUpParticle;
    public GameObject cannonBallHitParticle;
    public GameObject cannonBallFireParticle;

    [Header("Transforms")]
    public Transform kingPosition;

    public void InstantiateCollisionParticles(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.rockCollideTag)
        {
            Instantiate(obstacleCollisionParticle, kingPosition);
        }

        if (tag == EventTags.cannonBallHitTag)
        {
            GameObject _cannonBallHitParticle = GameObject.Instantiate(cannonBallHitParticle);
            Transform cannonBallPosition = data as Transform;
            _cannonBallHitParticle.transform.position = cannonBallPosition.position;
        }
    }

    public void InstantiateCannonFireParticle(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.cannonBallFire)
        {
            GameObject _cannonFirePartilce = Instantiate(cannonBallFireParticle, sender.transform);
            Transform cannonPosition = data as Transform;
            _cannonFirePartilce.transform.position = cannonPosition.position;
        }
    }

    public void InstantiateDespawnParticles(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.soldierDespawnParticleTag)
        {
            GameObject despawnParticle = GameObject.Instantiate(soldierDespawnParticle);
            Transform soldierTransform = data as Transform;
            despawnParticle.transform.position = soldierTransform.position;
        }
    }

    public void InstantiateSpawnParticles(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.soldierSpawnParticleTag)
            GameObject.Instantiate(soldierSpawnParticle, data as Transform);
    }

    public void InstantiateCoinPickUpParticles(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.coinPickupTag)
        {
            GameObject coinParticle = GameObject.Instantiate(coinPickUpParticle);
            Transform coinTransfrom = sender.transform;
            coinParticle.transform.position = coinTransfrom.position;
        }
    }

    public void InstantiateAddSoldierParticles(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.AddSoldierTag)
        {
            GameObject _addSoldierParticle = GameObject.Instantiate(addSoldierParticle);
            Transform _soldierTransform = sender.transform;
            _addSoldierParticle.transform.position = _soldierTransform.position;
        }
    }

}
