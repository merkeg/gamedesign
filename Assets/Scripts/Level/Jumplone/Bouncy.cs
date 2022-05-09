using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float JumpForce = 30;

    private bool playerOnJumpPad = false;
    private Rigidbody2D playerBody;
    private PlayerMovement playerMovement;
    private bool jumpedLastFrame = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player"); 
        this.playerBody = player.GetComponent<Rigidbody2D>();
        this.playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.jumpedLastFrame)
        {
            this.playerMovement.ResetJumpCounter();
            this.jumpedLastFrame = false;
            Debug.Log("___");
            Debug.Log("3");
            return;
        }
        if(this.playerOnJumpPad)
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.playerBody.velocity = new Vector2(this.playerBody.velocity.x, this.JumpForce);
                //this.playerBody.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
                this.playerMovement.SetJumpCounter(0);
                this.jumpedLastFrame = true;
                Debug.Log("2");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerOnJumpPad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerOnJumpPad = false;
        }
    }
}
