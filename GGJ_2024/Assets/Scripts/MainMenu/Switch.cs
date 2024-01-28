using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public GameObject[] background; 
    public GameObject cutscenes;
    public GameObject NextButton;
    public GameObject BackButton;
    public GameObject Credits;
    public GameObject Controls;
    public GameObject MainMenu;
    int index;

    void Start()
    {
        index = 0;
    }

    void Update()
    {
        if (index >= 9)
            index = 9;

        if (index < 0)
            index = 0;

        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
            BackButton.SetActive(false);
        }
        else
        {
            BackButton.SetActive(true);
        }

        if (index == 9)
        {
            NextButton.SetActive(false);
        }
        else
        {
            NextButton.SetActive(true);
        }
    }

    public void Next() 
    {
        for(int i = 0 ; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
        }
        index += 1;
        background[index].gameObject.SetActive(true);

        switch (index)
        {
            case 1:
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("Whistle");
                break;
            case 2:
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("Tada");
                break;
            case 5:
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("SitDown");
                break;
            case 6:
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("EatPaste");
                break;
            case 9:
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("Sleep");
                break;
            default:
                break;
        }
    }

    public void Previous()
    {
        index -= 1;

        for(int i = 0 ; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        Application.Quit();
    }

    public void StartDream()
    {
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene("Level");
    }

    public void TurnOnCutscenes() 
    {
        AudioManager.instance.PlaySFX("WaterSplash");
        cutscenes.SetActive(true);
    }

    public void CreditsMenu()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }

    public void ControlsMenu()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        Controls.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ControlsButton()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        MainMenu.SetActive(true);
        Controls.SetActive(false);
    }
}
