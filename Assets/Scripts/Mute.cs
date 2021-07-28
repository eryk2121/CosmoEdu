using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public Image objectS;
    public Sprite soundIco;
    public Sprite muteIco;
    public static bool sound = true;

    public void Mute_UnMute()
    {
        if (sound)
        {
            objectS.sprite = muteIco;
            sound = false;
        }
        else
        {
            objectS.sprite = soundIco;
            sound = true;
        }
    }
}
