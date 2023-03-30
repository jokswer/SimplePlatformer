using UnityEngine;

public class BackgroundMusicService : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void SetMusicEnabled(bool value)
    {
        _audioSource.enabled = value;
    }

    public void SetVolume(float value)
    {
        _audioSource.volume = value;
    }
}