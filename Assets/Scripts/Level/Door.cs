using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int feathersNeeded = 0;
    private bool PlayerIsAtTheDoor = false;

    public TMPro.TMP_Text text;
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
                if (GameManager.Instance.GetFeatherCountCurrentLevel() >= this.feathersNeeded)
            {
                GameManager.Instance.LevelEndReached();
                GameManager.Instance.LoadHub();
            }
            }
        }

        this.text.text = GameManager.Instance.GetFeatherCountCurrentLevel() +"/"+ this.feathersNeeded;
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
