using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

    }
    
   public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("User hasQuit");

    }

    // public void BeastiaryButton()
    // {
    //     
    //     
    // }
    
    
    
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");

    }
    
    
}
