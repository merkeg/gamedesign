using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightGiver : MonoBehaviour
{
    private VignetteInterface vignette;
    private bool playerInLightGiver = false;
    // Start is called before the first frame update
    void Start()
    {
        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.playerInLightGiver)
        {
            this.vignette.AddVignetteValue(-1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerInLightGiver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerInLightGiver = false;
        }
    }
}
