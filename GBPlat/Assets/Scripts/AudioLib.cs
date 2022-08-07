using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLib : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public AudioClip electro;
    public AudioClip car;
    public AudioClip falling;
    public AudioClip charge;

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayOnce(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }
}
