using System;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    public SpriteRenderer activeSprite;
    private Color originalColor;
    public GameObject goodEndingScreen;
    public static event Action AlarmSilenced;

    private void OnMouseDown()
    {
        AlarmController.AlarmSilenced?.Invoke();
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlaySFX("Victory");
        goodEndingScreen.SetActive(true);
        Destroy(gameObject);
    }

    void OnMouseEnter()
    {
        originalColor = activeSprite.color;
        activeSprite.color = Color.grey;
    }

    void OnMouseExit()
    {
        activeSprite.color = originalColor;
    }
}
