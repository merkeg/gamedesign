using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float AirMoveSpeed = 10;
    public float GroundMoveSpeed = 10;
    public float AirDrag = 1;
    public float GroundDrag = 2;
    public float JumpForce = 10;
    public float playerHeight = 2;
    public float glideGravityScale = 0.5f;
    public Transform topLeft;
    public Transform bottomRight;

    public LayerMask groundLayer;
    private Vector2 moveDirection;
    private bool isGrounded;
    private Rigidbody2D playerBody;
    private int jumpCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.playerBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (this.isGrounded)
        {
            this.playerBody.drag = this.GroundDrag;
            this.jumpCounter = 1;
        }
        else
        {
            this.playerBody.drag = this.AirDrag;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(this.isGrounded)
            {
                this.playerBody.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
            } else if (this.jumpCounter > 0) {
                this.playerBody.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
                this.jumpCounter--;
            }
        }
    }

    // Override Fixed Update
    private void FixedUpdate()
    {
        this.isGrounded = Physics2D.OverlapArea(this.topLeft.position, this.bottomRight.position, this.groundLayer);
        if(this.isGrounded)
        {
            this.playerBody.AddForce(this.moveDirection * this.GroundMoveSpeed, ForceMode2D.Force);
        }
        else
        {
            this.playerBody.AddForce(this.moveDirection * this.AirMoveSpeed, ForceMode2D.Force);
        }

        if (Input.GetButton("Jump"))
        {
            this.playerBody.gravityScale = 0.5f;
        }
        else
        {
            this.playerBody.gravityScale = 1f;
        }

    }
}
