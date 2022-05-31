using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public bool isOpen = false;
    public Image image;
    public float Tscale = 1;
    private float t = 0;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(this.t < 0)
        {
            this.t = 0;
        }
        else if(this.t > 1)
        {
            this.t = 1;
        }

        if(this.isOpen)
        {
            t += Time.deltaTime * this.Tscale;
            this.image.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.Close();
            }
        }
        else
        {
            t -= Time.deltaTime * this.Tscale;
            this.image.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            if(this.image.transform.localScale.magnitude == 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Open(Sprite mapSprite)
    {
        this.isOpen = true;
        this.image.sprite = mapSprite;
        this.image.transform.localScale = Vector3.zero;
        this.t = 0;
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.isOpen = false;
    }
}
