using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotAnimation : MonoBehaviour
{
    private Animator anim;

    #region Actions
    private void OnEnable()
    {
        InventoryControl.OpenMenu += MoveUp;
        InventoryControl.CloseMenu += MoveDown;
    }
    private void OnDisable()
    {
        InventoryControl.OpenMenu -= MoveUp;
        InventoryControl.CloseMenu -= MoveDown;
    }
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void MoveUp()
    {
        anim.ResetTrigger("IdleTrigger");
        anim.ResetTrigger("OpenTrigger");
        anim.ResetTrigger("DownTrigger");
        anim.SetTrigger("UpTrigger");
    }

    private void MoveDown()
    {
        anim.ResetTrigger("OpenTrigger");
        anim.ResetTrigger("UpTrigger");
        anim.SetTrigger("DownTrigger");
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
}
