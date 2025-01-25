using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        //SceneManager.LoadScene("DavidTestScene");
    }

    public static void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("DavidTestScene");
        Debug.Log("Game Started");
    }
    void Update()
    {
        
    }
}
