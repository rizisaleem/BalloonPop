using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private List<EventListener> eventListeners = new List<EventListener>();
    [SerializeField] private List<View> views = new List<View>();

    private Menu currentMenu;
    private Menu prevMenu;

    private ViewType currentView;

    public enum Menu
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

    public void ChangeMenu(Menu newMenu)
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

    public bool IsActiveState(Menu menu) => currentMenu == menu;

    public bool IsActiveState(ViewType viewType) => currentView == viewType;

    public Menu GetMenuState(bool getPrev) => getPrev ? prevMenu : currentMenu;

    public T GetMenu<T>(Menu menu) where T : EventListener
        => TryGetListener(menu, out var listener) ? listener as T : null;

    public T GetView<T>(ViewType viewType) where T : View
        => TryGetView(viewType, out var view) ? view as T : null;

    private bool TryGetListener(Menu menu, out EventListener listener) => listener = eventListeners.Find(el => el.MenuType == menu);

    private bool TryGetView(ViewType viewType, out View view) => view = views.Find(v => v.ViewType == viewType);
} 