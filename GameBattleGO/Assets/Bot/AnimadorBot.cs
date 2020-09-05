using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorBot : MonoBehaviour
{
    public Animator anim;
    public bool estaIdle;
    public bool tieneArma;
    public bool estaenelSuelo;
    public bool estaCayendo;
    public bool seEstaMoviendo;
    public bool estaAgarrandoelArma;
    public bool estaSaltando;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //estaCayendo = true;
        //anim.Play("caer");
        //actualizarBooleanosControlador();
    }

    // Update is called once per frame
    void Update()

    {
        //Vamos a tener que cambiar esto, cuando armemos el movimiento del bot.
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
            
            estaIdle = !estaCayendo && true;
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
    public void setearIdle()
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

    public void setAnim(Animator a)
    {
        this.anim = a;
    }

    public void saltar()
    {
        estaSaltando = true;
        estaIdle = false;
        seEstaMoviendo = false;
        estaAgarrandoelArma = false;
        this.actualizarBooleanosControlador();
        if (tieneArma)
        {
            anim.Play("saltarArma");
        }
        else
        {
            anim.Play("saltar");
        }
    }

    public void actualizarBooleanosControlador()
    {
        this.anim.SetBool("estaIdle", estaIdle);
        this.anim.SetBool("tieneArma", tieneArma);
        this.anim.SetBool("estaCayendo", estaCayendo);
        this.anim.SetBool("seEstaMoviendo", seEstaMoviendo);
        this.anim.SetBool("estaenelSuelo", estaenelSuelo);
        this.anim.SetBool("estaAgarrandoelArma", estaAgarrandoelArma);
        this.anim.SetBool("estaSaltando", estaSaltando);
    }
    public void moverse()
    {
        if (!estaCayendo)
        {
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

    public void saludar(string nombre)
    {
        print("SALUDOS DESDE EL ANIMADOR"+nombre);
    }

    public void agarroelArma()
    {
        tieneArma = true;
        actualizarBooleanosControlador();
        anim.Play("agarrarArma");
    }

    public void tiroelArma()
    {
        tieneArma = false;
        actualizarBooleanosControlador();
        anim.Play("tirarArma");
    }


    public void setearCaer()
    {
        estaCayendo = true;
        anim.Play("caer");
        actualizarBooleanosControlador();
    }

    public void llegoalSuelo()
    {
        estaCayendo = false;
        //anim.Play("Idle");
        actualizarBooleanosControlador();
    }
}