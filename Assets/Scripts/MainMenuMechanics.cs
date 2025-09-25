using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMechanics : MonoBehaviour
{
    public Image musicON;
    public Image musicOFF;
    public bool isMuted; 


    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        updateMusicIcon();
        AudioListener.pause = isMuted;
    }

    public void musicBtn()
    {
        if(isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }
        Save();
        updateMusicIcon();
    }

    public void Load()
    {
        isMuted = PlayerPrefs.GetInt("Muted") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Muted", isMuted ? 1: 0);
    }

    public void updateMusicIcon()
    {
        if(isMuted == false)
        {
            musicON.enabled = true;
            musicOFF.enabled = false;
        }
        else
        {
            musicON.enabled = false;
            musicOFF.enabled = true;
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
