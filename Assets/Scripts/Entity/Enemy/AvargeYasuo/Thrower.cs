using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float trhowCD = 4;
    private float throwCdCounter = 1;

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
            Instantiate(this.Timo, this.pos.position, Quaternion.identity);
            this.throwCdCounter = this.trhowCD;
        }

        this.throwCdCounter -= Time.deltaTime;
    }
}
