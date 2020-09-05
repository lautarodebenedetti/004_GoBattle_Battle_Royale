using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarArmasPersonaje : MonoBehaviour
{
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject ametralladora;
    public static bool pistolaActiva;
    public static bool escopetaActiva;
    public static bool ametralladoraActiva;


    // Start is called before the first frame update
    void Start()
    {
        //Al comienzo desactivo las armas para que no se vean!
        pistola.gameObject.SetActive(false);
        escopeta.gameObject.SetActive(false);
        ametralladora.gameObject.SetActive(false);
        pistolaActiva = false;
        escopetaActiva = false;
        ametralladoraActiva = false;
    }

    // Update is called once per frame
    void Update()
    {
        setearVisibilidad();
    }

    public static void mostrarPistola()
    {
        pistolaActiva = true;
        escopetaActiva = false;
        ametralladoraActiva = false;
    }

    public static void mostrarEscopeta()
    {
        pistolaActiva = false;
        escopetaActiva = true;
        ametralladoraActiva = false;
    }

    public static void mostrarAmetralladora()
    {
        pistolaActiva = false;
        escopetaActiva = false;
        ametralladoraActiva = true;
    }

    public static void mostrarNada()
    {
        pistolaActiva = false;
        escopetaActiva = false;
        ametralladoraActiva = false;
    }

    //Setea visibilidad del arma actual.
    public void setearVisibilidad()
    {
        pistola.gameObject.SetActive(false);
        escopeta.gameObject.SetActive(false);
        ametralladora.gameObject.SetActive(false);
        if (pistolaActiva == true) { 
            pistola.gameObject.SetActive(true);
    }       
        if(escopetaActiva== true)
        {
            escopeta.gameObject.SetActive(true);
        }
        if (ametralladoraActiva == true)
        {
            ametralladora.gameObject.SetActive(true);
        }
    }
}