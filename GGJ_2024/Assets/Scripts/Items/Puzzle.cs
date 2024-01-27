using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : Interactable
{
    public GameObject dialogue;
    private bool isEnabled = true;

    private void OnEnable()
    {
        Icon.SolvePuzzle += SolveMe;
        Dialogue.ChangeInteractive += ChangeEnabled;
    }
    private void OnDisable()
    {
        Icon.SolvePuzzle -= SolveMe;
        Dialogue.ChangeInteractive -= ChangeEnabled;
    }
    private void Start()
    {
        type = InteractiveTypes.Puzzle;
        solved = false;
    }
    private void OnMouseDown()
    {
        if (!solved && isEnabled)
        {
            foreach (Transform child in GameObject.FindGameObjectWithTag("DialogueHolder").transform)
            {
                child.gameObject.SetActive(false);
            }
            dialogue.SetActive(true);
        }
    }
    private void SolveMe(int ID)
    {
        if (ID == this.ID)
        {
            solved = true;
            activeSprite.color = Color.green;
        }
    }
    private void ChangeEnabled()
    {
        isEnabled = !isEnabled;
    }
}