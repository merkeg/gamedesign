using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private VignetteInterface vignette;
    private bool playerOnCheckpoint = false;
    public float zoomOutSize = 20;

    public Sprite mapSprite;
    private Map map;

    private CamController camController;
    // Start is called before the first frame update
    void Start()
    {
        Vector3? checkpoint = GameManager.Instance.GetCheckPoint();
        if(checkpoint != null)
        {
            GameObject.Find("Player").transform.position = (Vector3)checkpoint;
        }
        this.vignette = FindObjectOfType<VignetteInterface>();

        this.camController = GameObject.Find("Main Camera").GetComponent<CamController>();

        this.map = GameObject.Find("MapContainer").transform.GetChild(0).GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.playerOnCheckpoint)
        {
            this.vignette.AddVignetteValue(-1f);

            if(Input.GetKeyDown(KeyCode.E) && !this.map.isOpen)
            {
                this.map.Open(this.mapSprite);
            }   
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.CheckpointReached(this.transform.position);
            this.playerOnCheckpoint = true;
            this.camController.trySetDiseredZoom(this.zoomOutSize, 1, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerOnCheckpoint = false;
            this.camController.trySetDiseredZoom(CamController.defaulZoom, 1, 0);
            if(this.map.isOpen)
            {
                this.map.Close();
            }
        }
    }
}
