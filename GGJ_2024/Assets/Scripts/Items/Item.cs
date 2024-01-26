using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public ItemInfo itemInfo;
    public static event Action<GameObject> TakeItem; 

    void Start()
    { 
        type = InteractiveTypes.Item;
        solved = false;
    }

    private void OnMouseDown()
    {
        activeSprite.color = Color.white;
        Item.TakeItem?.Invoke(this.gameObject);
    }
}