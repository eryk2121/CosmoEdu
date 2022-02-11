using System;
using UnityEngine.UI;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static int score = 0;
    public static bool freeze = false;
    public Data dataBase;   
    public GameObject missile;
    public GameObject endPanel;
    public GameObject questionPanel;
    public GameObject explosion;
    public Text text;

    public Image shipImage;

    public GameSpawner generator;

    private long time = DateTime.Now.Ticks;

    public static int coins = 0;

    public Image health;

    public Sprite ship1;
    public Sprite ship2;
    public Sprite ship3;
    public Sprite ship4;
    public Sprite ship5;

    private bool respawn = true;

    private bool shieldActive = false;

    private void Start()
    {
        Restart();
        LoadGrahpics();
    }

    private void LoadGrahpics()
    {
        switch (PlayerPrefs.GetString("Ship"))
        {
            case "Ship1":
                shipImage.sprite = ship1;
                break;
            case "Ship2":
                shipImage.sprite = ship2;
                break;
            case "Ship3":
                shipImage.sprite = ship3;
                break;
            case "Ship4":
                shipImage.sprite = ship4;
                break;
            case "Ship5":
                shipImage.sprite = ship5;
                break;
            default:
                shipImage.sprite = ship1;
                break;
        }
    }

    void Update()
    {
        if (Pause.pause)
        {
            if (DateTime.Now.Ticks - time >= 2000000 && !endPanel.active && !questionPanel.active)
            {
                score++;
                text.text = "Wynik:" + score;

                time = DateTime.Now.Ticks;
            }

            ShieldLogic();
            FreezeLogic();
        }

    }

    float counter = 160;
    bool raise = true;
    private void ShieldLogic()
    {
        if (DateTime.Now.Ticks - shieldTime >= 20000000 * (PlayerPrefs.GetInt("ShieldUpgrade") + 1))
        {
            shieldActive = false;
        }
        else
        {
            Image img = GetComponent<Image>();
            img.color = new Color32((byte)(img.color.r * 255), (byte)(img.color.g * 255), (byte)(img.color.b * 255), (byte)counter);
            if (raise)
            {
                counter += 1f;
                if (counter == 250)
                {
                    raise = false;
                }
            }
            else
            {
                counter -= 1f;
                if (counter == 150)
                {
                    raise = true;
                }
            }
        }
    }

    private long time3 = DateTime.Now.Ticks;
    private void FreezeLogic()
    {
        if (DateTime.Now.Ticks - time3 > 80000000/(PlayerPrefs.GetInt("FreezeUpgrade")+1))
        {
            freeze = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collision(collision.gameObject);
    }

    public void Collision(GameObject gameObject)
    {
        if (gameObject.CompareTag("Hit"))
        {
            GetComponent<ShipAudioManager>().PlayMeteorCollision();
            Explode(gameObject);
            Destroy(gameObject);
            Hit();
        }
	else if(gameObject.CompareTag("Satelite"))
	{
	    GetComponent<ShipAudioManager>().PlayMeteorCollision();
            Explode(gameObject);
            Destroy(gameObject);
	    int dmg = 30; 
	    Hit(dmg);
	}
        else if (gameObject.CompareTag("Boss"))
        {
            Explode(gameObject);
            Hit(50);
        }
        else if (gameObject.CompareTag("EnemyMissile"))
        {
            GetComponent<ShipAudioManager>().PlayMeteorCollision();
            Explode(gameObject);
            int dmg = gameObject.GetComponent<EnemyMissile>().GetDmg();
            Destroy(gameObject);
            Hit(dmg);

        }
        else if (gameObject.CompareTag("Heart"))
        {
            GainHeart();
            GetComponent<ShipAudioManager>().Bonuscollect();
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Shield"))
        {
            Shield();
            GetComponent<ShipAudioManager>().Bonuscollect();
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Coin"))
        {
            GainCoins();
            GetComponent<ShipAudioManager>().Bonuscollect();
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Freeze"))
        {
            time3 = DateTime.Now.Ticks;
            Destroy(gameObject);
            freeze = true;

        }

    }

    public void Explode(GameObject go)
    {
        GameObject n = Instantiate(explosion);
        n.transform.position = go.transform.position;
        n.transform.parent = go.transform.parent;
    }

    long shieldTime = 0;

    public void Shield()
    {
        shieldTime = DateTime.Now.Ticks;
        shieldActive = true;
    }

    public void GainHeart()
    {
        if (health.fillAmount < 1f)
        {
            health.fillAmount += 0.05f * (PlayerPrefs.GetInt("HealthUpgrade")+1);
        }
    }

    public void GainCoins()
    {
        int coins = dataBase.CurrentCoins;
        dataBase.LastAddedCoins += 2 * (PlayerPrefs.GetInt("CoinUpgrade") + 1);
        coins += 2 * (PlayerPrefs.GetInt("CoinUpgrade")+1);
        dataBase.CurrentCoins = coins;
        Ship.coins += 2 * (PlayerPrefs.GetInt("CoinUpgrade") +1);
    }

    public void AddCoins()
    {
        dataBase.LastAchievedScore += score;
        int coins = dataBase.CurrentCoins;
        dataBase.LastAddedCoins += (score / 100);
        coins += (score / 100);
        dataBase.CurrentCoins = coins;
        Ship.coins += score / 100;
    }

    private int GetQuizLevel()
    {
        if (score > 2000)
            return 3;
        if (score > 1000)
            return 2;
        return 1;
    }
    public void Hit()
    {
        Quiz quiz = questionPanel.GetComponent<Quiz>();

        if (health.fillAmount < 0.01f && !questionPanel.active && !endPanel.active && respawn)
        {
            respawn = false;
            Deactive();
            health.fillAmount = 0f;
            questionPanel.SetActive(true);
            quiz.LoadElement(GetQuizLevel());
        }
        else if (health.fillAmount < 0.01f)
        {
            dataBase.AmountOfPlay += 1;
            UpdateHighScore();
            AddCoins();
            Deactive();
            new SceneSwitch().SwitchToFact();
        }
        else if (!shieldActive)
        {
            health.fillAmount -= 0.1f + score / 5000;
        }

    }
   

    public void Hit(int dmg)
    {
        Quiz quiz = questionPanel.GetComponent<Quiz>();
        if (health.fillAmount < 0.01f && !questionPanel.active && !endPanel.active && !shieldActive && respawn)
        {
            respawn = false;
            Deactive();
            health.fillAmount = 0f;
            questionPanel.SetActive(true);
            quiz.LoadElement(GetQuizLevel());
        }
        else if (health.fillAmount < 0.01f)
        {
            dataBase.AmountOfPlay += 1;
            UpdateHighScore();
            AddCoins();
            Deactive();
            new SceneSwitch().SwitchToFact();
        }
        else if (!shieldActive)
        {
            quiz.ZeroQuiz();
            health.fillAmount -= ((float)dmg / 100);
        }

    }

    public void Restart()
    {
        dataBase.LastAchievedScore = 0;
        dataBase.LastAddedCoins = 0;
        health.fillAmount = 1f;
        endPanel.SetActive(false);
        questionPanel.SetActive(false);
        score = 0;
        coins = 0;
        freeze = false;
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 3, 1);
        generator.ResetProgres();
    }

    public void SoftRestart()
    {
        Active();
        health.fillAmount = 1f;
        endPanel.SetActive(false);
        questionPanel.SetActive(false);
        gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 3, 1);
    }

    public void ActiveEndPanel() {
        questionPanel.SetActive(false);
        endPanel.SetActive(true);
    }

    long shotTime = DateTime.Now.Ticks;

    public void Shot()
    {
        if (DateTime.Now.Ticks - shotTime >= 5000000)
        {
            GetComponent<ShipAudioManager>().RocketStart();
            GameObject miss = Instantiate(missile);
            miss.transform.SetParent(this.gameObject.transform.parent);
            miss.transform.position = this.gameObject.transform.position;
            shotTime = DateTime.Now.Ticks;
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateHighScore()
    {
        dataBase.TryToAddScoreScoreboard(score);

        if(score > dataBase.HighScore)
        {
            dataBase.HighScore = score;
        }

        GameSpawner.waveLevel = 1;
    }

}
