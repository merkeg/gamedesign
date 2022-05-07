using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CorruptSun : MonoBehaviour
{
    public float TimeToBOOM;
    public GameObject explosion;
    private bool idontfuckingknwoanamenameityourselfyoufuckingidiot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.idontfuckingknwoanamenameityourselfyoufuckingidiot)
            {
                Debug.Log("Floppa");
                Invoke("Explode", this.TimeToBOOM);
                this.idontfuckingknwoanamenameityourselfyoufuckingidiot = false;
            }
        }
    }

    private void Explode()
    {
        Instantiate(this.explosion, this.transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }
}
