using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShinyText : MonoBehaviour
{
    public Text[] texts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float counter = 160; //zmienna odpowiadająca maksymalnej wartości pokolorowanego tekstu
    bool raise = true; // zmienna odpowiadająca czy wartość koloru ma rosnąć bądź maleć

    // Update is called once per frame
    void Update()
    {

        foreach (Text t in texts)
        {
            t.color = new Color32 ((byte)(t.color.r*255), (byte)(t.color.g*255), (byte)(t.color.b*255), (byte)counter);
            t.GraphicUpdateComplete();
        }

        if (raise)
        {
            counter += 0.5f;
            if (counter == 250)
            {
                raise = false;
            }
        }
        else
        {
            counter-= 0.5f;
            if (counter == 80)
            {
                raise = true;
            }
        }
    }
}
