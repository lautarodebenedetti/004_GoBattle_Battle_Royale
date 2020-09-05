using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorArma : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            girarArmaDerecha();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            girarArmaIzquierda();
        }
    }

    void girarArmaDerecha()
    {
        transform.Rotate(new Vector3(0f, 0f, 1000f)*Time.deltaTime);
    }

    void girarArmaIzquierda()
    {
        transform.Rotate(new Vector3(0f, 0f, -1000f) * Time.deltaTime);
    }
}
