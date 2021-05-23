using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] GameObject loseLabel;
    [SerializeField] Text scoreText;

    private void Awake()
    {
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
