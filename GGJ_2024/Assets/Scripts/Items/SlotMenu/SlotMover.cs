using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMover : MonoBehaviour
{
    private bool isEnabled = true;

    private void OnEnable()
    {
        Dialogue.ChangeInteractive += ChangeEnabled;
        PasswordController.ChangeInteractive += ChangeEnabled;
    }
    private void OnDisable()
    {
        Dialogue.ChangeInteractive -= ChangeEnabled;
        PasswordController.ChangeInteractive -= ChangeEnabled;
    }

    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(27.36f, -5.21f, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(-14.62f, -5.21f, 0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(6.36f, -18.22f, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(6.36f, -5.21f, 0);
            }
        }
    }

    private void ChangeEnabled()
    {
        isEnabled = !isEnabled;
    }
}
