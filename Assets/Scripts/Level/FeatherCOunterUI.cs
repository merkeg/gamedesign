using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCOunterUI : MonoBehaviour
{
    public string stringy= "{0} of {1}";
    public int feathersInLevel = -1;
    public TMPro.TMP_Text text;

    public RectTransform counter;

    public float midTime = 1f;
    private float midTimeCOunter;

    private Vector3 startPos = new Vector3(718, -374, 0);
    private Vector3 endPos = new Vector3(400, -225, 0);

    public float startScale = 2f;
    public float Tscale = 0.5f;
    private float t = 0;

    private Vector3 iAmLazy;
    // Start is called before the first frame update
    void Start()
    {
        if(this.feathersInLevel < 0)
        {
            throw new System.Exception("TIMO");
        }
        this.counter.anchoredPosition = startPos;
        //this.iAmLazy = this.counter.localScale *= startScale;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format(this.stringy, GameManager.Instance.GetFeatherCountCurrentLevel(), this.feathersInLevel);
        this.midTimeCOunter += Time.deltaTime;
        if(this.midTime <= this.midTimeCOunter)
        {
            t += Time.deltaTime * this.Tscale;
            this.counter.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
            // this.counter.localScale = Vector3.Lerp(iAmLazy, Vector3.one, t); Scaling fucks us
        }
    }
}
