using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_UI : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject pause;
    public GameObject gamePlay;
    public GameObject winScreen;
    public GameMechanics gameMechanicsRef;
    
    public Text counterViewer;
    public Text timerViewer;
    public Text Countdown;
    public Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        gamePlay.SetActive(true);
        gameOver.SetActive(false);
        pause.SetActive(false);
        winScreen.SetActive(false);
    }
    public void mainMenubtn()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void pausebtn()
    {
        pause.SetActive(true);
    }
    public void resumebtn()
    {
        gamePlay.SetActive(true);
        gameOver.SetActive(false);
        pause.SetActive(false);
        winScreen.SetActive(false);
    }
    public void updateCounter()
    {
        counterViewer.text = gameMechanicsRef.counter.ToString();
    }
    public void updateTimer()
    {
        timerViewer.text = gameMechanicsRef.seconds.ToString();
    }
    public void displayHighScore()
    {
        HighScore.text = gameMechanicsRef.highScore.ToString();
    }
    public void displayCountDown()
    {
        Countdown.text = gameMechanicsRef.countDown.ToString();
    }

    public void pauseMenu()
    {
        if (gameMechanicsRef.isPaused == true)
        {
            pause.SetActive(true);
        }
        else if (gameMechanicsRef.isPaused == false)
        {
            pause.SetActive(false);
        }

    }
    public void winPanel()
    {
        winScreen.SetActive(true);
    }
    public void loseScreen()
    {
        gameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
