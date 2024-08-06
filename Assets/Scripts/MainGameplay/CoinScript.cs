using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameEvent coinPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("King"))
        {
            coinPickup.Raise(this, 1, EventTags.coinPickupTag);
            Destroy(gameObject);
        }
    }
}
