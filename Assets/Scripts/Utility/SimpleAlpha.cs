using UnityEngine;

public class SimpleAlpha : MonoBehaviour
{
    public float minAlpha;
    public float maxAlpha;
    public float animationTime;

    public GameObject homePageUI;

    GameObject thisCanvasParent;
    CanvasGroup thisCanvas;

    // Start is called before the first frame update
    void OnEnable()
    {
        thisCanvas = GetComponent<CanvasGroup>();
        thisCanvasParent = transform.parent.gameObject;
        AlphaAnimationBegin();
    }

    public void AlphaAnimationBegin()
    {
        thisCanvas.alpha = minAlpha;
        thisCanvas.LeanAlpha(maxAlpha, animationTime).setOnComplete(() => homePageUI.SetActive(false));
    }

    public void AlphaAnimationEnd()
    {
        thisCanvas.alpha = maxAlpha;
        //disable the parent canvas on animation end
        thisCanvas.LeanAlpha(minAlpha, animationTime).setOnComplete(() =>
        {
            thisCanvasParent.SetActive(false);
            homePageUI.SetActive(true);
        });
    }
}
