using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteInterface : MonoBehaviour
{
    public VolumeProfile VolumeProfile;
    private Vignette _vignette;

    void Start()
    {
        VolumeProfile.TryGet<Vignette>(out _vignette);

        _vignette.intensity.overrideState = true;

    }

    public void ClearVignette()
    {
        _vignette.intensity.value = 0;
    }

    public void SetVignette(float intensity)
    {
        _vignette.intensity.value = intensity;
    }

    public void AddVignetteValue(float intensity)
    {
        SetVignette(_vignette.intensity.value + intensity);
    }

    public void SetVignetteColor(Color color)
    {
        _vignette.color.value = color;
    }

    public float GetIntensity()
    {
        return this._vignette.intensity.value;
    }




}
