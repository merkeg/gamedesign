using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int feathersNeeded = 0;
    private bool PlayerIsAtTheDoor = false;

    private SpriteRenderer rendere;
    public Sprite onSprite;
    bool on = false;

    public TMPro.TMP_Text text;

    public GameObject eText;
    private float EelaspedTime = 0;
    private float ETimeToShow = 2;

    public Sprite mapSprite;
    private Map map;
    // Start is called before the first frame update
    void Start()
    {
        this.rendere = this.gameObject.GetComponent<SpriteRenderer>();
        this.map = GameObject.Find("MapContainer").transform.GetChild(0).GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.on && GameManager.Instance.GetFeatherCountCurrentLevel() >= this.feathersNeeded)
        {
            this.rendere.sprite = this.onSprite;
            this.on = true;
        }

        if(this.PlayerIsAtTheDoor)
        {
            if(Input.GetKeyDown(KeyCode.M) && !this.map.isOpen)
            {
                this.map.Open(this.mapSprite);
            }

            this.EelaspedTime += Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.Instance.GetFeatherCountCurrentLevel() >= this.feathersNeeded)
                {
                 GameManager.Instance.LevelEndReached();
                    GameManager.Instance.LoadHub();
                }
            }
        }
        else
        {
            this.EelaspedTime = 0;
        }

        if(this.EelaspedTime >= this.ETimeToShow)
        {
            eText.SetActive(true);
        }
        else
        {
            eText.SetActive(false);
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
            if(this.map.isOpen)
            {
                this.map.Close();
            }
        }
    }
}
