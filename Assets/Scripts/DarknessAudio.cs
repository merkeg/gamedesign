using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAudio : MonoBehaviour
{
    public AudioSource darknessSource;
    public AudioSource heartbeatSource;
    public AudioClip heartbeat;

    private VignetteInterface vignette;

    private void Start()
    {
        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    private void Update()
    {
        this.darknessSource.volume = this.vignette.GetIntensity() / 4;

        // Play Heartbeat sound moments before death
        if (this.vignette.GetIntensity() >= 0.75f && !this.heartbeatSource.isPlaying)
        {
            this.heartbeatSource.PlayOneShot(this.heartbeat);
        }
    }
}
