using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : Menu
{
    private MenuManager MenuManager => MenuManager.Instance;

    [SerializeField] private Text highScore;

    [SerializeField] private Text timerCount;
    [SerializeField] private float timer = 30;

    private void Awake()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        timerCount.text = Mathf.FloorToInt(timer).ToString();
        
        if (timer <= 1)
        {
            timer = 0;
            // Game over logic here
        }
    }

    public void PauseGame()
    {
        MenuManager.EnableView(MenuManager.ViewType.Pause);
    }

    public void MainMenu()
    {
        MenuManager.ChangeMenu(MenuManager.MenuType.MainMenu);
    }
}
