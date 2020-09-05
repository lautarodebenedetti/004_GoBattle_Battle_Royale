using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisorBala : MonoBehaviour
{
    public GameObject bala;
    public GameObject emisor;
    public static GameObject arma;
    public float seg = 3;
    public static float velocidad;
    public static float frecuencia;
    public static int totalMunicion;
    public static int municion;
    public static float puedoDisparar;
    public static int dano;
    public GameObject player;
    public GameObject mira;
    private Camera camara;
    private AudioSource audioSource;
    private AudioClip audioAmetralladora;
    private AudioClip audioPistola;
    private AudioClip audioEscopeta;
    private bool isPosibleToShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        ObtenerCamara();
        totalMunicion = 0;
        puedoDisparar = 0;
        municion = 0;
        isPosibleToShoot = true;
        arma = null;
        audioSource = GetComponent<AudioSource>();
        audioPistola = ((AudioClip)Resources.Load("Sounds/WeaponGun"));
        audioAmetralladora = ((AudioClip)Resources.Load("Sounds/WeaponMachineGun"));
        audioEscopeta = ((AudioClip)Resources.Load("Sounds/WeaponShotgun"));
    }

    // Update is called once per frame
    void Update() 
    {
        puedoDisparar = puedoDisparar + Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X) && puedoDisparar>=frecuencia && arma != null)
        {
            disparar();
            puedoDisparar = 0; //Reseteo el tiempo de disparo
            print("MUNICIÓN: " + municion);
        }

        if ((Input.GetKeyDown(KeyCode.R))) //Recargo cuando la municion
        {
            recargarMunicion();
        }
    }

    public void Shoot()
    {
        if (isPosibleToShoot)
        {
            disparar();
        }
        puedoDisparar = 0; //Reseteo el tiempo de disparo
        if (municion == 0 && totalMunicion > 0)
        {
            recargarMunicion();
        }
    }
    void disparar()
    {
        //Creamos la instancia de la bala.
        if (municion > 0) {
            isPosibleToShoot = false;
            PlaySoundShoot();
            //TODO: No se de donde levantar la rotación de la bala al momento de emitirse!
        //GameObject aux = Instantiate(bala, emisor.transform.position, emisor.transform.rotation) as GameObject;
            GameObject aux = Instantiate(bala, emisor.transform.position, camara.transform.rotation) as GameObject;
            // Vector3 newRotation = new Vector3(arma.transform.eulerAngles.x, arma.transform.eulerAngles.y, arma.transform.eulerAngles.z);
            //this.transform.eulerAngles = newRotation;
            //aux.transform.Rotate(Vector3.left* 90);
            aux.name = "bala";
            Rigidbody fisica = aux.GetComponent<Rigidbody>();
            fisica.AddForce(transform.forward * velocidad);
            municion--;
            Destroy(aux, seg);
            StartCoroutine(WaitForFrecuencyShoot());
        }
    }

    public static void agarrarMunicion()
    {
        totalMunicion = totalMunicion + 50;
        print("EL TOTAL DE MUNICION COLECTADA ES DE: "+totalMunicion);
    }

    public static void recargarMunicion()
    {
        if (arma != null) { 
        int aux = 50 - municion; //50 es el máximo de balas, calculo lo que me falta!
        if (totalMunicion >= aux && municion < 50)
        {
            municion = municion + aux;
            totalMunicion = totalMunicion - aux;
            print("RECARGUE UN TOTAL DE:" + aux + " BALAS");
        }
        else
        {
            municion = municion + totalMunicion; //Si no alcanzo a poner lo que necesito, le pongo todo.
            print("RECARGUE UN TOTAL DE:" + totalMunicion + " BALAS");
            totalMunicion = 0;
        }
            print("EL TOTAL DE MUNICION ES DE: "+totalMunicion);
        }
    }

    public static void agarrarArma(GameObject a)
    {
        arma = a;
        agarrarMunicion();
        recargarMunicion();
        setConfiguracionArma(a);
    }
    public static void setConfiguracionArma(GameObject a)
    {
        if (a != null) {
            string tipo = a.tag;
           
            if (tipo == "pistola")
            {
                frecuencia = Constants.frecuencyWeaponGun;
                velocidad = Constants.velocityWeaponGun;
                dano = Constants.damageWeaponGun;
            }

            if (tipo == "escopeta")
            {
                frecuencia = Constants.frecuencyWeaponShotgun;
                velocidad = Constants.velocityWeaponShotgun;
                dano = Constants.damageWeaponShotgun;
            }

            if (tipo == "ametralladora")
            {
                frecuencia = Constants.frecuencyWeaponMachineGun;
                velocidad = Constants.velocityWeaponMachineGun;
                dano = Constants.damageWeaponMachineGun;
            }
        }
    }

    private IEnumerator WaitForFrecuencyShoot()
    {
        yield return new WaitForSeconds(frecuencia);
        isPosibleToShoot = true;
    }

    private void PlaySoundShoot()
    {
        if (arma != null && arma.tag == "ametralladora" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioAmetralladora);
        }
        else if (arma != null && arma.tag == "pistola" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioPistola);
        }
        else if (arma != null && arma.tag == "escopeta" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioEscopeta);
        }
    }

    private void ObtenerCamara()
    {
        this.camara = DataGame.IsViewInthirdPerson ?
            GameObject.Find("ThirdPersonCamera").GetComponent<Camera>() :
            GameObject.Find("FirstPersonCamera").GetComponent<Camera>();
    }
}
