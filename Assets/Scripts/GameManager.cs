using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Player player;

    private Spawner spawner;

    public GameObject playButton;

    public GameObject gameOver;

    public int score { get; private set; }

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
    }

    public void Play()
    {
        score = -2;
        // scoreText.text = score.ToString();
        scoreText.text = "0";

        FindObjectOfType<CheckCollision>().isGameOver = false;
        player.transform.position = new Vector3(-0.5f, 2f, 0f);

        FindObjectOfType<PhysicsEngine>().ResetVelocity();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        if (score >= 0){
            scoreText.text = score.ToString();
        }
        else {
            scoreText.text = "0";
        }
    }
}
