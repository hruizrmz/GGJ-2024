using System;
using UnityEngine;
using TMPro;

public class PasswordController : MonoBehaviour
{
    public GameObject passwordScreen, desktopScreen;
    public GameObject passwordObject, desktopObject;
    public TMP_InputField inputField;
    private bool showBook;
    public static event Action ChangeInteractive;

    private void Start()
    {
        showBook = false;
        passwordScreen.SetActive(false);
        desktopScreen.SetActive(false);
        inputField.characterLimit = 4;
    }

    public void ShowPwdScreen()
    {
        passwordScreen.SetActive(true);
        PasswordController.ChangeInteractive?.Invoke();
    }

    public void HidePwdScreen()
    {
        passwordScreen.SetActive(false);
        PasswordController.ChangeInteractive?.Invoke();
        AudioManager.instance.sfxSource.Stop();
    }

    public void ShowDesktopScreen()
    {
        desktopScreen.SetActive(true);
        if (!showBook)
        {
            GameObject.FindGameObjectWithTag("Books").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("BooksItem").transform.GetChild(0).gameObject.SetActive(true);
            showBook = true;
        }
        PasswordController.ChangeInteractive?.Invoke();
    }

    public void HideDesktopScreen()
    {
        desktopScreen.SetActive(false);
        PasswordController.ChangeInteractive?.Invoke();
        AudioManager.instance.sfxSource.Stop();
    }

    public void CheckPwd()
    {
        string code = inputField.text;
        if (code == "6124" || code == "6 1 2 4")
        {
            PasswordController.ChangeInteractive?.Invoke();
            passwordScreen.SetActive(false);
            passwordObject.SetActive(false);
            desktopObject.SetActive(true);
        }
        else
        {
            inputField.text = "";
        }
    }
}
