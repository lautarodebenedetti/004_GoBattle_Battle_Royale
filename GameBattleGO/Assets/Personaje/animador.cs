using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animador : MonoBehaviour
{
    private static Animator anim;
    //BANDERAS PARA CONTROLAR LOS ESTADOS DE LAS ANIMACIONES!
    public static bool estaIdle;
    public static bool tieneArma;
    public static bool estaenelSuelo;
    public static bool estaCayendo;
    public static bool seEstaMoviendo;
    public static bool estaAgarrandoelArma;
    public static bool estaSaltando;
    
    // Start is called before the first frame update
    void Start()
    {
        estaCayendo = true;
        anim=GetComponent<Animator>();
        actualizarBooleanosControlador();
        anim.Play("caer");
    }

    // Update is called once per frame
    void Update()
        
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moverse();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moverse();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moverse();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moverse();
        }

        if (Input.anyKey == false)
        {
            estaIdle = true;
            seEstaMoviendo = false;
            estaSaltando = false;
            estaAgarrandoelArma = false;
            actualizarBooleanosControlador();
            if (tieneArma)
            {
                anim.Play("idleArma");
            }
            //anim.Play("idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar();
        }
   
    }

    public static void saltar()
    {
        estaSaltando = true;
        estaIdle = false;
        seEstaMoviendo = false;
        estaAgarrandoelArma = false;
        actualizarBooleanosControlador();
        if (tieneArma)
        {
            anim.Play("saltarArma");
        }
        else
        {
            anim.Play("saltar");
        }
       
    }

    private static void actualizarBooleanosControlador()
    {
        anim.SetBool("estaIdle", estaIdle);
        anim.SetBool("tieneArma", tieneArma);
        anim.SetBool("estaCayendo", estaCayendo);
        anim.SetBool("seEstaMoviendo", seEstaMoviendo);
        anim.SetBool("estaenelSuelo", estaenelSuelo);
        anim.SetBool("estaAgarrandoelArma", estaAgarrandoelArma);
        anim.SetBool("estaSaltando", estaSaltando);
    }

    public static void moverse()
    {
        if (!estaCayendo) { 
        estaIdle = false;
        estaSaltando = false;
        estaCayendo = false;
        seEstaMoviendo = true;
        actualizarBooleanosControlador();
        if (tieneArma)
        {
            anim.Play("moverseArma");
        }
        else
        {
            anim.Play("moverse");
        }
        }
    }

    public static void tieneelArma()
    {
        //estaAgarrandoelArma = true;
        tieneArma = true;
        actualizarBooleanosControlador();
        anim.Play("agarrarArma");
       


    }

    public static void tiroelArma()
    {
        //estaAgarrandoelArma = false;
        tieneArma = false;
        actualizarBooleanosControlador();
        anim.Play("tirarArma");
    }
}