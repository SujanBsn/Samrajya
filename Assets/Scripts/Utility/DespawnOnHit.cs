using UnityEngine;

public class DespawnOnHit : MonoBehaviour
{
    public string targetTag;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(targetTag))
            Destroy(gameObject);
    }
}
