using UnityEngine;

public class SimpleCustomMove : MonoBehaviour
{
    public float animationTime;
    public Transform initialPosTransform;

    Vector3 initialPos;
    Vector3 finalPos;
    private void Awake()
    {
        initialPos = initialPosTransform.position;
        finalPos = transform.position;

        transform.position = initialPos;
        transform.LeanScale(Vector3.zero, 0);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.LeanMove(finalPos, animationTime).setEaseInQuad();
        transform.LeanScale(new Vector3(1, 1, 1), animationTime).setEaseInQuad();
    }

    public void MoveBackOnClose()
    {
        transform.LeanMove(initialPos, animationTime).setEaseOutQuad();
        transform.LeanScale(Vector3.zero, animationTime).setEaseOutQuad();
    }
}
