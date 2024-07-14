using MoreMountains.Feedbacks;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleObject obstacleType;
    public GameEvent obstacleCollision;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MMF_Player>().PlayFeedbacks();
        OnCollisionResponse();
    }

    void OnCollisionResponse()
    {
        float[] penaltyValue = { obstacleType.despawnCount, obstacleType.despawnTime, obstacleType.initialDelay };
        obstacleCollision.Raise(this, penaltyValue);
    }
}
