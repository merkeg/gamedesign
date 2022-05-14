using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteInterface : MonoBehaviour
{
    public VolumeProfile VolumeProfile;
    private Vignette _vignette;

    public Transform mask;

    public float size;

    public float masxSize = 40;

    //public AnimationCurve plot = new AnimationCurve();

    void Start()
    {
        //VolumeProfile.TryGet<Vignette>(out _vignette);

        //_vignette.intensity.overrideState = true;

        Debug.Log(Camera.main.aspect);

        this.size = this.masxSize;
    }

    public void Update()
    {
        if(this.size < 0)
        {
            this.size = 0;
        }
        else if(this.size > this.masxSize)
        {
            this.size = masxSize;
        }
        Vector3 newScale = new Vector3(Camera.main.aspect * 15,15, 1);
        newScale = newScale * size;
        this.mask.localScale = newScale;
        //Debug.Log(this.mask.localScale);
        //plot.AddKey(Time.timeSinceLevelLoad, this.GetIntensity());
    }

    public void AddVignetteValue(float intensity)
    {
        if(this.size <= this.masxSize * 2/3 && this.size >= this.masxSize * 1/3)
        {
            Debug.Log("YES");
            intensity = intensity / 2;
        }

        this.size = this.size - this.masxSize * intensity;
    }

    public float GetIntensity()
    {
        return 1 - this.size / this.masxSize;
    }




}
