using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCollect : MonoBehaviour
{
    // Start is called before the first frame update

    public int FeatherId = -1;
    void Start()
    {
        if(this.FeatherId < 0)
        {
            throw new System.Exception("No Feather ID set");
        }

        GameManager.Instance.FeatherAllwoedToExist(this.gameObject, this.FeatherId);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectFeather(this.FeatherId);
            GameObject.Destroy(this.gameObject);
        }
    }
}
