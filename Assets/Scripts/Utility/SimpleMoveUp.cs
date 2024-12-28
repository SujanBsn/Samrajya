using UnityEngine;

public class SimpleMoveUp : MonoBehaviour
{
    public float animationTime;

    Vector3 originalPos;
    private void Awake()
    {
        originalPos = transform.position;
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.LeanMoveLocal(new Vector2(0, -1920), 0);
        transform.LeanMove(originalPos, animationTime).setEaseInQuad();
    }

    public void MoveBackOnClose()
    {
        transform.LeanMoveLocal(new Vector2(0, -1920), animationTime).setEaseOutQuad();
    }
}
