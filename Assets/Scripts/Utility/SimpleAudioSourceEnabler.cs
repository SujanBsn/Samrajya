using UnityEngine;

public class SimpleAudioSourceEnabler : MonoBehaviour
{
    public AudioSource audioSource;
    public void EnableAudioSource()
    {
        audioSource.UnPause();
        audioSource.enabled = true;
    }
}
