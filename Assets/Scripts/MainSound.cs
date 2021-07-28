using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.mute = !Mute.sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
