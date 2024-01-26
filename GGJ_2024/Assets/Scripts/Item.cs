using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public string itemName;
    public Vector3 itemOriginalPos;
    private Vector3 mouseDragStart, itemDragStart;
    public bool canDrag, dragging, holding;
    public static event Action<int> SolvePuzzle; 

    void Start()
    {
        type = InteractiveTypes.Item;
        canDrag = dragging = solved = false;
    }

    private void OnMouseDown()
    {
        mouseDragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        itemDragStart = transform.localPosition;
        activeSprite.color = Color.white;
    }

    private void OnMouseDrag()
    {
        if (canDrag)
        {
            dragging = true;
            transform.localPosition = itemDragStart + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStart);
            // transform.GetComponent<SpriteRenderer>().sprite = unsolved;
        }
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            dragging = false;
            if (!solved)
            {
                transform.localPosition = itemOriginalPos;
            }
            else
            {
                Item.SolvePuzzle?.Invoke(ID);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Puzzle>())
        {
            activeSprite.color = Color.yellow;
            // transform.GetComponent<SpriteRenderer>().sprite = hover;
            if (this.ID == collision.gameObject.GetComponent<Puzzle>().ID)
            {
                this.solved = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Puzzle>())
        {
            activeSprite.color = Color.white;
            // transform.GetComponent<SpriteRenderer>().sprite = unsolved;
            if (this.ID == collision.gameObject.GetComponent<Puzzle>().ID)
            {
                this.solved = false;
            }
        }
    }
}