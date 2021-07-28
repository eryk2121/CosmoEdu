using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private bool finalPosition = false;
    private RectTransform rt;
    public GameObject enenmyMissile;
    public Image bossHealthBar;

    int level = 1;

    private bool left = true;

    private void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {

        if (Pause.pause)
        {
            if (rt.localPosition.y <= 580)
            {
                finalPosition = true;
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.2f);
            }

            if (finalPosition)
            {
                if (!TrySuperShot())
                {
                    TryShoot();
                }

                HorizontalMove();
            }
        }

    }

    private void HorizontalMove()
    {
        if (rt.localPosition.x <= -310)
        {
            left = true;
        }
        else if (rt.localPosition.x >= 310)
        {
            left = false;
        }

        if (left)
        {
            rt.localPosition = new Vector3(rt.localPosition.x + 2, rt.localPosition.y);

        }
        else
        {
            rt.localPosition = new Vector3(rt.localPosition.x - 2, rt.localPosition.y);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            if (finalPosition)
            {
                bossHealthBar.fillAmount = bossHealthBar.fillAmount - (0.1f + (0.05f * PlayerPrefs.GetInt("WeaponUpgrade")));
            }
            if (bossHealthBar.fillAmount <= 0.01f)
            {
                Ship.score += 150;
                Destroy(gameObject);
            }
        }
    }

    long shotTime = DateTime.Now.Ticks;

    private void TryShoot()
    {
        if (DateTime.Now.Ticks - shotTime >= 20000000 && finalPosition)
        {
            GameObject enemyMissile = Instantiate(enenmyMissile);
            enemyMissile.transform.position = gameObject.transform.position;
            enemyMissile.transform.SetParent(gameObject.transform.parent);
            shotTime = DateTime.Now.Ticks;
        }
    }

    long superShotTime = DateTime.Now.Ticks;

    private bool TrySuperShot()
    {
        if (DateTime.Now.Ticks - superShotTime >= 9553070 && finalPosition && (gameObject.transform.position.x > (Screen.width / 2 - 10) && gameObject.transform.position.x < (Screen.width / 2 + 10)))
        {
            int dir = -6;
            for (int i = 0; i < 5; i++)
            {
                GameObject enemyMissile = Instantiate(enenmyMissile);
                enemyMissile.transform.position = new Vector3(gameObject.transform.position.x + dir - 10, gameObject.transform.position.y);
                enemyMissile.transform.SetParent(gameObject.transform.parent);
                enemyMissile.GetComponent<EnemyMissile>().SetxDirection(dir);
                enemyMissile.GetComponent<EnemyMissile>().SetDmg(level*10);
                dir += 3;
            }

            shotTime = DateTime.Now.Ticks;
            superShotTime = DateTime.Now.Ticks;
            return true;
        }
        return false;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetSprite(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
