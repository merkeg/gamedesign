using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    private VignetteInterface vignette;
    // Start is called before the first frame update
    void Start()
    {
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
            this.vignette.AddVignetteValue(-0.75f);
            GameObject.Destroy(this.gameObject);
        }
    }
}
