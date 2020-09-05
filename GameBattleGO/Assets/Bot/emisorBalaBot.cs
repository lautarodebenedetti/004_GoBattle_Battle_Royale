using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisorBalaBot : MonoBehaviour
{
    public GameObject bala;
    public GameObject emisor;
    public GameObject arma;
    public float seg = 3f;
    public static float velocidad;
    public static int totalMunicion;
    public static int municion;
    public static float puedoDisparar;
    public static int dano;
    
    void Start()
    {
        totalMunicion = 0;
        puedoDisparar = 0;
        arma = null;
        seg = 3f;
    }

    public void setEmitter(GameObject e)
    {
        this.emisor = e;
    }

    public void setArma(GameObject a)
    {
        this.arma = a;
    }

    public void disparar(GameObject a, GameObject e)
    {
        arma = a;
        emisor = e;
        setConfiguracionArma(a);
        municion = 50;
        recargarMunicion();
        puedoDisparar = puedoDisparar + Time.deltaTime;

        if (municion > 0 && arma != null)
        {
            bala = GameObject.Find("bala");
            Vector3 posicionEmisor = new Vector3(emisor.transform.position.x, emisor.transform.position.y, emisor.transform.position.z);
            GameObject aux = Instantiate(bala, posicionEmisor, emisor.transform.rotation) as GameObject;
            aux.name = "bala";
            Rigidbody fisica = aux.GetComponent<Rigidbody>();
            fisica.AddForce(emisor.transform.forward * velocidad);
            municion--;
            Destroy(aux, seg);
            puedoDisparar = 0; //Reseteo el tiempo de disparo
        }
    }

    public void agarrarMunicion()
    {
        totalMunicion = totalMunicion + 50;
        recargarMunicion();
    }

    public void recargarMunicion()
    {
    //    print("EL BOT RECARGÓ MUNICIÓN");
        if (arma != null)
        {
            int aux = 50 - municion; //50 es el máximo de balas, calculo lo que me falta!
            if (totalMunicion >= aux && municion < 50)
            {
                municion = municion + aux;
                totalMunicion = totalMunicion - aux;
            }
            else
            {
                municion = municion + totalMunicion; //Si no alcanzo a poner lo que necesito, le pongo todo.
                totalMunicion = 0;
            }
        }
    }

    public void agarrarArma(GameObject a)
    {
        arma = a;
        agarrarMunicion();
        recargarMunicion();
        setConfiguracionArma(a);
    }
    public void setConfiguracionArma(GameObject a)
    {
        if (a != null)
        {
            string tipo = a.tag;
            if (tipo == "pistola" || tipo == "pistolaBot")
            {
                velocidad = Constants.velocityWeaponGun;
                dano = Constants.damageWeaponGun;
            }

            if (tipo == "escopeta" || tipo == "escopetaBot")
            {
                velocidad = Constants.velocityWeaponShotgun;
                dano = Constants.damageWeaponShotgun;
            }

            if (tipo == "ametralladora" || tipo == "ametralladoraBot")
            {
                velocidad = Constants.velocityWeaponMachineGun;
                dano = Constants.damageWeaponMachineGun;
            }
        }
    }
}
