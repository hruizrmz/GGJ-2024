using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMover : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(27.36f, -5.21f, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-14.62f, -5.21f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(6.36f, -18.22f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(6.36f, -5.21f, 0);
        }
    }
}
