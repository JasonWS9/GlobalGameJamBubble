using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

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
        if (score >= requiredPowerupScore && !powerUpReadied)
        {
            Debug.Log("Spawn Powerup");
            ReadyPowerUp();
            powerUpReadied= true;
        }
    }

    private void DisplayRandomPowerUp(Button button, TextMeshProUGUI text1, TextMeshProUGUI text2, TextMeshProUGUI text3)
    {
        int randomUID = Random.Range(0, Upgrades.Upgrade.NextUID - 1);
        Upgrades.Upgrade upgrade = Upgrades.upgrades[randomUID];
        text1.text = upgrade.Name;
        text2.text = upgrade.Description;
        text3.text = upgrade.Type + "";
        button.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(randomUID);
        });
        
    }

    private void ReadyPowerUp()
    {
        DisplayRandomPowerUp(button1, button1text1, button1text2, button1text3);
        DisplayRandomPowerUp(button2, button2text1, button2text2, button2text3);
        DisplayRandomPowerUp(button3, button3text1, button3text2, button3text3);
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
