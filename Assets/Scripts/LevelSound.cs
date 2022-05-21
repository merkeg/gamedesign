using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    public AudioClip caveAtmo;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        // Start the cave atmo
        caveAtmo.LoadAudioData();
        source.loop = true;
        source.PlayOneShot(caveAtmo);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
