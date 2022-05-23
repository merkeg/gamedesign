using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAnimationFollow : MonoBehaviour
{
    public Transform darknessMask;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.darknessMask.position;
        Vector3 newScale = new Vector3(Mathf.Abs(this.darknessMask.localScale.x * this.player.localScale.x), this.darknessMask.localScale.y * this.player.localScale.y, 1);
        this.transform.localScale = newScale;
    }
}
