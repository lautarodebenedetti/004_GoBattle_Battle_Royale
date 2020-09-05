using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamara : MonoBehaviour
{
    public Camera c1;
    public Camera c2;
    public Camera c3;
    public Camera c4;
    public Camera camaraActual;

    // Start is called before the first frame update
    void Start()
    {
        c1.enabled = false;
        c2.enabled = false;
        c3.enabled = true;
        c4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            c1.enabled = true;
            c2.enabled = false;
            c3.enabled = false;
            c4.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            c1.enabled = false;
            c2.enabled = true;
            c3.enabled = false;
            c4.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            c1.enabled = false;
            c2.enabled = false;
            c3.enabled = true;
            c4.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            c1.enabled = false;
            c2.enabled = false;
            c3.enabled = false;
            c4.enabled = true;
        }
    }
}
