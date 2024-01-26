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
    // public text bottomText;
    public bool solved;
    public SpriteRenderer activeSprite;
    // public Sprite unsolved, solved, hover;

    public void HandleClick()
    {
        if (!solved)
        {
            if ((int)type == 1)
            {
                // show text
            }
            else if ((int)type == 2)
            {
                if (GetComponent<Item>())
                {
                    Item myItem = GetComponent<Item>();
                    // showtext
                }
            }
        }
    }

    void OnMouseEnter()
    {
        if (!solved)
        {
            activeSprite.color = Color.red;
            // transform.GetComponent<SpriteRenderer>().sprite = hover;
        }
    }

    void OnMouseExit()
    {
        if (!solved)
        {
            activeSprite.color = Color.white;
            // transform.GetComponent<SpriteRenderer>().sprite = unsolved;
        }
    }
}
