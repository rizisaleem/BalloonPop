using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public MenuManager.MenuType MenuType;

    protected virtual void OnEnable() { }
    protected virtual void OnDisable() { }
}
