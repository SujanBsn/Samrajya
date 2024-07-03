using System.Collections;
using TMPro;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    public TextMeshProUGUI fpsDisplay;

    public float pollingTime;
    public float time;
    public int frameCount;
    public int targetFrameRate;

    private void Start()
    {
        pollingTime = 1f;
        targetFrameRate = 0;
    }


    private void Update()
    {
        Application.targetFrameRate = targetFrameRate;
        time += Time.deltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsDisplay.text = frameRate.ToString() + " FPS";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}