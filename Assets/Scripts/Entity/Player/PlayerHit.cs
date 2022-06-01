using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHit : MonoBehaviour
{
    public Transform Mask;
    public GameObject Vin;
    private Vector3 startSize;
    private float t = 0;
    public float vignetteSpeed = 5;
    private bool hitVinette = false;

    private Vector3 end = new Vector3(8, 8, 1);
    // Start is called before the first frame update
    void Start()
    {
        this.startSize = Mask.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if(this.hitVinette)
        {
            t += Time.deltaTime * this.vignetteSpeed;

            if(t >= 1)
            {
                this.hitVinette = false;
            }
        }
        else
        {
            t -= Time.deltaTime * this.vignetteSpeed;
        }

        if(t < 0)
        {
            t = 0;
        }

        if(t == 0)
        {
            this.Vin.SetActive(false);
        }
        else
        {
            this.Vin.SetActive(true);
        }
        this.Mask.localScale = Vector3.Lerp(startSize, end, t);
    }

    public void Hit()
    {
        //Play Hit Sound

        this.hitVinette = true;
    }
}
