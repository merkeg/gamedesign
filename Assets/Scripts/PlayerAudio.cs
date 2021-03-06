using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip chute;
    public AudioClip cape;
    public AudioClip jump;
    public AudioClip damage;
    public bool InAir { get; set; }

    public void playCape()
    {
        source.PlayOneShot(cape);
    }

    public void playChute()
    {
        source.PlayOneShot(chute);
    }

    public void playJump()
    {
        source.PlayOneShot(jump);
    }

    public void playDamage()
    {
        source.PlayOneShot(damage);
    }

    public bool isPlaying()
    {
        return source.isPlaying;
    }
}
