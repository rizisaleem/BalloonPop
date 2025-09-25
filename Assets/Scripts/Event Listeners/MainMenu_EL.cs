using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEventListener : EventListener
{
    private MenuManager MenuManager => MenuManager.Instance;

    public void OnClickPlayButton()
    {
        MenuManager.ChangeMenu(MenuManager.Menu.Gameplay);
    }

    public void OnClickHowToPlayButton()
    {
        MenuManager.EnableView(MenuManager.ViewType.HowToPlay);
    }

    public void OnClickCreditsButton()
    {
        MenuManager.EnableView(MenuManager.ViewType.Credits);
    }

    public void OnClickSettingsButton()
    {
        MenuManager.EnableView(MenuManager.ViewType.Settings);
    }
}
