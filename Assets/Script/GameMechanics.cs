using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameMechanics : MonoBehaviour
{
    public int counter;
    public float timer;
    public float seconds;

    public bool timeEnded;
    public bool isPaused;

    public int highScore;
    public int goal;
    public bool hasWon;

    public float countDown;
    public bool countDownEnded;

    public AudioSource audioSource;
    public AudioClip[] audio_clips;

    public GamePlay_UI gamePlayUIRef;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        timer = 30;
        countDownEnded = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        gamePlayUIRef.displayHighScore();
        hasWon = false;
        isPaused = false;
        timeEnded = false;
        goal = 70;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownEnded == false)
        {
            countDown = countDown - Time.deltaTime;
            if (countDown <= 0)
            {
                countDownEnded = true;
            }
            gamePlayUIRef.displayCountDown();
        }
        if (timeEnded == false && countDownEnded == true)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0)
            {
                timeEnded = true;
                timer = 0;
            }
            seconds = Mathf.FloorToInt(timer);
            gamePlayUIRef.updateTimer();
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && isPaused == false)
            {
                counter++;
                gamePlayUIRef.updateCounter();
               // playsound();

            }
        }
        else if (timeEnded == true)
        {
            if (counter > goal)
            {
                gamePlayUIRef.winPanel();
            }
            else
            {
                gamePlayUIRef.loseScreen();
            }
            if (counter > highScore)
            {
                highScore = counter;
                PlayerPrefs.SetInt("HighScore", highScore);

            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        gamePlayUIRef.pauseMenu();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        gamePlayUIRef.pauseMenu();
    }
/*
    public void playsound()
    {
        int random;
        random = Random.Range(0, 4);
        audioSource.PlayOneShot(audio_clips[random]);
    }*/
}
