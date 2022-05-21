using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip darkness;

    private VignetteInterface vignette;

    private void Start()
    {
        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    private void Update()
    {
        this.source.volume = this.vignette.GetIntensity() / 4;
    }
}
