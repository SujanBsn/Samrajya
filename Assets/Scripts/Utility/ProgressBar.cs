using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    ParticleSystem particles;

    public float fillSpeed = 0.5f;

    float targetProgress = 0;

    private void Start()
    {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;

            if (particles != null && particles.isStopped)
            {
                particles.Play();
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
