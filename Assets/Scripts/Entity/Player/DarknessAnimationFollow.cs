using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAnimationFollow : MonoBehaviour
{
    public Transform darknessMask;
    public Transform player;
    public Animator animator;
    private VignetteInterface vignette;
    // Start is called before the first frame update
    void Start()
    {
        this.vignette = FindObjectOfType<VignetteInterface>();
        this.animator = this.gameObject.GetComponent<Animator>();
        //this.animator.Play("Base Layer.DarknessLoop1234567432", 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.darknessMask.position;
        Vector3 newScale = new Vector3(Mathf.Abs(this.darknessMask.localScale.x * this.player.localScale.x), this.darknessMask.localScale.y * this.player.localScale.y, 1);
        this.transform.localScale = newScale;

        //Adjust Animation Speed
        float intes = this.vignette.GetIntensity();
        intes =  Mathf.Clamp(intes, 0, 1);
        float temp = 0.25f + 0.75f * intes;
        this.animator.speed = temp;
    }
}
