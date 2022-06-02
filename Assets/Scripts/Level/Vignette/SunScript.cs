using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public int SunID = -1;

    public float RespawnTime = 30f;
    private VignetteInterface vignette;
    public AudioClip PickupSound;
    public float PickupSoundScale = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        if(this.SunID < 0)
        {
            throw new System.Exception("Sun has no ID");
        }

        GameManager.Instance.SunAllowedToExist(this.gameObject, this.SunID);

        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerAudio>().source.PlayOneShot(PickupSound, PickupSoundScale);
            GameManager.Instance.CollectSun(this.SunID);
            this.vignette.AddVignetteValue(-0.75f);
            Invoke("Reactivate", this.RespawnTime);
            this.gameObject.SetActive(false);
        }
    }

    private void Reactivate()
    {
        this.gameObject.SetActive(true);
    }
}
