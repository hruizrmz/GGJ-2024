using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCamera : MonoBehaviour
{
    private int count = 0;
    private bool isEnabled = true;
    public bool gotKey = false;
    public GameObject Targetposition;

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
                if (!gotKey)
                {
                    count++;
                }
                Targetposition.transform.position = new Vector3(21, 0, -10);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!gotKey)
                {
                    count++;
                }
                Targetposition.transform.position = new Vector3(-21, 0, -10);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!gotKey)
                {
                    if (count % 2 == 0)
                    {
                        GameObject.FindGameObjectWithTag("KeyReflection").transform.GetChild(0).gameObject.SetActive(true);
                        GameObject.FindGameObjectWithTag("GreenKey").transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                Targetposition.transform.position = new Vector3(0, -13, -10);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Targetposition.transform.position = new Vector3(0, 0, -10);
            }
            if (!gotKey)
            {
                if (count % 2 != 0)
                {
                    GameObject.FindGameObjectWithTag("KeyReflection").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenKey").transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

    private void ChangeEnabled()
    {
        isEnabled = !isEnabled;
    }
}
