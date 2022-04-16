using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;

public class EnemyHandArm : MonoBehaviour
{
    
    public bool PlayerInRange = false;

    public float Speed = 2f;

    public float addedDrag = 0.2f;
    public float dmgPerSec = 0.1f;

    [Header("Arm")]
    public GameObject ArmGraphic;
    private SpriteRenderer armSprite;
    public Transform ArmStart;
    public Transform ArmEnd;
    public float armLength = 10f;

    private Vector3 startPos;
    private GameObject player;

    private PlayerMovement playerMovement;
    private Damageable playerDamage;

    private bool touchingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.transform.position;
        this.player = GameObject.Find("Player");
        this.playerMovement = this.player.GetComponent<PlayerMovement>();
        this.playerDamage = this.player.GetComponent<Damageable>();

        this.armSprite = this.ArmGraphic.GetComponent<SpriteRenderer>();
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
            this.playerDamage.TakeDamage(this.dmgPerSec * Time.deltaTime);
        }

        this.SetArm();
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
        }
    }

    private void SetArm()
    {
        Vector3 startToEnd = this.ArmEnd.position - this.ArmStart.position;
        //float angle = Vector3.Angle(Vector3.up, startToEnd);
        float angle = Vector2.Angle(Vector2.up, startToEnd);
        
        if(this.ArmEnd.position.x > this.ArmStart.position.x)
        {
            angle = -angle;
        }

        this.ArmGraphic.transform.eulerAngles = new Vector3(0, 0, angle);
        this.ArmGraphic.transform.position = this.ArmStart.position +  startToEnd / 2;

        this.armSprite.size = new Vector2(this.armSprite.size.x, this.armLength * startToEnd.magnitude);
    }
}
