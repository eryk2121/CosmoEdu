using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePowerUp : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 8.5f);
        if (GetComponent<RectTransform>().localPosition.y < -1500)
        {
            Destroy(this.gameObject);
        }
    }
}
