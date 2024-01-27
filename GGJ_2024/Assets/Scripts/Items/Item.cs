using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public GameObject dialogue;
    public ItemInfo itemInfo;
    public static event Action<GameObject> TakeItem;
    private bool isEnabled = true;

    private void OnEnable()
    {
        Dialogue.ChangeInteractive += ChangeEnabled;
    }
    private void OnDisable()
    {
        Dialogue.ChangeInteractive -= ChangeEnabled;
    }

    void Start()
    { 
        type = InteractiveTypes.Item;
        solved = false;
    }

    private void OnMouseDown()
    {
        if (isEnabled)
        {
            activeSprite.color = Color.white;
            Item.TakeItem?.Invoke(this.gameObject);
            foreach (Transform child in GameObject.FindGameObjectWithTag("DialogueHolder").transform)
            {
                child.gameObject.SetActive(false);
            }
            dialogue.SetActive(true);
        }
    }
    private void ChangeEnabled()
    {
        isEnabled = !isEnabled;
    }
}