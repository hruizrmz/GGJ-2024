using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : Interactable
{
    public ItemInfo itemInfo;
    public Transform itemOriginalPos;
    private Vector3 mouseDragStart, itemDragStart;
    public bool hovering, dragging;
    public static event Action<int> SolvePuzzle;
    public static event Action<GameObject> UseItem;
    public static event Action ChangeDrag, ChangeHover;

    private void OnEnable()
    {
        Timer.OnTimerCompleted += DeleteMe;
        AlarmController.AlarmSilenced -= DeleteMe;
    }
    private void OnDisable()
    {
        Timer.OnTimerCompleted -= DeleteMe;
        AlarmController.AlarmSilenced -= DeleteMe;
    }

    void Start()
    {
        type = InteractiveTypes.Icon;
        hovering = dragging = solved = false;
    }

    private void OnMouseOver()
    {
        if (!hovering)
        {
            hovering = true;
            Icon.ChangeHover?.Invoke();
        }
    }

    private void OnMouseDown()
    {
        activeSprite.color = Color.white;
        mouseDragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        itemDragStart = transform.localPosition;
        if (!dragging) Icon.ChangeDrag?.Invoke();
    }

    private void OnMouseDrag()
    {
        dragging = true;
        transform.localPosition = itemDragStart + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStart);
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            Icon.ChangeDrag?.Invoke();
            dragging = false;
            if (!solved)
            {
                transform.localPosition = Vector3.zero;
            }
            else
            {
                solved = true;
                Icon.UseItem?.Invoke(this.gameObject);
                Icon.SolvePuzzle?.Invoke(ID);
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseExit()
    {
        if (hovering)
        {
            hovering = false;
            Icon.ChangeHover?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Puzzle>())
        {
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
            if (this.ID == collision.gameObject.GetComponent<Puzzle>().ID)
            {
                this.solved = false;
            }
        }
    }

    private void DeleteMe()
    {
        Destroy(gameObject);
    }
}
