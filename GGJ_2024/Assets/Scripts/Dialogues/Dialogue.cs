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
    public static event Action ChangeInteractive;

    public float textSpeed;
    private int index;
    private bool isTalking;
    public bool isStoryDialogue;

    private void Start()
    {
        if (isStoryDialogue)
        {
            Debug.Log("change enabled");
            Dialogue.ChangeInteractive?.Invoke();
        }
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
                if (isStoryDialogue)
                {
                    Dialogue.ChangeInteractive?.Invoke();
                }
                gameObject.SetActive(false);
            }
            else
            {
                if (isStoryDialogue)
                {
                    Debug.Log("change enabled");
                    Dialogue.ChangeInteractive?.Invoke();
                }
                textComponent.text = string.Empty;
                StartDialogue();
            }
        }
    }
}
