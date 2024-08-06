using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleObject obstacleType;
    public GameEvent obstacleCollision;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("King"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            OnCollisionResponse();
        }
    }

    void OnCollisionResponse()
    {
        float[] penaltyValue = { obstacleType.despawnCount, obstacleType.despawnTime, obstacleType.initialDelay };
        obstacleCollision.Raise(this, penaltyValue, EventTags.soldierDespawnTag);
        obstacleCollision.Raise(this, transform, obstacleType.obstacleTag);
    }
}
