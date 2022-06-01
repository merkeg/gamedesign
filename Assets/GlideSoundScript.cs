using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideSoundScript : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void playGlide()
    {
        audioSource.Play();
    }

    public void stopGlide()
    {
        audioSource.Stop();
    }

    public bool isPlaying()
    {
        return audioSource.isPlaying;
    }
}
