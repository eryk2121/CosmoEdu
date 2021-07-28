using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerUp : MonoBehaviour
{
    private void Update()
    {
        if (Pause.pause)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 8.5f);
        }
    }
}
