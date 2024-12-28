using UnityEngine;

public class SimpleAudioSourceDisabler : MonoBehaviour
{
    public AudioSource audioSource;
    public void DisableAudioSource()
    {
        audioSource.Pause();
        audioSource.clip = null;
        audioSource.enabled = false;
    }
}
