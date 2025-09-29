using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTP_View : View
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnClickClose()
    {
        AudioManager.Instance.PlaySound("Click");
        anim.SetTrigger("Return3");
        StartCoroutine(HideViewCoroutine());
    }
    
    private IEnumerator HideViewCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        gameObject.SetActive(false);
    }
}
