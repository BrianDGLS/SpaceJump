using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance { get; private set; }
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -3f;
    private int score = 0;
    public Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayerScored()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = $"Score: {score.ToString()}";
        }
    }

    public void PlayerDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
