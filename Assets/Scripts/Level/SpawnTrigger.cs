using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject ToSpawn;
    private bool spawn = true;
    // Start is called before the first frame update
    void Start()
    {
        this.spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.spawn)
            {
                GameObject.Instantiate(ToSpawn);
            }
            this.spawn = false;
        }
    }
}
