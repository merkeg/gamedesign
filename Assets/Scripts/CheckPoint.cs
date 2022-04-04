using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private VignetteInterface vignette;
    private bool playerOnCheckpoint = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector3? checkpoint = GameManager.Instance.GetCheckPoint();
        if(checkpoint != null)
        {
            GameObject.Find("Player").transform.position = (Vector3)checkpoint;
        }
        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.playerOnCheckpoint)
        {
            this.vignette.AddVignetteValue(-1f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.CheckpointReached(this.transform.position);
            this.playerOnCheckpoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerOnCheckpoint = false;
        }
    }
}
