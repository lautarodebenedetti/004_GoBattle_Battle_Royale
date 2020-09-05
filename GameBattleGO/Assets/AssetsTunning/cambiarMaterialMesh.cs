using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarMaterialMesh : MonoBehaviour
{
    public GameObject mesh;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void aplicarPrevio()
    {
        Renderer rend = mesh.GetComponent<Renderer>();
        if (rend != null)
        {
            print("APLICAR PREVIO");
            //rend.material = lista[i];
        }
    }

    public void aplicarSiguiente()
    {
        print("APLICAR PREVIO");
        Renderer rend = mesh.GetComponent<Renderer>();
        if (rend != null)
        {
            /*if (i < lista.Count)
            {
                rend.material = lista[i];
            }*/
        }
    }

    public void aplicarRandom()
    {
        Renderer rend = mesh.GetComponent<Renderer>();

        Color c = new Color(
                            Random.Range(0f, 1f),
                            Random.Range(0f, 1f),
                            Random.Range(0f, 1f));
        if (rend != null)
        {
            rend.material.SetColor("_Color", c);

        }
    }
}
