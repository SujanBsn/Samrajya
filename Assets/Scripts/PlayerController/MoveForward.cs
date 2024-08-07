using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = 5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy_Boss"))
        {
            speed = 0f;
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    private void Update()
    {
        Vector3 forwardPos = new(0, 0, transform.forward.z);
        transform.position += speed * Time.deltaTime * forwardPos;
    }
}
