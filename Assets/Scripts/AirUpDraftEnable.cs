using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirUpDraftEnable : MonoBehaviour
{
    public Transform airUpDraft;
    public Collider2D airUpDraftEnabler;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            airUpDraft.gameObject.SetActive(true);
            airUpDraftEnabler.enabled = false;
        }
    }
}
