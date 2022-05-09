using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirUpDraft : MonoBehaviour
{
    public float UpDraftForce = 10;
    public float maxVelocity = 40;
    private GameObject player;
    private Rigidbody2D playerBody;
    private PlayerMovement playerMovement;
    private bool pLayerInUpdraft = false;
    private Animator playerAnimatoir;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.playerBody = this.player.GetComponent<Rigidbody2D>();
        this.playerMovement = this.player.GetComponent<PlayerMovement>();
        this.playerAnimatoir = this.player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.pLayerInUpdraft)
        {
            if(this.playerMovement.isGlidingKeyDown())
            {
                if(this.playerBody.velocity.y <= this.maxVelocity)
                this.playerBody.AddForce(new Vector2(0, this.UpDraftForce), ForceMode2D.Force);

                this.playerAnimatoir.SetBool("InUpDraft", true);
            }
            else
            {
                this.playerAnimatoir.SetBool("InUpDraft", false);
            }
        }
        else
        {
            this.playerAnimatoir.SetBool("InUpDraft", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.pLayerInUpdraft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.pLayerInUpdraft = false;
        }
    }
}
