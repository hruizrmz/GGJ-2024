using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerVideo : MonoBehaviour
{
    public GameObject video;
    public GameObject MainMenu;
    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(5, video));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject video)
    {
        yield return new WaitForSeconds(seconds);
        video.SetActive(false);
        MainMenu.SetActive(true);
    }
}
