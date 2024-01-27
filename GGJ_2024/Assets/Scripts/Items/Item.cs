using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interactable
{
    public string soundName;
    public GameObject dialogue;
    public ItemInfo itemInfo;
    public static event Action<GameObject> TakeItem;
    private bool isEnabled = true;
    public bool isGreenKey;

    private void OnEnable()
    {
        Dialogue.ChangeInteractive += ChangeEnabled;
        PasswordController.ChangeInteractive += ChangeEnabled;
        Timer.OnTimerCompleted += DeleteMe;
        AlarmController.AlarmSilenced += DeleteMe;
    }
    private void OnDisable()
    {
        Dialogue.ChangeInteractive -= ChangeEnabled;
        PasswordController.ChangeInteractive -= ChangeEnabled;
        Timer.OnTimerCompleted -= DeleteMe;
        AlarmController.AlarmSilenced -= DeleteMe;
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
            AudioManager.instance.PlaySFX(soundName);
            if (isGreenKey)
            {
                GameObject.FindGameObjectWithTag("KeyReflection").transform.GetChild(0).gameObject.SetActive(false);
                Camera.main.GetComponent<ArrowCamera>().gotKey = true;
            }
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

    private void DeleteMe()
    {
        Destroy(gameObject);
    }
}