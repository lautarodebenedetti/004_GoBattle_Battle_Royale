using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionArmasBot : MonoBehaviour
{
    public GameObject arma;
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject ametralladora;
    public GameObject emitter;
    public GameObject bot; //Vamos a necesitar la posición XYZ y rotación del player!
    private Animator anim;
    private emisorBalaBot emisorBalas;
    private mostrarArmasBot mostrarArmas;
    public BotPlayer botPlayer;
    private string nombreBot;
    public GameObject pistolaAux;
    public GameObject escopetaAux;
    public GameObject ametralladoraAux;

    // Start is called before the first frame update
    void Start()
    {
        nombreBot = this.name;
        
        //Los objetos de las armas ahora van a llamar a la arma del bot i
        ametralladoraAux = GameObject.Find("/"+nombreBot+"/armasBot/ametralladoraBot");
        pistolaAux = GameObject.Find("/" + nombreBot + "/armasBot/pistolaBot");
        escopetaAux = GameObject.Find("/" + nombreBot + "/armasBot/escopetaBot");
        emitter = GameObject.Find("/" + nombreBot + "/armasBot/emitterBalaBot");
        emisorBalas = new emisorBalaBot();
        emisorBalas.setEmitter(emitter);
        sinArmas();
        arma = null; //Inicialmente no tenemos arma!
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            tirarArma();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            print("LLAMO A DISPARAR!!!!");
            this.emisorBalas.disparar(this.arma,this.emitter);
        }
    }

    public void setNombreBot(string n)
    {
        this.nombreBot = n;
    }

    public void tirarArma()
    {
        if (arma != null)
        {
            Vector3 posicionObjeto = new Vector3(bot.transform.position.x + 5, bot.transform.position.y + 3, bot.transform.position.z + 2);
            Instantiate(arma, posicionObjeto, bot.transform.rotation);
            arma = null;
            emisorBalas.agarrarArma(arma);
            emisorBalas.setArma(null);
            this.anim.Play("tirarArma");
            this.anim.SetBool("tieneArma", false);
            sinArmas();
        }
    }

    public void sinArmas()
    {
        pistolaAux.SetActive(false);
        escopetaAux.SetActive(false);
        ametralladoraAux.SetActive(false);
    }

    public void setBotPlayer(BotPlayer b)
    {
        this.botPlayer = b;
    }

    public void setAnimador(AnimadorBot a)
    {
        //this.anim = a;  
    }


    public void setEmisorArmas(emisorBalaBot e)
    {
        this.emisorBalas = e;
        print("el emisor de balas es nulo: " + this.emisorBalas == null);
    }

    private void tieneelArma()
    {
        this.anim.SetBool("tieneArma", true);
        anim.Play("agarrarArma");
        anim.Play("idleArma");
    }

    public void setMostrarArmas(mostrarArmasBot m)
    {
        this.mostrarArmas = m;
    }

    void OnCollisionEnter(Collision otroObjeto)
    {

        if (otroObjeto.gameObject.tag == "pistola" && arma == null)
        {
            print("El bot agarró la pistola!");
            arma = pistola;
            
            pistolaAux.SetActive(true);
            escopetaAux.SetActive(false);
            ametralladoraAux.SetActive(false);
            tieneelArma();
            emisorBalas.setArma(arma);
            //emisorBalas.agarrarArma(arma);
            //this.anim.agarroelArma();
            //this.botPlayer.mostrarPistola();

            Destroy(otroObjeto.gameObject);
        }

        if (otroObjeto.gameObject.tag == "escopeta" && arma == null)
        {
            print("El bot agarró la escopeta");
            arma = escopeta;
            //emisorBalas.agarrarArma(arma);
            //this.anim.agarroelArma();
            //Aca pincha
            
            pistolaAux.SetActive(false);
            escopetaAux.SetActive(true);
            ametralladoraAux.SetActive(false);
            emisorBalas.setArma(arma);
            //this.botPlayer.mostrarEscopeta();
            //mostrarArmas.mostrarEscopeta();
            tieneelArma();
            Destroy(otroObjeto.gameObject);
        }

        if (otroObjeto.gameObject.tag == "ametralladora" && arma == null)
        {
            print("El bot agarró la ametralladora!");
            arma = ametralladora;
            //emisorBalas.agarrarArma(arma);
            //this.anim.agarroelArma();
            
            print("BOT PLAYER ES NULO: ");
            print(this.botPlayer == null);
            
            pistolaAux.SetActive(false);
            escopetaAux.SetActive(false);
            ametralladoraAux.SetActive(true);
            tieneelArma();
            emisorBalas.setArma(arma);
            //this.botPlayer.mostrarAmetralladora();
            //mostrarArmas.mostrarAmetralladora();
            Destroy(otroObjeto.gameObject);
        }
        if (arma != null)
        {
            if (otroObjeto.gameObject.tag == "municionPistola" && arma.tag == "pistola")
            {
                print("El bot agarró la municion de la pistola!");
                emisorBalas.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }

            if (otroObjeto.gameObject.tag == "municionEscopeta" && arma.tag == "escopeta")
            {
                print("El bot agarró la municion de la escopeta!");
                emisorBalas.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }

            if (otroObjeto.gameObject.tag == "municionAmetralladora" && arma.tag == "ametralladora")
            {
                print("El bot agarró la municion de la ametralladora!");
                emisorBalas.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }
        }

    }
}
