using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timo : MonoBehaviour
{
    public float ImpulseForceX = 25;
    public float ImpulseForceY = 10;
    public float Damage = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.ImpulseForceX, this.ImpulseForceY), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
