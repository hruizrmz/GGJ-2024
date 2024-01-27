using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryControl : MonoBehaviour
{
    public int size;
    private int maxSize = 3;
    private bool hoveringIcon, draggingIcon;
    [SerializeField] public Slot[] slots = new Slot[3];
    private Animator anim;
    public static event Action OpenMenu, CloseMenu;

    #region Actions
    private void OnEnable()
    {
        Item.TakeItem += AddItem;
        Icon.UseItem += RemoveItem;
        Icon.ChangeDrag += ChangeIconDrag;
        Icon.ChangeHover += ChangeIconHover;
        Timer.OnTimerCompleted += DeleteMe;
        AlarmController.AlarmSilenced += DeleteMe;
    }
    private void OnDisable()
    {
        Item.TakeItem -= AddItem;
        Icon.UseItem -= RemoveItem;
        Icon.ChangeDrag -= ChangeIconDrag;
        Icon.ChangeHover -= ChangeIconHover;
        Timer.OnTimerCompleted -= DeleteMe;
        AlarmController.AlarmSilenced -= DeleteMe;
    }
    #endregion

    private void Start()
    {
        size = 0;
        draggingIcon = false;
        anim = GetComponent<Animator>();
    }

    public void ChangeIconDrag()
    {
        draggingIcon = !draggingIcon;
        if (!draggingIcon)
        {
            InventoryControl.CloseMenu?.Invoke();
            anim.ResetTrigger("OpenTrigger");
            anim.ResetTrigger("UpTrigger");
            anim.SetTrigger("DownTrigger");
        }
    }

    public void ChangeIconHover()
    {
        hoveringIcon = !hoveringIcon;
    }

    public void PointerEnter()
    {
        InventoryControl.OpenMenu?.Invoke();
        anim.ResetTrigger("IdleTrigger");
        anim.ResetTrigger("OpenTrigger");
        anim.ResetTrigger("DownTrigger");
        anim.SetTrigger("UpTrigger");
    }

    public void PointerExit()
    {
        if (!draggingIcon && !hoveringIcon)
        {
            InventoryControl.CloseMenu?.Invoke();
            anim.ResetTrigger("OpenTrigger");
            anim.ResetTrigger("UpTrigger");
            anim.SetTrigger("DownTrigger");
        }
    }

    public void SetOpenMenu()
    {
        anim.ResetTrigger("UpTrigger");
        anim.SetTrigger("OpenTrigger");
    }

    public void SetIdleMenu()
    {
        anim.ResetTrigger("DownTrigger");
        anim.SetTrigger("IdleTrigger");
    }

    private void AddItem(GameObject newItem)
    {
        if (size<maxSize)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemInSlot == null)
                {
                    slots[i].SetStats(newItem.gameObject.GetComponent<Item>());
                    size++;
                    Destroy(newItem);
                    break;
                }
            }
        }
    }

    private void RemoveItem(GameObject byeItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemInSlot == byeItem.gameObject.GetComponent<Icon>().itemInfo)
            {
                slots[i].SetStats(null);
                size--;
                break;
            }
        }
    }

    private void DeleteMe()
    {
        Destroy(gameObject);
    }
}
