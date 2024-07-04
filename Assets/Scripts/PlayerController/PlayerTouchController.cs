using UnityEngine;

public class PlayerTouchController : MonoBehaviour
{
    public float sensitivity;

    public GameObject pathInner;

    private float minPathX;
    private float maxPathX;

    private void Start()
    {
        sensitivity = 20f;
        SetPathBounds();
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
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Moved) return;

        Vector3 currentPos = transform.position;
        float moveDelta = touch.deltaPosition.x / Screen.width * sensitivity;

        Vector3 newPos = new(
            Mathf.Clamp(currentPos.x + moveDelta, minPathX, maxPathX),
            currentPos.y,
            currentPos.z
        );

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * sensitivity);
    }

    /// <summary>
    /// Sets the minimum and maximum x bounds of the path
    /// </summary>
    void SetPathBounds()
    {
        Collider pathBoxCollider = pathInner.GetComponent<BoxCollider>();
        minPathX = pathBoxCollider.bounds.min.x;
        maxPathX = pathBoxCollider.bounds.max.x;
    }
}
