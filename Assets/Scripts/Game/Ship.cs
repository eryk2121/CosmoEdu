using System;
using UnityEngine.UI;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static int score = 0;

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
                text.text = "Score:" + score;

                time = DateTime.Now.Ticks;
            }

            ShieldLogic();
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
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Shield"))
        {
            Shield();
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Coin"))
        {
            GainCoins();
            Destroy(gameObject);
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
        int coins = PlayerPrefs.GetInt("Coins");
        coins += 2 * (PlayerPrefs.GetInt("CoinUpgrade")+1);
        PlayerPrefs.SetInt("Coins", coins);
        Ship.coins += coins;
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
            quiz.LoadElement();
        }
        else if (health.fillAmount < 0.01f)
        {
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
            quiz.LoadElement();
        }
        else if (health.fillAmount < 0.01f)
        {
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
        health.fillAmount = 1f;
        endPanel.SetActive(false);
        questionPanel.SetActive(false);
        score = 0;
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
        AddCoins();
        UpdateMaxScore();
        UpdateGamesAmount();
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

    public void AddCoins()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coins += score / 200;
        PlayerPrefs.SetInt("Coins", coins);
        Ship.coins += coins;
    }

    public void UpdateMaxScore()
    {
        if (score > PlayerPrefs.GetInt("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }
    }

    public void UpdateCorrectAnswerAmount()
    {
        
        PlayerPrefs.SetInt("CorrectAnswer", PlayerPrefs.GetInt("CorrectAnswer") + 1);

    }

    public void UpdateGamesAmount()
    {

        PlayerPrefs.SetInt("GamesAmount", PlayerPrefs.GetInt("GamesAmount") + 1);

    }

    public int GetScore()
    {
        return score;
    }

}
