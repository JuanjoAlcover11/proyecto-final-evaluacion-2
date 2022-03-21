using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{ 
    public bool gameOver;

    public TextMeshProUGUI scoreText;
    public int score;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = $"Score: {score}";
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        score = 0;
        UpdateScore(0);

        gameOver = false;
        gameOverPanel.SetActive(false);
    }
}
