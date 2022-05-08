using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hammond : MonoBehaviour
{
    public float speed = 20;
    public float chargeSpeed = 50;

    public float Damage = 0.15f;

    [Header("Dedection")]
    public float groundDedectionlength = 1.5f;
    public Transform GroundDecetion;
    public LayerMask GroundLayer;
    public Transform WallDedection;
    public float wallDedectionLength = 0.1f;

    public float CharingDedectionLengt = 5; 
    public Transform CharingDedection;
    public LayerMask PlayerLayer;

    public bool DebugDraw = false;

    public bool PlayerInRangeToJump = false;
    public float JumpCD = 2;
    private float JumpCDCounter = 2;
    public float JumpForceX = 50;
    public float JumpForceY = 20;

    private Rigidbody2D rb;

    private bool Charing = false;
    private bool WaitingOnEdge = false;
    private Entity.Damageable playerDmg;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.playerDmg = GameObject.Find("Player").GetComponent<Entity.Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        this.WaitingOnEdge = false;
        RaycastHit2D ground = Physics2D.Raycast(this.GroundDecetion.position, Vector2.down, this.groundDedectionlength, this.GroundLayer);
        if(ground.collider == null)
        {
            if(this.Charing)
            {
                this.WaitingOnEdge = true;
            }
            else
            {
                //Debug.Log("Ground");
                this.Rotate();
            }
        }

        RaycastHit2D wall = Physics2D.Raycast(this.WallDedection.position, Vector2.right, this.wallDedectionLength, this.GroundLayer);
        if(wall.collider != null)
        {
            //Debug.Log("Wall");
            this.Rotate();
        }

        RaycastHit2D charing = Physics2D.Raycast(this.CharingDedection.position, Vector2.right * this.transform.localScale.x, this.CharingDedectionLengt, this.PlayerLayer);
        if(charing.collider != null && charing.collider.tag == "Player")
        {
            this.Charing = true;
        }
        else
        {
            this.Charing = false;
        }

        if(this.PlayerInRangeToJump && this.JumpCDCounter <= 0)
        {
            this.rb.AddForce(new Vector2(this.JumpForceX, this.JumpForceY), ForceMode2D.Impulse);
            this.JumpCDCounter = this.JumpCD;
        }
        this.JumpCDCounter -= Time.deltaTime;
        this.DmgCdCounter -= Time.deltaTime;

        if(DebugDraw)
        {
            Debug.DrawRay(this.GroundDecetion.position, Vector3.down * this.groundDedectionlength, Color.green, 0);
            Debug.DrawRay(this.CharingDedection.position,Vector2.right * this.CharingDedectionLengt * this.transform.lossyScale.x, Color.green, 0);
            Debug.DrawRay(this.WallDedection.position, Vector3.right * this.wallDedectionLength, Color.cyan, 0);
        }
    }

    void FixedUpdate()
    {
        if(this.Charing)
        {
            if(this.WaitingOnEdge == false)
            {
                this.rb.AddForce(new Vector2(this.chargeSpeed, 0), ForceMode2D.Force);
            }
            else if(this.rb.velocity.magnitude > 0.5f) // Breake so we dont run over the edge
            {
                this.rb.AddForce(new Vector2(-this.chargeSpeed, 0), ForceMode2D.Force);
            }
        }else
        {
            this.rb.AddForce(new Vector2(this.speed, 0), ForceMode2D.Force);
        }
    }

    private void Rotate()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * - 1, this.transform.localScale.y, this.transform.localScale.z);
        this.speed *= -1;
        this.chargeSpeed *= -1;
        this.JumpForceX *= -1;
        this.wallDedectionLength *= -1;
    }

    private float DmgCd = 2;
    private float DmgCdCounter = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(DmgCdCounter <= 0)
            {
                this.playerDmg.TakeDamage(this.Damage);
                GameObject.Destroy(this.gameObject);
                this.DmgCdCounter = DmgCd;
            }
        }
    }
}
