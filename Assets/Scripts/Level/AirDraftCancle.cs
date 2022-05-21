using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDraftCancle : MonoBehaviour
{
    public float SecsDisabeled = 1f;
    private float SecsDisabeledCounter = 0;
    private AirUpDraft airUpDraft;
    private bool RunTimer = false;
    private bool playerOn = false;

    public float timeOn = 0.5f;
    private float timeOnCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.airUpDraft = this.transform.parent.gameObject.GetComponent<AirUpDraft>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.playerOn)
        {
            this.timeOnCounter += Time.deltaTime;
        }
        if(this.timeOnCounter >= this.timeOn)
        {
            this.RunTimer = true;
            this.airUpDraft.enableSlefMade = false;
            Debug.Log("Timer Start");
            this.timeOnCounter = 0;
        }

        if(this.RunTimer)
        {
            this.SecsDisabeledCounter += Time.deltaTime;
        }

        if(this.SecsDisabeledCounter >= this.SecsDisabeled)
        {
            this.airUpDraft.enableSlefMade = true;
            this.RunTimer = false;
            this.SecsDisabeledCounter = 0;
            Debug.Log("Timer Stop");
            if(this.playerOn)
            {
                this.RunTimer = true;
                this.airUpDraft.enableSlefMade = false;
                Debug.Log("Timer Start");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if(other.gameObject.tag == "Player")
        {
            this.playerOn = true;
            if(other.gameObject.transform.position.y < this.transform.position.y)
            {
                this.RunTimer = true;
                this.airUpDraft.enableSlefMade = false;
                Debug.Log("Timer Start");
            }
            else
            {
                Debug.Log("L");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.playerOn = false;
            this.timeOnCounter = 0;
        }
    }
}
