using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timo : MonoBehaviour
{
    public float ImpulseForceX = 25;
    public float ImpulseForceY = 10;
    public float gravityScale = 1;
    public float Damage = 0.1f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = this.gravityScale;
        rb.AddForce(new Vector2(this.ImpulseForceX, this.ImpulseForceY), ForceMode2D.Impulse);
        this.rb = rb;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = this.rb.velocity;
        float angle = Vector2.Angle(Vector2.left, v);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Timo")
        {
            return;
        }
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Entity.Damageable>().TakeDamage(this.Damage);
        }

        GameObject.Destroy(this.gameObject);
    }

    public void setForce(float x, float y)
    {
        this.ImpulseForceX = x;
        this.ImpulseForceY = y;
    }
}
