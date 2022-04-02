using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public int NeededFeathers = 0;
    [SerializeField]
    public int LevelToLoad = -1;

    private bool PlayerIsAtTheDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        if(this.LevelToLoad < 0)
        {
            throw new System.Exception("Missing Level to load");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.PlayerIsAtTheDoor)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameManager.Instance.getPesistentFeatherCount() >= this.NeededFeathers)
                {
                    GameManager.Instance.LoadLevel(this.LevelToLoad);
                }
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
