using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffSetSetter : MonoBehaviour
{
    public float offSetY = 8.5f;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<CamController>().offSetY = this.offSetY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
