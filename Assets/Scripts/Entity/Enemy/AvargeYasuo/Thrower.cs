using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float trhowCD = 4;
    public float throwCdCounter = 1;

    public float ImpulseForceX = 25;
    public float ImpulseForceY = 10;
    public float gravityScale = 1f;

    public Transform pos;
    public GameObject Timo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.throwCdCounter <= 0)
        {
            GameObject timo =  Instantiate(this.Timo, this.pos.position, Quaternion.identity);
            Timo timeScrupt = timo.GetComponent<Timo>();
            timeScrupt.setForce(this.ImpulseForceX, this.ImpulseForceY);
            timeScrupt.gravityScale = this.gravityScale;
            
            this.throwCdCounter = this.trhowCD;
        }

        this.throwCdCounter -= Time.deltaTime;
    }
}
