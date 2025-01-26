using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public TextMeshProUGUI text1;
    public Button button2;
    public TextMeshProUGUI text2;
    public Button button3;
    public TextMeshProUGUI text3;
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

    private void DisplayRandomPowerUp(Button button, TextMeshProUGUI text)
    {
        int randomUID = Random.Range(0, Upgrades.Upgrade.NextUID - 1);
        Upgrades.Upgrade upgrade = Upgrades.upgrades[randomUID];
        text.text = upgrade.Name + "\n" + upgrade.Description + "\n" + upgrade.Type;
        button.onClick.AddListener(delegate {
            Upgrades.ApplyUpgrade(randomUID);
        });
        
    }

    private void ReadyPowerUp()
    {
        DisplayRandomPowerUp(button1, text1);
        DisplayRandomPowerUp(button2, text2);
        DisplayRandomPowerUp(button3, text3);
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
