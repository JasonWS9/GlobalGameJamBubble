using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyManager;
    
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

    public int score = 0;
    private int requiredPowerupScore = 10;
    private bool powerUpReadied = false;

    public TextMeshProUGUI HealthUI;
    public TextMeshProUGUI SpeedUI;
    public TextMeshProUGUI DamageUI;
    public TextMeshProUGUI ScoreUI;

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
    public bool isPowerUpAvailable;
    public void increaseScore(int Score)
    {
        score+= Score;
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = "Health: " + PlayerManager.Instance.playerHealth;
        SpeedUI.text = "Speed: " + PlayerManager.Instance.playerSpeed;
        DamageUI.text = "Damage: " + PlayerManager.Instance.damage;
        ScoreUI.text = "Score: " + score;
        if (score >= requiredPowerupScore && !powerUpReadied)
        {
            Debug.Log("Spawn Powerup");
            ReadyPowerUp();
            powerUpReadied= true;
        }
    }

    private void DisplayRandomPowerUps()
    {
        List<int> UIDs = new List<int>();
        UIDs.Add(Random.Range(0, Upgrades.Upgrade.NextUID - 1));
        while(UIDs.Count < 3)
        {
            int temp = Random.Range(0, Upgrades.Upgrade.NextUID - 1);

            if(!UIDs.Contains(temp))
            {
                UIDs.Add(temp);
            }
        }

        Debug.Log("First: " + UIDs[0] + " Second: " + UIDs[1] + " Third " + UIDs[2]);

        // int randomUID = Random.Range(0, Upgrades.Upgrade.NextUID - 1);
        Upgrades.Upgrade upgrade = Upgrades.upgrades[UIDs[0]];
        button1text1.text = upgrade.Name;
        button1text2.text = upgrade.Description;
        button1text3.text = upgrade.Type + "";
        button1.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(UIDs[0]);
        });
        upgrade = Upgrades.upgrades[UIDs[1]];
        button2text1.text = upgrade.Name;
        button2text2.text = upgrade.Description;
        button2text3.text = upgrade.Type + "";
        button2.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(UIDs[1]);
        });
        upgrade = Upgrades.upgrades[UIDs[2]];
        button3text1.text = upgrade.Name;
        button3text2.text = upgrade.Description;
        button3text3.text = upgrade.Type + "";
        button3.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(UIDs[2]);
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

}
