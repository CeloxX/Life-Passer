using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] GameObject loseLabel;
    [SerializeField] Text scoreText;

    public static GameSession Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        loseLabel.SetActive(false);
        scoreText.text = score.ToString();
    }

    public float seeScore()
    {
        return score;
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
    public void HandleLoseCondition()
    {
        
        StartCoroutine(Wait());        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        loseLabel.SetActive(true);
    }
}
