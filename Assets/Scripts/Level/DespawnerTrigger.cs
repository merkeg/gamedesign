using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerTrigger : MonoBehaviour
{
    public string ToDespawn;
    private bool despawn = true;
    // Start is called before the first frame update
    void Start()
    {
        this.despawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.despawn)
            {
                GameObject.Destroy(GameObject.Find(this.ToDespawn));
            }
            this.despawn = false;
        }
    }
}
