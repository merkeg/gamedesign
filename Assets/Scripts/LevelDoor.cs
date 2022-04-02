using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public int NeededFeathers = 0;
    [SerializeField]
    public UnityEngine.Events.UnityEvent LevelLoad;

    private bool PlayerIsAtTheDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.PlayerIsAtTheDoor)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.LevelLoad.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.PlayerIsAtTheDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.PlayerIsAtTheDoor = false;
        }
    }
    
}
