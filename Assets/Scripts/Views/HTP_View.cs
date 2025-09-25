using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTPView : View
{
    public void OnClickClose()
    {
        gameObject.SetActive(false);
    }
}
