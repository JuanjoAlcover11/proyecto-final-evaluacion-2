using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{ 
    //Variable gameOver para establecer cuando esta activo nuestro juego
    public bool gameOver;
    //Texto para mostrar los puntos
    public TextMeshProUGUI scoreText;
    //Variable int para guardar los puntos
    public int score;
    //Panel del Game Over
    public GameObject gameOverPanel;
    //Panel del menu inicial
    public GameObject mainMenuPanel;

    void Start()
    {
        //Hacemos que gameOver sea verdadero para que el juego no empiece mientras estamos en el menu
        gameOver = true;
    }

    public void UpdateScore(int pointToAdd)
    {
        //Vamos acumulando los puntos
        score += pointToAdd;
        //Los mostramos en pantalla
        scoreText.text = $"Score: {score}";
    }
    public void GameOver()
    {
        //Hacemos que gameOver sea verdadero
        gameOver = true;
        //Mostramos la pantalla de Game Over
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        //Reiniciamos el juego
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        //Hacemos que al empezar el juego los puntos esten a 0
        score = 0;
        UpdateScore(0);
        //Hacemos que empieze el juego
        gameOver = false;
        //El menu ya no es visible
        mainMenuPanel.SetActive(false);
    }
}
