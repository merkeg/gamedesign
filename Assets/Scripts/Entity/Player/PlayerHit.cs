using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHit : MonoBehaviour
{
    public VolumeProfile VolumeProfile;
    private Vignette _vignette;

    public float vignetteSpeed = 5;
    private bool hitVinette = false;
    // Start is called before the first frame update
    void Start()
    {
        VolumeProfile.TryGet<Vignette>(out _vignette);
        _vignette.intensity.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.hitVinette)
        {
            this._vignette.intensity.value += Time.deltaTime * this.vignetteSpeed;

            if(this._vignette.intensity.value >= 1)
            {
                this.hitVinette = false;
            }
        }
        else
        {
            this._vignette.intensity.value -= Time.deltaTime * this.vignetteSpeed;
        }
    }

    public void Hit()
    {
        //Play Hit Sound

        this.hitVinette = true;
    }
}
