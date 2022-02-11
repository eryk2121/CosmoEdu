using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudioManager : MonoBehaviour
{
    public AudioClip meteorCollision;
    public AudioClip rocketStart;
    public AudioClip collect;

    public void PlayMeteorCollision()
    {
        if (Mute.sound)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = meteorCollision;
            audio.Play();
        }
    }

    public void RocketStart()
    {
        if (Mute.sound)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = rocketStart;
            audio.Play();
        }
    }
    public void Bonuscollect()
    {
        if (Mute.sound)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = collect;
            audio.Play();
        }


    }
}
