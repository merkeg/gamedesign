using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;

public class HandExplosion : MonoBehaviour
{
    public bool PlayerInRange = false;

    public float Speed = 2f;
    public float addedDrag = 0.2f;

    private Vector3 startPos;
    private GameObject player;

    private PlayerMovement playerMovement;
    private Damageable playerDamage;

    private bool touchingPlayer = false;

    public float secsTillBoom = 1f;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.transform.position;
        this.player = GameObject.Find("Player");
        this.playerMovement = this.player.GetComponent<PlayerMovement>();
        this.playerDamage = this.player.GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.PlayerInRange)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.transform.position, this.Speed * Time.deltaTime);
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.startPos, this.Speed * Time.deltaTime);
        }

        if(this.touchingPlayer)
        {
            this.secsTillBoom -= Time.deltaTime;
        }

        if(this.secsTillBoom <= 0)
        {
            this.Boom();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerMovement.AirDrag += this.addedDrag;
            this.playerMovement.GroundDrag += this.addedDrag;
            this.touchingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerMovement.AirDrag -= this.addedDrag;
            this.playerMovement.GroundDrag -= this.addedDrag;
            this.touchingPlayer = false;
            this.secsTillBoom = 0;
        }
    }

    private void Boom()
    {
        // if(this.touchingPlayer)
        // {
        //     this.playerMovement.AirDrag -= this.addedDrag;
        //     this.playerMovement.GroundDrag -= this.addedDrag;
        //     this.touchingPlayer = false;
        // }

        Instantiate(this.explosion, this.transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }
}
