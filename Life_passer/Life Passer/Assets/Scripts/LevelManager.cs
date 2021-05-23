using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;


    int currentSceneIndex;


   
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

  

    public void SplashScreenLoad()
    {
        StartCoroutine(SplashScreenLoading());
    }

    IEnumerator SplashScreenLoading()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Destroy(FindObjectOfType<GameSession>());
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Destroy(FindObjectOfType<GameSession>());
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
