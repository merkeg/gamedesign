using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public int SunID = -1;
    private VignetteInterface vignette;
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
            GameManager.Instance.CollectSun(this.SunID);
            this.vignette.AddVignetteValue(-0.75f);
            GameObject.Destroy(this.gameObject);
        }
    }
}
