using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public int score = 0;
    private int requiredPowerupScore = 10;
    private bool powerUpReadied = false;

    public GameObject powerupUI;
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

    private void ReadyPowerUp()
    {
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
