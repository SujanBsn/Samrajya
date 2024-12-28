using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    float accumulatedDeltaTime = 0.0f; // Accumulated delta time for the interval
    int frameCount = 0; // Number of frames in the current interval
    float displayFPS = 0.0f; // Average FPS to display
    float updateInterval = 0.25f; // Update interval in seconds
    float timer = 0.0f; // Timer to track time elapsed since last update

    void Update()
    {
        // Accumulate delta time and count frames
        accumulatedDeltaTime += Time.deltaTime;
        frameCount++;

        // Update the timer
        timer += Time.deltaTime;

        // Update the displayed FPS only after the specified interval
        if (timer >= updateInterval)
        {
            // Calculate average FPS
            displayFPS = frameCount / accumulatedDeltaTime;

            // Reset for the next interval
            timer = 0.0f;
            accumulatedDeltaTime = 0.0f;
            frameCount = 0;
        }
    }

    void OnGUI()
    {
        // Get the safe area and adjust position
        Rect safeArea = Screen.safeArea;
        Rect adjustedRect = new Rect(
            safeArea.x + 50,                  // 10 pixels from the left edge of the safe area
            safeArea.y + 50,                  // 10 pixels from the top edge of the safe area
            400,                              // Width of the display
            100                               // Height of the display
        );

        // Set up the style for the display
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = 64;
        style.normal.textColor = Color.white;

        // Display FPS
        string text = $"FPS: {displayFPS:0.}";
        GUI.Label(adjustedRect, text, style);
    }
}
