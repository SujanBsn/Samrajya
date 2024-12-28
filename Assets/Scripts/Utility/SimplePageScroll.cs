using UnityEngine;

public class SimplePageScroll : MonoBehaviour
{
    [Header("Gameobjects")]
    public GameObject targetPageUI;
    public GameObject currentPageUI;

    [Header("Scroll Direction")]
    [Tooltip("1 for left to right, -1 for right to left")]
    public int direction;

    [Header("Time")]
    public float animationTime = 1f;



    //Wait until loading completes to start animation
    public void ScrollPage()
    {
        if ((direction != 0))
        {
            direction /= Mathf.Abs(direction);
        }
        else
        {
            direction = 1;
        }


        //Wait until the slider is filled completely
        currentPageUI.transform.LeanMoveLocal(new Vector2(1920 * direction, 0), animationTime)
            .setOnComplete(() => currentPageUI.SetActive(false));//lambda 

        targetPageUI.transform.LeanMoveLocal(new Vector2(-1920 * direction, 0), 0);
        targetPageUI.SetActive(true);
        targetPageUI.transform.LeanMoveLocal(new Vector2(0, 0), animationTime);
    }
}
