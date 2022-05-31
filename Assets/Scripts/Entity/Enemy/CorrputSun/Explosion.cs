using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Schoppa");
        Invoke("bye", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Whoppa");
            other.gameObject.GetComponent<Entity.Damageable>().TakeDamage(this.Damage);
            other.gameObject.GetComponent<PlayerHit>().Hit();
        }
    }

    private void bye()
    {
        GameObject.Destroy(this.gameObject);
    }
}
