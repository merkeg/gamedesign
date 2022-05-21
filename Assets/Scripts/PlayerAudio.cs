using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip chute;
    public AudioClip cape;

    public void playCape()
    {
        Debug.Log(cape);
        source.PlayOneShot(cape);
    }

    public void playChute()
    {
        source.PlayOneShot(chute);
    }
}
