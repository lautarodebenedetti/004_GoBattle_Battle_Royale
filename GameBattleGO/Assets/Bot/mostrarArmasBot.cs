using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarArmasBot : MonoBehaviour
{
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject ametralladora;
    public GameObject bot;
    private string botActual;

    public bool pistolaActiva;
    public bool escopetaActiva;
    public bool ametralladoraActiva;

    private BotPlayer aux;
    private Animator anim;
    private emisorBalaBot emisor;


    // Start is called before the first frame update
    void Start()
    {
        emisor = new emisorBalaBot();
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
        //Vector3 posicionEmpty = new Vector3(bot.transform.position.x, bot.transform.position.y, bot.transform.position.z);
        setearVisibilidad();
    }

    public void setAux(BotPlayer a)
    {
        this.aux = a;
    }

    public void setBot(GameObject b)
    {
        this.bot = b;
    }
    public void mostrarPistola()
    {
        pistolaActiva = true;
        escopetaActiva = false;
        ametralladoraActiva = false;
        aux.mostrarPistola();
        setearVisibilidad();
    }

    public void mostrarEscopeta()
    {
        pistolaActiva = false;
        escopetaActiva = true;
        //Instantiate(this.ametralladora, bot.transform.position, bot.transform.rotation);
        ametralladoraActiva = false;
        aux.mostrarEscopeta();
        setearVisibilidad();
    }

    public void mostrarAmetralladora()
    {
        print("me pidieron que muestra la metralla");
        pistolaActiva = false;
        escopetaActiva = false;
        ametralladoraActiva = true;
        aux.mostrarAmetralladora();
        //ametralladora.gameObject.SetActive(true);
        setearVisibilidad();
    }

    public void setearPistola(GameObject p)
    {
        this.pistola = p;
    }

    public void setearEscopeta(GameObject e)
    {
        this.escopeta = e;
    }

    public void setearAmetralladora(GameObject a)
    {
        this.ametralladora = a;
    }

    public void mostrarNada()
    {
        pistolaActiva = false;
        escopetaActiva = false;
        ametralladoraActiva = false;
        setearVisibilidad();
    }

    //Setea visibilidad del arma actual.
    public void setearVisibilidad()
    {
        pistola.gameObject.SetActive(false);
        escopeta.gameObject.SetActive(false);
        ametralladora.gameObject.SetActive(false);

        if (pistolaActiva == true)
        {
            pistola.gameObject.SetActive(true);
        }
        if (escopetaActiva == true)
        {
            escopeta.gameObject.SetActive(true);
        }
        if (ametralladoraActiva == true)
        {
            ametralladora.gameObject.SetActive(true);
        }
    }
}
