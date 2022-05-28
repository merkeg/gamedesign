using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AirUpDraft : MonoBehaviour
{
    public float UpDraftForce = 10;
    public float maxVelocity = 40;
    private GameObject player;
    private Rigidbody2D playerBody;
    private PlayerMovement playerMovement;
    private bool pLayerInUpdraft = false;
    private Animator playerAnimatoir;

    private bool hasLock = false;
    private static bool isLocked = false;

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
        
    }

    private void trySetInAirDraft(bool inAirDraft)
    {
        if(AirUpDraft.isLocked && !this.hasLock)
        {
            return;
        }

        AirUpDraft.isLocked = inAirDraft;
        this.hasLock = inAirDraft;
        this.playerAnimatoir.SetBool("InUpDraft", inAirDraft);

    }

    private void FixedUpdate()
    {

        Debug.Log(this.pLayerInUpdraft);
        if(this.pLayerInUpdraft)
        {
            if(Input.GetButton("Jump") || Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log(Time.timeSinceLevelLoad);
                if(this.playerBody.velocity.y <= this.maxVelocity)
                {
                    this.playerBody.AddForce(new Vector2(0, this.UpDraftForce), ForceMode2D.Force);
                }

                trySetInAirDraft(true);
            }
            else
            {
                trySetInAirDraft(false);
            }
        }
        else
        {
            trySetInAirDraft(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.pLayerInUpdraft = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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
