using MoreMountains.Feedbacks;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public EventTagObject eventTags;
    public ObstacleObject obstacleType;
    public GameEvent obstacleCollision;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Collider>().enabled = false;
        OnCollisionResponse();
    }

    void OnCollisionResponse()
    {
        float[] penaltyValue = { obstacleType.despawnCount, obstacleType.despawnTime, obstacleType.initialDelay };
        obstacleCollision.Raise(this, penaltyValue, eventTags.soldierDespawnTag);
    }
}
