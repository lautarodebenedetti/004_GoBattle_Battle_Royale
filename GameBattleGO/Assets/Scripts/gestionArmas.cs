using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionArmas : MonoBehaviour
{
    public GameObject arma;
    public GameObject pistola;
    public GameObject escopeta;
    public GameObject ametralladora;
    public GameObject player; //Vamos a necesitar la posición XYZ y rotación del player!

    // Start is called before the first frame update
    void Start()
    {
        arma = null; //Inicialmente no tenemos arma!
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            tirarArma();
        }
    }

    public void tirarArma()
    {
        if (arma != null) {
            Vector3 posicionObjeto = new Vector3(player.transform.position.x + 5, player.transform.position.y+3, player.transform.position.z + 2);
            Instantiate(arma, posicionObjeto, player.transform.rotation);
            arma = null;
            emisorBala.agarrarArma(arma);
            animador.tiroelArma();
            mostrarArmasPersonaje.mostrarNada();
            print("AHORA NO TENGO MÁS ARMAS!");
          }
    }

  
     void OnCollisionEnter(Collision otroObjeto)
     {
         if (otroObjeto.gameObject.tag == "pistola" && arma==null)
         {
            print("Agarre la pistola!");
            arma = pistola;
            emisorBala.agarrarArma(arma);
            animador.tieneelArma();
            mostrarArmasPersonaje.mostrarPistola();
            
            Destroy(otroObjeto.gameObject);
         }

         if (otroObjeto.gameObject.tag == "escopeta" && arma == null)
         {
             print("Agarre la escopeta");
             arma = escopeta;
             emisorBala.agarrarArma(arma);
             animador.tieneelArma();
             mostrarArmasPersonaje.mostrarEscopeta();
             Destroy(otroObjeto.gameObject);
         }

         if (otroObjeto.gameObject.tag == "ametralladora" && arma == null)
         {
            print("Agarre la ametralladora!");
            arma = ametralladora;
            emisorBala.agarrarArma(arma);
            animador.tieneelArma();
            mostrarArmasPersonaje.mostrarAmetralladora();
            Destroy(otroObjeto.gameObject);
         }
        if (arma != null) {
            if (otroObjeto.gameObject.tag == "municionPistola" && arma.tag =="pistola")
            {
                print("Agarre la municion de la pistola!");
                emisorBala.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }

            if (otroObjeto.gameObject.tag == "municionEscopeta" && arma.tag == "escopeta")
            {
                print("Agarre la municion de la escopeta!");
                emisorBala.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }

            if (otroObjeto.gameObject.tag == "municionAmetralladora" && arma.tag == "ametralladora")
            {
                print("Agarre la municion de la ametralladora!");
                emisorBala.agarrarMunicion();
                Destroy(otroObjeto.gameObject);
            }
        }

    }
}
