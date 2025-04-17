using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        if (speed == 0)
            speed = 5f;
    }

    private void Update()
    {
        Vector3 forwardPos = new(0, 0, transform.forward.z);
        transform.position += speed * Time.deltaTime * forwardPos;
    }
}
