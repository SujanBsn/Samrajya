using UnityEngine;

public class SimpleScaler3D : MonoBehaviour
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
        transform.LeanScale(new Vector3(maxSize, maxSize,maxSize), animationTime).setEaseInOutQuad().setLoopPingPong();
    }

    public void StopScaleAnimation()
    {
        LeanTween.cancel(gameObject);
    }
}
