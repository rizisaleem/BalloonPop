using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BalloonClickUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text tapCount;
    private int counter = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        counter++;
        tapCount.text = counter.ToString();
        this.transform.localScale += new Vector3(0.015f, 0.015f, 0.015f);
    }
}
