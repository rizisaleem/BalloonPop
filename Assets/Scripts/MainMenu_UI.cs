using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject credits;
    public GameObject how_to_play;

    public Slider volumeSlider;

    public AudioSource audioSource;
    public AudioClip background;

    // Awake is called on compile time before runtime, will be run firstly
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
        how_to_play.SetActive(false);

        if(PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else 
        {
            Load();
        }
        audioSource.clip = background;
        audioSource.Play();
    }

    public void settingbtn()
    {
        //mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void creditsbtn()
    {
        //mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void how_to_playbtn()
    {
        //mainMenu.SetActive(false);
        how_to_play.SetActive(true);
    }

    public void backtbn()
    {
        mainMenu.SetActive(true);
        Animator animator = settings.GetComponent<Animator>();
        animator.SetTrigger("Return");
        Invoke("turnOFFPanel", 1f);

        Animator animator1 = credits.GetComponent<Animator>();
        animator1.SetTrigger("Return2");
        Invoke("turnOFFPanel", 1f);

        Animator animator2 = how_to_play.GetComponent<Animator>();
        animator2.SetTrigger("Return3");
        Invoke("turnOFFPanel", 1f);
    }

    public void turnOFFPanel()
    {
        settings.SetActive(false);
        credits.SetActive(false);
        how_to_play.SetActive(false);
    }

    public void playtbtnclicked()
    {
        SceneManager.LoadScene(1);
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void playButton()
    {
        audioSource.Play();
    }



    // Update is called once per frame, change rate variable
    void Update()
    {
        
    }

    // Has regular interval, fixed like 20fps fixed
    void FixedUpdate()
    {
        
    }
}
