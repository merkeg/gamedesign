using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cam; // Camera reference (of its transform)
	Vector3 previousCamPos;

    public float SecsTillReset = 2f;
    private float resetCounter = 0;
    private Vector3 startPos;

	public float speedX = 0f; // Distance of the item (z-index based) 
	public float speedY = 0f;


    private SpriteRenderer spriteRendere;

	void Awake () {
		cam = Camera.main.transform;
        this.spriteRendere = this.gameObject.GetComponent<SpriteRenderer>();
        this.startPos = this.transform.position;
	}
	
	void Update () {
        if(this.spriteRendere.isVisible)
        {
            if (speedX != 0f) {
                float parallaxX = (previousCamPos.x - cam.position.x) * speedX;
                Vector3 backgroundTargetPosX = new Vector3(transform.position.x + parallaxX, 
                                                        transform.position.y, 
                                                        transform.position.z);
                
                // Lerp to fade between positions
                transform.position = Vector3.Lerp(transform.position, backgroundTargetPosX, 1);
            }

            if (speedY != 0f) {
                float parallaxY = (previousCamPos.y - cam.position.y) * speedY;
                Vector3 backgroundTargetPosY = new Vector3(transform.position.x, 
                                                        transform.position.y + parallaxY, 
                                                        transform.position.z);
                
                transform.position = Vector3.Lerp(transform.position, backgroundTargetPosY, 1);
            }
            this.resetCounter = 0;
        }
        else
        {
            this.resetCounter += Time.deltaTime;
            if(this.resetCounter >= this.SecsTillReset)
            {
                this.transform.position = this.startPos;
            }
        }

		previousCamPos = cam.position;
	}
}
