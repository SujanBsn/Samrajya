using UnityEngine;
using UnityEngine.UI;

public class SoundSliderHandler : MonoBehaviour, ISliderAction
{
    [Header("Slider")]
    public Slider volumeSlider;

    [Header("Audio Source")]
    public AudioSource soundSource;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        soundSource.volume = value;
    }
}
