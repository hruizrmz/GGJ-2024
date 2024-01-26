using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCamera : MonoBehaviour
{
    // Update is called once per frame
    public GameObject Targetposition;
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Targetposition.transform.position = new Vector3(19, 0, -10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Targetposition.transform.position = new Vector3(-19, 0, -10);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Targetposition.transform.position = new Vector3(0, -10, -10);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Targetposition.transform.position = new Vector3(0, 11, -10);
        }
    }
}
