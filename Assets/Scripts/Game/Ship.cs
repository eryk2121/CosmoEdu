using System;
using UnityEngine.UI;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private int score = 0;

    public GameObject missile;
    public GameObject endPanel;
    public GameObject questionPanel;
    public GameObject explosion;
    public Text text;
    public Text endscore;

    public Image shipImage;

    public GameSpawner generator;

    private long time = DateTime.Now.Ticks;

    public Image health;

    public Sprite ship1;
    public Sprite ship2;
    public Sprite ship3;
    public Sprite ship4;
    public Sprite ship5;



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
        if (DateTime.Now.Ticks - time >= 2000000 && !endPanel.active && !questionPanel.active)
        {
            score++;
            text.text = "Score:" + score;

            time = DateTime.Now.Ticks;
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
            Hit();
        }
        else if (gameObject.CompareTag("Boss"))
        {

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

    }

    public void Explode(GameObject go)
    {
        GameObject n = Instantiate(explosion);
        n.transform.position = go.transform.position;
        n.transform.parent = go.transform.parent;
    }

    public void GainHeart()
    {
        if (health.fillAmount < 1f)
        {
            health.fillAmount += 0.1f;
        }
    }

    public void Hit()
    {
        if (health.fillAmount < 0.01f && !questionPanel.active && !endPanel.active)
        {
            health.fillAmount = 0f;
            //menu przegranej
            questionPanel.SetActive(true);
            //endscore.text = "Wynik:" + score;
            //this.gameObject.SetActive(false);
            Quiz quiz = questionPanel.GetComponent<Quiz>();
            quiz.LoadElement();

            //AddToLeaderBoard();
        }
        else
        {
            health.fillAmount -= 0.1f;
        }
    }

    public void Hit(int dmg)
    {
        if (health.fillAmount < 0.01f && !questionPanel.active && !endPanel.active)
        {
            health.fillAmount = 0f;
            //menu przegranej
            questionPanel.SetActive(true);
            //endscore.text = "Wynik:" + score;
            //this.gameObject.SetActive(false);
            Quiz quiz = questionPanel.GetComponent<Quiz>();
            quiz.LoadElement();

            //AddToLeaderBoard();
        }
        else
        {
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
        if (DateTime.Now.Ticks - shotTime >= 10000000)
        {
            GetComponent<ShipAudioManager>().RocketStart();

            GameObject miss = Instantiate(missile);


            miss.transform.SetParent(this.gameObject.transform.parent);
            miss.transform.position = this.gameObject.transform.position;

            shotTime = DateTime.Now.Ticks;
        }
    }

    public void AddCoins()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coins += score / 10;
        PlayerPrefs.SetInt("Coins", coins);
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



    /*
    public void AddToLeaderBoard()
    {
        int oldScore = 0;

        if (score > PlayerPrefs.GetInt("1"))
        {
            oldScore = PlayerPrefs.GetInt("1");
            PlayerPrefs.DeleteKey("1");
            PlayerPrefs.SetInt("1", score);
            AddToLeaderBoard(oldScore);
        }
        else if (score > PlayerPrefs.GetInt("2"))
        {
            oldScore = PlayerPrefs.GetInt("2");

            PlayerPrefs.DeleteKey("2");
            PlayerPrefs.SetInt("2", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("3"))
        {
            oldScore = PlayerPrefs.GetInt("3");

            PlayerPrefs.DeleteKey("3");
            PlayerPrefs.SetInt("3", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("4"))
        {
            oldScore = PlayerPrefs.GetInt("4");

            PlayerPrefs.DeleteKey("4");
            PlayerPrefs.SetInt("4", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("5"))
        {
            oldScore = PlayerPrefs.GetInt("5");

            PlayerPrefs.DeleteKey("5");
            PlayerPrefs.SetInt("5", score);
            AddToLeaderBoard(oldScore);

        }
    }

    public void AddToLeaderBoard(int score)
    {
        int oldScore = 0;

        if (score > PlayerPrefs.GetInt("1"))
        {
            oldScore = PlayerPrefs.GetInt("1");
            PlayerPrefs.DeleteKey("1");
            PlayerPrefs.SetInt("1", score);
            AddToLeaderBoard(oldScore);
        }
        else if (score > PlayerPrefs.GetInt("2"))
        {
            oldScore = PlayerPrefs.GetInt("2");

            PlayerPrefs.DeleteKey("2");
            PlayerPrefs.SetInt("2", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("3"))
        {
            oldScore = PlayerPrefs.GetInt("3");

            PlayerPrefs.DeleteKey("3");
            PlayerPrefs.SetInt("3", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("4"))
        {
            oldScore = PlayerPrefs.GetInt("4");

            PlayerPrefs.DeleteKey("4");
            PlayerPrefs.SetInt("4", score);
            AddToLeaderBoard(oldScore);

        }
        else if (score > PlayerPrefs.GetInt("5"))
        {
            oldScore = PlayerPrefs.GetInt("5");

            PlayerPrefs.DeleteKey("5");
            PlayerPrefs.SetInt("5", score);
            AddToLeaderBoard(oldScore);

        }
        
    }
    */
}
