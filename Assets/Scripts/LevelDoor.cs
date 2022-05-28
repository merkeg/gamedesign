using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public int NeededFeathers = 0;
    [SerializeField]
    public int LevelToLoad = -1;
    public TMPro.TMP_Text text;

    public Sprite onSprite;
    private bool PlayerIsAtTheDoor = false;

    public float errorMessageTime = 2.5f;
    private float errorMessageTimer = 2.5f;
    public string errorMessage = "You need {0} more feathers!";

    public GameObject eText;
    private float EelaspedTime = 0;
    private float ETimeToShow = 2;

    public TMPro.TMP_Text FeatherCountText;
    public int FeatherInTHisLevel = -1;
    public GameObject FeatherIcon;

    // Start is called before the first frame update
    void Start()
    {
        if(this.LevelToLoad < 0)
        {
            throw new System.Exception("Missing Level to load");
        }

        this.FeatherIcon.SetActive(false);
        this.FeatherCountText.gameObject.SetActive(false);

        //this.text.text = GameManager.Instance.getPesistentFeatherCount() +"/"+ this.NeededFeathers;
        this.text.text = "Level " + (this.LevelToLoad);
        if(GameManager.Instance.getPesistentFeatherCount() >= this.NeededFeathers)
        {
            this.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = this.onSprite;
            this.transform.GetChild(2).gameObject.SetActive(true);
            if(GameManager.Instance.GetFeatherCountForLevel(this.LevelToLoad) >= 0)
            {
                this.FeatherCountText.text = string.Format("{0} of {1}", GameManager.Instance.GetFeatherCountForLevel(this.LevelToLoad), this.FeatherInTHisLevel);
                this.FeatherIcon.SetActive(true);
                this.FeatherCountText.gameObject.SetActive(true);
            }
        }

        eText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.PlayerIsAtTheDoor)
        {
            this.EelaspedTime += Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameManager.Instance.getPesistentFeatherCount() >= this.NeededFeathers)
                {
                    GameManager.Instance.LoadLevel(this.LevelToLoad);
                }else {
                    this.text.text = string.Format(this.errorMessage, this.NeededFeathers - GameManager.Instance.getPesistentFeatherCount());
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

        this.errorMessageTimer += Time.deltaTime;
        if (this.errorMessageTimer >= this.errorMessageTime)
        {
            this.errorMessageTimer = 0f;
            this.text.text = "Level " + (this.LevelToLoad);
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
