using UnityEngine;

public class PlayerTouchController : MonoBehaviour
{
    public float sensitivity;

    private void Start()
    {
        sensitivity = 3.5f;
    }

    private void Update()
    {
        TouchControl();
    }

    /// <summary>
    /// Control the attached player with touch
    /// </summary>
    void TouchControl()
    {
        if(Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved) 
            {
                Vector3 currentPos = transform.position;
                Vector3 newPos = new(
                    currentPos.x + touch.deltaPosition.x / Screen.width * sensitivity,
                    currentPos.y,
                    currentPos.z);

                transform.position = Vector3.MoveTowards(transform.position, newPos, sensitivity);
            }
        }
    }
}
