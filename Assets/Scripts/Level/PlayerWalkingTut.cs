using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingTut : MonoBehaviour
{
    public GameObject text;
    private Transform player;

    private Vector3 oldPlayerPos;
    private float timeTillShow = 4f;
    private float elaspedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player").transform;
        this.text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.player.transform.position == this.oldPlayerPos)
        {
            this.elaspedTime += Time.deltaTime;
        }
        else
        {
            this.elaspedTime = 0;
            this.oldPlayerPos = this.player.position;
        }

        if(this.elaspedTime >= this.timeTillShow)
        {
            this.text.SetActive(true);
        }
        else
        {
            this.text.SetActive(false);
        }

        this.transform.position = this.player.transform.position;
        this.transform.position += new Vector3(0, 3, 0);
    }
}
