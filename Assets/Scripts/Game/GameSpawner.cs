using System;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameObject heartPrefab;
    public GameObject parent;

    public GameObject bossPrefab;

    public Ship ship;

    public Sprite ship1;
    public Sprite ship2;
    public Sprite ship3;
    public Sprite ship4;
    public Sprite ship5;

    private long time = DateTime.Now.Ticks;
    private long eventM = DateTime.Now.Ticks;
    private long deltaTime = (20000000);
    private GameObject boss;

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Ticks - time >= deltaTime)
        {
            SpawnMeteor(); 

            time = DateTime.Now.Ticks;
        
            if (deltaTime > 10000000)
            {
                deltaTime -= 50000;
            }

            if (UnityEngine.Random.Range(1,10) == 5)
            {
                SpawnPowerUp();
            }
        }

        if (DateTime.Now.Ticks - eventM >= 200000000)
        {

            for (int i = 0; i < UnityEngine.Random.Range(7, 15); i++)
            {
                SpawnMeteor();
            }

            eventM = DateTime.Now.Ticks;
        }

        if (ship.GetScore() % 100 == 0 && ship.GetScore() > 0 && boss == null)
        {
            SpawnBoss();
        }

    }

    void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab);
        newMeteor.transform.position = new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height * 1.2f, 1);

        float scale = UnityEngine.Random.Range(1.5f, 4);
        newMeteor.transform.localScale = new Vector3(scale, scale, 1);
        newMeteor.transform.SetParent(parent.transform);
    }

    void SpawnPowerUp()
    {
        GameObject newPowerUp = Instantiate(heartPrefab);
        newPowerUp.transform.position = new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height * 1.2f, 1);
        newPowerUp.transform.SetParent(parent.transform);

    }

    private int bossLevel = 1;
    
    void SpawnBoss()
    {
        boss = Instantiate(bossPrefab);
        boss.transform.position = new Vector3(Screen.width/2, Screen.height * 1.2f, 1);
        boss.transform.SetParent(parent.transform);

        Boss bossScript = boss.GetComponent<Boss>();

        bossScript.SetLevel(bossLevel);

        if (bossLevel % 1 == 0)
        {
            bossScript.SetSprite(ship1);
        }
        if (bossLevel % 2 == 0)
        {
            bossScript.SetSprite(ship2);

        }
        if (bossLevel % 3 == 0)
        {
            bossScript.SetSprite(ship3);

        }
        if (bossLevel % 4 == 0)
        {
            bossScript.SetSprite(ship4);

        }
        if (bossLevel % 5 == 0)
        {
            bossScript.SetSprite(ship5);

        }

        if(bossLevel == 5)
        {
            bossLevel = 1;
        }





    }

    public void ResetProgres()
    {
        deltaTime = 20000000;
    }
}
