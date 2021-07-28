using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    int dmg = 10;
    int xDirection = 0;

    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(xDirection, -10), ForceMode2D.Impulse);
        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x , gameObject.transform.rotation.y, gameObject.transform.rotation.z + xDirection*6, gameObject.transform.rotation.w);
        if (gameObject.transform.position.y <= -5000)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag.ToString())
        {
            case "Hit":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
            case "Missile":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
        }
    }

    public void SetxDirection(int xDir)
    {
        xDirection = xDir;
    }

    public void SetDmg(int dmg)
    {
        this.dmg = dmg;
    }

    public int GetDmg()
    {
        return dmg;
    }
}
