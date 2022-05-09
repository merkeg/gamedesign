using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;

    public float minZoom = 12;
    public float darkZoomBuffer = 3;
    public float darkZoomScale = 0.5f;

    public float darknessIntesityScale = 0.5f;

    public static float defaulZoom = 17;
    private float desiredZoom = 17;

    private VignetteInterface vignette;

    private int currentPrio = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.vignette = FindObjectOfType<VignetteInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.player.position.x, this.player.position.y, this.transform.position.z);

        

        this.zoom();        
    }

    private void zoom()
    {
        this.trySetDiseredZoom(defaulZoom, 0, 0);

        float darkZoom = (1 - this.vignette.GetIntensity() * this.darknessIntesityScale) * defaulZoom;
        darkZoom += this.darkZoomBuffer;
        if(darkZoom < defaulZoom)
        {
            if(darkZoom < this.minZoom)
            {
                darkZoom = this.minZoom;
            }
            this.trySetDiseredZoom(darkZoom, 0, 0);
        }

        Camera.main.orthographicSize += (desiredZoom - Camera.main.orthographicSize) * Time.deltaTime;
    }

    // prio is checked, to see if we can override the zoom. prioAfter is the new value the prio will take after setting the desired prio (So we can actually bring it down)
    public void trySetDiseredZoom(float desiredZoom, int prio, int prioAfter)
    {
        if(prio >= this.currentPrio)
        {
            this.desiredZoom = desiredZoom;
            this.currentPrio = prioAfter;
        }
    }


}
