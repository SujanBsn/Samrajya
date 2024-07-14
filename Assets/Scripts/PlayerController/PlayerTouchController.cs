using UnityEngine;

public class PlayerTouchController : MonoBehaviour
{
    [Header("Smoothness Parameters")]
    public float sensitivity;  // Increased sensitivity for responsiveness
    public float smoothTime;  // Reduced smooth time for quicker response

    [Header("Target Path")]
    public GameObject pathInner;

    private float minPathX;
    private float maxPathX;
    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    private void Start()
    {
        SetPathBounds();
        targetPosition = transform.position;
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

        if (touch.phase == TouchPhase.Began)
        {
            targetPosition = transform.position;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            float moveDelta = touch.deltaPosition.x / Screen.width * sensitivity;

            targetPosition = new Vector3(
                Mathf.Clamp(targetPosition.x + moveDelta, minPathX, maxPathX),
                transform.position.y,
                transform.position.z  // Ensure z position remains constant
            );
        }

        // Smoothly move the player towards the target position
        targetPosition.z = transform.position.z;  // Explicitly maintain the z position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
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
