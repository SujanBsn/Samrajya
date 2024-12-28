using UnityEngine;

public class SimpleScaler : MonoBehaviour
{
    public float maxSize;
    public float minSize;
    public float animationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartScaleAnimation();
    }

    public void StartScaleAnimation()
    {
        transform.LeanScale(new Vector2(maxSize, maxSize), animationTime).setEaseInOutQuad().setLoopPingPong();
    }

    public void StopScaleAnimation()
    {
        LeanTween.cancel(gameObject);
    }
}
