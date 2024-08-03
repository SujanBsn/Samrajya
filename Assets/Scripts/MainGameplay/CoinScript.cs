using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public EventTagObject eventTags;
    public GameEvent coinPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("King"))
        {
            coinPickup.Raise(this, 1, eventTags.coinPickupTag);
            Destroy(gameObject);
        }
    }
}
