using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    private MenuManager MenuManager => MenuManager.Instance;

    public void OnClickPlayButton()
    {
        AudioManager.Instance.PlaySound("Click");
        MenuManager.ChangeMenu(MenuManager.MenuType.Gameplay);
    }

    public void OnClickHowToPlayButton()
    {
        AudioManager.Instance.PlaySound("Click");
        MenuManager.EnableView(MenuManager.ViewType.HowToPlay);
    }

    public void OnClickCreditsButton()
    {
        AudioManager.Instance.PlaySound("Click");
        MenuManager.EnableView(MenuManager.ViewType.Credits);
    }

    public void OnClickSettingsButton()
    {
        AudioManager.Instance.PlaySound("Click");
        MenuManager.EnableView(MenuManager.ViewType.Settings);
    }
}
