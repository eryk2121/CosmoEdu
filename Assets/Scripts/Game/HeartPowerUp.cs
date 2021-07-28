using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{
    private void Update()
    {
        if (Pause.pause)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 8.5f);
            if (GetComponent<RectTransform>().localPosition.y < -1500)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
