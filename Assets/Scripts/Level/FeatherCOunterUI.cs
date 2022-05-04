using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCOunterUI : MonoBehaviour
{
    public string stringy= "Feathers: {0}/{1}";
    public int feathersInLevel = -1;
    public TMPro.TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(this.feathersInLevel < 0)
        {
            throw new System.Exception("TIMO");
        }

    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format(this.stringy, GameManager.Instance.GetFeatherCountCurrentLevel(), this.feathersInLevel);
    }
}
