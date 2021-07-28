using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, Random.Range(-200,-1350));
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().localPosition.y < -1500)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(gameObject);
        }
    }
}
