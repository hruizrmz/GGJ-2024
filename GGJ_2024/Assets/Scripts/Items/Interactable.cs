using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected enum InteractiveTypes
    {
        Puzzle = 1,
        Item = 2,
        Icon = 3
    }
    protected InteractiveTypes type;
    public int ID;
    public bool solved;
    public SpriteRenderer activeSprite;
    private Color originalColor;

    public void HandleClick()
    {
    }

    void OnMouseEnter()
    {
        if (!solved)
        {
            originalColor = activeSprite.color;
            activeSprite.color = Color.grey;
        }
    }

    void OnMouseExit()
    {
        if (!solved)
        {
            activeSprite.color = originalColor;
        }
    }
}
