using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("GroundMovement")]
    public float GroundMoveSpeed = 10;
    public float GroundDrag = 2;
    public float maxGroundVelocityFromInput = 100000;

    [Header("AirMovement")]
    public float AirMoveSpeed = 10;
    public float AirDrag = 1;
    public float maxAirVelocityFromInput = 100000;

    [Header("JumpAndGlide")]
    public float JumpForce = 10;
    public float jumpVelocityYScale = 1;
    public float glideGravityScale = 0.5f;

    [Header("GroundDedection")]
    public Transform topLeft;
    public Transform bottomRight;
    public LayerMask groundLayer;

    private Vector2 moveDirection;
    private bool isGrounded;
    private Rigidbody2D playerBody;
    private int jumpCounter = 1;

    private Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        this.playerBody = this.GetComponent<Rigidbody2D>();

        this.localScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        this.moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if(this.moveDirection.x > 0)
        {
            this.transform.localScale = this.localScale;
        }
        else if(this.moveDirection.x < 0)
        {
            this.transform.localScale = new Vector3(this.localScale.x * -1, this.localScale.y, this.localScale.z);
        }

        this.jump();
    }

    // Override Fixed Update
    private void FixedUpdate()
    {
        this.isGrounded = Physics2D.OverlapArea(this.topLeft.position, this.bottomRight.position, this.groundLayer);

        this.setDrag();
        this.glide();
        this.move();
    }

    private void setDrag()
    {
        if (this.isGrounded)
        {
            this.playerBody.drag = this.GroundDrag;
            this.jumpCounter = 1;
        }
        else
        {
            this.playerBody.drag = this.AirDrag;
        }
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(this.isGrounded)
            {
                if(this.playerBody.velocity.y < 0)
                {
                    this.playerBody.velocity = new Vector2(this.playerBody.velocity.x, this.playerBody.velocity.y * this.jumpVelocityYScale);
                }
                this.playerBody.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
            } 
            else if (this.jumpCounter > 0) {
                if(this.playerBody.velocity.y < 0)
                {
                    this.playerBody.velocity = new Vector2(this.playerBody.velocity.x, this.playerBody.velocity.y * this.jumpVelocityYScale);
                }
                this.playerBody.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
                this.jumpCounter--;
            }
        }
    }

    private void move()
    {
        if(this.isGrounded)
        {
            this.groundMove();
        }
        else
        {
            this.airMove();
        }
    }

    private void airMove()
    {
        if(this.moveDirection.x > 0)
        {
            //move right
            if(this.playerBody.velocity.x < this.maxAirVelocityFromInput)
            {
                //velocity.x is still smaller, than max
                this.playerBody.AddForce(this.moveDirection * this.AirMoveSpeed, ForceMode2D.Force);
            }
        }
        else if(this.moveDirection.x < 0)
        {
            //move left
            if(this.playerBody.velocity.x > -this.maxAirVelocityFromInput)
            {
                //velocity.x is still bigger, tham min (-max)
                this.playerBody.AddForce(this.moveDirection * this.AirMoveSpeed, ForceMode2D.Force);
            }
        }
    }

    private void groundMove()
    {
        if(this.moveDirection.x > 0)
        {
            //move right
            if(this.playerBody.velocity.x < this.maxGroundVelocityFromInput)
            {
                //velocity.x is still smaller, than max
                this.playerBody.AddForce(this.moveDirection * this.GroundMoveSpeed, ForceMode2D.Force);
            }
        }
        else if(this.moveDirection.x < 0)
        {
            //move left
            if(this.playerBody.velocity.x > -this.maxGroundVelocityFromInput)
            {
                //velocity.x is still bigger, tham min (-max)
                this.playerBody.AddForce(this.moveDirection * this.GroundMoveSpeed, ForceMode2D.Force);
            }
        }
    }

    private void glide()
    {
        if (Input.GetButton("Jump"))
        {
            this.playerBody.gravityScale = this.glideGravityScale;
        }
        else
        {
            this.playerBody.gravityScale = 1f;
        }
    }
}
