using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private List<Menu> menus = new List<Menu>();
    [SerializeField] private List<View> views = new List<View>();

    private MenuType currentMenu;
    private MenuType prevMenu;

    private ViewType currentView;

    public enum MenuType
    {
        MainMenu,
        Gameplay,
    }

    public enum ViewType
    {
        Settings,
        HowToPlay,
        Credits
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ChangeMenu(MenuType newMenu)
    {
        prevMenu = currentMenu;
        currentMenu = newMenu;

        if (TryGetListener(prevMenu, out var oldListener))
            oldListener.gameObject.SetActive(false);

        if (TryGetListener(currentMenu, out var newListener))
            newListener.gameObject.SetActive(true);
    }

    public void EnableView(ViewType viewType)
    {
        if (TryGetView(viewType, out var view))
            view.gameObject.SetActive(true);
    }

    public bool IsActiveState(MenuType menu) => currentMenu == menu;

    public bool IsActiveState(ViewType viewType) => currentView == viewType;

    public MenuType GetMenuState(bool getPrev) => getPrev ? prevMenu : currentMenu;

    public T GetMenu<T>(MenuType menu) where T : Menu
        => TryGetListener(menu, out var listener) ? listener as T : null;

    public T GetView<T>(ViewType viewType) where T : View
        => TryGetView(viewType, out var view) ? view as T : null;

    private bool TryGetListener(MenuType menu, out Menu listener) => listener = menus.Find(el => el.MenuType == menu);

    private bool TryGetView(ViewType viewType, out View view) => view = views.Find(v => v.ViewType == viewType);
} 