using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : Interactable
{
    private void Start()
    {
        type = InteractiveTypes.Puzzle;
        solved = false;
    }

    private void OnEnable()
    {
        Item.SolvePuzzle += SolveMe;
    }
    private void OnDisable()
    {
        Item.SolvePuzzle -= SolveMe;
    }
    private void SolveMe(int ID)
    {
        if (ID == this.ID)
        {
            solved = true;
            activeSprite.color = Color.green;
            // transform.GetComponent<SpriteRenderer>().sprite = solved;
        }
    }
}