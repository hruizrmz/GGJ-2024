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
    public GameObject MainMenu;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
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
        } else {
            BackButton.SetActive(true);
        }


        if (index == 9)
        {
            NextButton.SetActive(false);
        } else {
            NextButton.SetActive(true);
        }


    }

    public void Next() 
    {
        index += 1;

        for(int i = 0 ; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

    public void Previous()
    {
        index -= 1;

        for(int i = 0 ; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartDream()
    {
        SceneManager.LoadScene("Level");
    }

    public void TurnOnCutscenes() 
    {
        
        cutscenes.SetActive(true);
    }

    public void CreditsMenu()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void CreditsButton()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }
}
