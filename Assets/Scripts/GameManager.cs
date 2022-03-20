using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour

{ 
    public bool gameOver;
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = $"Score: {score}";
        Debug.Log(score);
    }
    public void StartGame(int difficulty)
    {
        score = 0;
        UpdateScore(0);
    }
}
