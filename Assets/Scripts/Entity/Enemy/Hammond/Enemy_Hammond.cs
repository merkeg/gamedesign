using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hammond : MonoBehaviour
{
    public float speed = 20;
    public float chargeSpeed = 50;

    [Header("Dedection")]
    public float groundDedectionlength = 1.5f;
    public Transform GroundDecetion;
    public LayerMask GroundLayer;

    public float CharingDedectionLengt = 5; 
    public Transform CharingDedection;

    public bool DebugDraw = false;

    private Rigidbody2D rb;

    private bool Charing = false;
    private bool WaitingOnEdge = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D ground = Physics2D.Raycast(this.GroundDecetion.position, Vector2.down, this.groundDedectionlength, this.GroundLayer);
        if(ground.collider == null)
        {
            if(this.Charing)
            {
                this.WaitingOnEdge = true;
            }
            else
            {
                this.WaitingOnEdge = false;
                this.Rotate();
            }
        }

        RaycastHit2D charing = Physics2D.Raycast(this.CharingDedection.position, Vector2.right * this.transform.localScale.x, this.CharingDedectionLengt);
        if(charing.collider != null && charing.collider.tag == "Player")
        {
            this.Charing = true;
        }
        else
        {
            this.Charing = false;
        }

        if(DebugDraw)
        {
            Debug.DrawRay(this.GroundDecetion.position, Vector3.down * this.groundDedectionlength, Color.green, 0);
            Debug.DrawRay(this.CharingDedection.position,Vector2.right * this.CharingDedectionLengt * this.transform.lossyScale.x, Color.green, 0);
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
    }
}
