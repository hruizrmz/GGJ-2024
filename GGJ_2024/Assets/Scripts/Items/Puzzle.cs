using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Puzzle : Interactable
{
    public GameObject dialogue;
    public string soundName;
    private bool isEnabled = true;
    public bool isLockGone, isPaintingGone, isKeyUsed, isRedLockGone, isDoorDialogue;

    private void OnEnable()
    {
        Icon.SolvePuzzle += SolveMe;
        Dialogue.ChangeInteractive += ChangeEnabled;
        PasswordController.ChangeInteractive += ChangeEnabled;
        Timer.OnTimerCompleted += DeleteMe;
        AlarmController.AlarmSilenced += DeleteMe;
    }
    private void OnDisable()
    {
        Icon.SolvePuzzle -= SolveMe;
        Dialogue.ChangeInteractive -= ChangeEnabled;
        PasswordController.ChangeInteractive -= ChangeEnabled;
        Timer.OnTimerCompleted -= DeleteMe;
        AlarmController.AlarmSilenced -= DeleteMe;
    }
    private void Start()
    {
        type = InteractiveTypes.Puzzle;
        solved = false;
    }

    private void OnMouseDown()
    {
        if (!solved && isEnabled)
        {
            AudioManager.instance.PlaySFX(soundName);
            foreach (Transform child in GameObject.FindGameObjectWithTag("DialogueHolder").transform)
            {
                child.gameObject.SetActive(false);
            }
            dialogue.SetActive(true);
        }
    }
    private void SolveMe(int ID)
    {
        if (ID == this.ID)
        {
            solved = true;
            activeSprite.color = Color.green;
            DeleteMe();

            if (isLockGone)
            {
                GameObject.FindGameObjectWithTag("ClosetDoor").SetActive(false);
                GameObject.FindGameObjectWithTag("OpenCloset").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("PieceItem").transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (isPaintingGone)
            {

                GameObject.FindGameObjectWithTag("CompletePainting").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("StarKey").transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (isKeyUsed)
            {
                GameObject.FindGameObjectWithTag("Alarm").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("StarKey").SetActive(false);
            }
            else if (isRedLockGone)
            {
                GameObject.FindGameObjectWithTag("RoomDoor").SetActive(false);
                GameObject.FindGameObjectWithTag("OpenDoor").transform.GetChild(0).gameObject.SetActive(true);
            }
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