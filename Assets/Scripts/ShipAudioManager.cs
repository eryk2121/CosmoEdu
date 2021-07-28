using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudioManager : MonoBehaviour
{
    public AudioClip meteorCollision;
    public AudioClip rocketStart;

    public void PlayMeteorCollision()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = meteorCollision;
        audio.Play();
    }

    public void RocketStart()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = rocketStart;
        audio.Play();
    }
}
