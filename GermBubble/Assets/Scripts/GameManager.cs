using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public PlayerManager playerManager;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        powerupUI.SetActive(false);

    }

    void Start()
    {
        Debug.Log(Upgrades.upgrades[0].Name + ": " + Upgrades.upgrades[0].UID);
        Debug.Log(Upgrades.upgrades[1].Name + ": " + Upgrades.upgrades[1].UID);
        Debug.Log(Upgrades.upgrades[2].Name + ": " + Upgrades.upgrades[2].UID);
    }

    public int score = 0;
    private int requiredPowerupScore = 10;
    private int scoreIncreaseAmount = 1;
    private bool powerUpReadied = false;

    public TextMeshProUGUI HealthUI;
    public TextMeshProUGUI SpeedUI;
    public TextMeshProUGUI DamageUI;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI WaveUI;

    public GameObject powerupUI;
    public Button button1;
    public TextMeshProUGUI button1text1;
    public TextMeshProUGUI button1text2;
    public TextMeshProUGUI button1text3;
    public Button button2;
    public TextMeshProUGUI button2text1;
    public TextMeshProUGUI button2text2;
    public TextMeshProUGUI button2text3;
    public Button button3;
    public TextMeshProUGUI button3text1;
    public TextMeshProUGUI button3text2;
    public TextMeshProUGUI button3text3;
    public Button button4;
    public TextMeshProUGUI button4text1;
    public TextMeshProUGUI button4text2;
    public TextMeshProUGUI button4text3;
    public bool isPowerUpAvailable;
    public void increaseScore(int Score)
    {
        score+= Score;
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = "HP: " + PlayerManager.Instance.playerHealth;
        SpeedUI.text = "Speed: " + PlayerManager.Instance.playerSpeed;
        DamageUI.text = "Damage: " + PlayerManager.Instance.damage;
        ScoreUI.text = "Score: " + score;
        WaveUI.text = "Wave: " + EnemyManager.Instance.wave;
        if (score >= requiredPowerupScore)
        {
            Debug.Log("Spawn Powerup");
            ReadyPowerUp();
            score = 0;
            requiredPowerupScore += scoreIncreaseAmount;
            scoreIncreaseAmount *= 2;
        }
    }

    private void DisplayRandomPowerUps()
    {
        
        
        button1text1.text = Upgrades.upgrades[0].Name;
        button1text2.text = Upgrades.upgrades[0].Description;
        button1text3.text = Upgrades.upgrades[0].Type + "";
        button1.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(0);
        });

        button2text1.text = Upgrades.upgrades[1].Name;
        button2text2.text = Upgrades.upgrades[1].Description;
        button2text3.text = Upgrades.upgrades[1].Type + "";
        button2.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(1);
        });

        button3text1.text = Upgrades.upgrades[2].Name;
        button3text2.text = Upgrades.upgrades[2].Description;
        button3text3.text = Upgrades.upgrades[2].Type + "";
        button3.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(2);
        });

        button4text1.text = Upgrades.upgrades[3].Name;
        button4text2.text = Upgrades.upgrades[3].Description;
        button4text3.text = Upgrades.upgrades[3].Type + "";
        button4.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(3);
        });
    }

    private void ReadyPowerUp()
    {
        DisplayRandomPowerUps();
        powerupUI.SetActive(true);
        Time.timeScale = 0f;
        playerManager.enabled = false;
        
    }


    public void PowerUp1() 
    {
        Time.timeScale = 1f;
        playerManager.enabled = true;
        powerupUI.SetActive(false);
        Debug.Log("powerup1");
        //Actual powerup
    }

    public void PowerUp2()
    {
        Time.timeScale = 1f;
        playerManager.enabled = true;
        powerupUI.SetActive(false);
        Debug.Log("powerup2");
        //Actual powerup
    }

    public void PowerUp3()
    {
        Time.timeScale = 1f;
        playerManager.enabled = true;
        powerupUI.SetActive(false);
        Debug.Log("powerup3");
        //Actual powerup
    }

    public void PowerUp4()
    {
        Time.timeScale = 1f;
        playerManager.enabled = true;
        powerupUI.SetActive(false);
        Debug.Log("powerup4");
        //Actual powerup
    }

}
