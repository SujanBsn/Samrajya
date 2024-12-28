using UnityEngine;

public class SimpleFPSTarget : MonoBehaviour
{
    [Tooltip("Set the target frame rate for the application.")]
    [SerializeField] 
    private int targetFPS = 60;

    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = targetFPS;

        // Optional: Adjust the VSync count (0 disables VSync)
        QualitySettings.vSyncCount = 0;
    }

    void OnValidate()
    {
        // Ensure the target FPS is not set to a negative value
        if (targetFPS < 1)
        {
            targetFPS = 1;
            Debug.LogWarning("Target FPS cannot be less than 1. Setting to 1.");
        }
    }
}
