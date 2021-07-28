﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{

    bool left = true;

    float startX;

    private void Start()
    {
        startX = gameObject.transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (Pause.pause)
        {
            if (left)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y - 5.5f + (1 * GameSpawner.waveLevel));
                if (gameObject.transform.position.x < startX - 80)
                {
                    left = false;
                }
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y - 5.5f + (1 * GameSpawner.waveLevel));

                if (gameObject.transform.position.x > startX + 80)
                {
                    left = true;
                }
            }

            if (GetComponent<RectTransform>().localPosition.y < -1500)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
