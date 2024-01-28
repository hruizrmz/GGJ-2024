using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI charComponent, textComponent;
    public RawImage portraitComponent;
    public string[] characters, lines;
    public Texture[] portraits;
    public static event Action ChangeInteractive, StartTimer;

    public float textSpeed;
    private int index;
    private bool isTalking;
    public bool isStoryDialogue, isPassword, isDesktop, isBookDialogue;

    private void Start()
    {
        if (!isTalking)
        {
            textComponent.text = string.Empty;
            StartDialogue();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        Dialogue.ChangeInteractive?.Invoke();
        isTalking = true;
        index = 0;
        charComponent.text = characters[index];
        portraitComponent.texture = portraits[index];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        AudioManager.instance.PlayClick("ButtonClick");
        if (index < lines.Length - 1)
        {
            index++;
            charComponent.text = characters[index];
            portraitComponent.texture = portraits[index];
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (isTalking)
            {
                isTalking = false;
                Dialogue.ChangeInteractive?.Invoke();
                if (isStoryDialogue)
                {
                    AudioManager.instance.PlayMusic("Level");
                    Dialogue.StartTimer?.Invoke();
                }
                else if (isPassword)
                {
                    GameObject.FindGameObjectWithTag("PC").GetComponent<PasswordController>().ShowPwdScreen();
                }
                else if (isDesktop)
                {
                    GameObject.FindGameObjectWithTag("PC").GetComponent<PasswordController>().ShowDesktopScreen();
                }
                else if (isBookDialogue)
                {
                    GameObject.FindGameObjectWithTag("Crowbar").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Books").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("BooksItem").transform.GetChild(0).gameObject.SetActive(false);
                }
                gameObject.SetActive(false);
            }
            else
            {
                textComponent.text = string.Empty;
                StartDialogue();
            }
        }
    }
}
