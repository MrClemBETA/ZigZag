﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject platform;
    public GameObject diamond;

    private float createPlatformTime = .2f;
    private float currentPlatformTime = 0f;

    private float xPos;
    private float zPos;
    private float scale;
    private int score = 0;
    private int highScore;

    public bool GameOver { get; private set; }
    public bool GameStart { get; private set; }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        GameOver = false;
        GameStart = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        zPos = transform.position.z;
        scale = platform.transform.localScale.x;
        highScore = PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        currentPlatformTime += Time.deltaTime;
        if(currentPlatformTime > createPlatformTime && GameRunning())
        {
            CreatePlatform();
            currentPlatformTime = 0;
        }
    }

    private void CreatePlatform()
    {
        // Creates a platform
        GameObject go = Instantiate(platform);
        go.transform.position = new Vector3(xPos, transform.position.y, zPos);

        // Randomly create a diamond
        float value = Random.Range(0f, 1f);
        if(value < .3f)
        {
            GameObject d = Instantiate(diamond);
            d.transform.position = new Vector3(xPos, d.transform.position.y, zPos);
        }
        
        // Determine Next Position
        int direction = Random.Range(0, 2);
        if(direction == 0)
        {
            xPos += scale;
        } else
        {
            zPos += scale;
        }
    }

    public void GameIsOver()
    {
        GameOver = true;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }
        DisplayManager.instance.endingPanel.SetActive(true);
        DisplayManager.instance.gameOverScoreText.text = "Score: " + score;
        DisplayManager.instance.highScoreText.text = "High Score: " + highScore;
    }

    public void StartGame()
    {
        DisplayManager.instance.startingPanel.SetActive(false);
        GameStart = true;
    }

    public bool GameRunning()
    {
        return !GameOver && GameStart;
    }

    public void AddScore()
    {
        score++;
        DisplayManager.instance.scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
