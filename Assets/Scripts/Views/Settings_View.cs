using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_View : View
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Image soundON;
    [SerializeField] private Image soundOFF;
    private bool soundCheck;

    private Animator anim;

    private int targetScore;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        targetScore = PlayerPrefs.GetInt("TargetScore", 50);
    }

    public void OnClickClose()
    {
        AudioManager.Instance.PlaySound("Click");
        anim.SetTrigger("Return");
        StartCoroutine(HideViewCoroutine());
    }
    
    private IEnumerator HideViewCoroutine()
    {
        yield return new WaitForSeconds(1.25f);
        gameObject.SetActive(false);
    }

    public void ToggleSoundButton()
    {
        soundCheck = !AudioManager.Instance.IsMusicPlaying();
        AudioManager.Instance.TurnMusicOnOff(soundCheck);
        soundON.gameObject.SetActive(soundCheck);
        soundOFF.gameObject.SetActive(!soundCheck);
    }

    public void VolumeControl()
    {
        AudioManager.Instance.VolumeControl(volumeSlider.value);
    }

    public void SetTargetScore(string input)
    {
        if (int.TryParse(input, out int score))
        {
            targetScore = score;
            PlayerPrefs.SetInt("TargetScore", targetScore);
            Debug.Log("Target Score set to: " + targetScore);
        }
        else
        {
            Debug.Log("Invalid input! Please enter a number.");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
