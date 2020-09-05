using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPlayer : MonoBehaviour
{
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    private AnimadorBot animadorBot;
    private emisorBalaBot emisorBalas;
    private gestionArmasBot gestorArmas;
    public Animator anim;
    private int id = 02;
    private double life = 100;
    private float moveSpeed = 1f;
    private float jumpForce = 3.5f;
    private double score;
    private bool isGrounded = false;
    private Rigidbody thisRigibody;
    private Transform camTransform;
    public GameObject characterPlayer;
    private mostrarArmasBot mostrarArmas;
    private bool isPlayerInRange = false;
    private bool isPlayerShooting = false;
    private float frecuency = 0f;
    private AudioSource audioSource;
    private AudioClip audioFall;
    private AudioClip audioWalk;
    private AudioClip audioRun;
    private AudioClip audioAmetralladora;
    private AudioClip audioPistola;
    private AudioClip audioEscopeta;


    public GameObject pistola;
    public GameObject escopeta;
    public GameObject ametralladora;

    void Start()
    {
        print("mi nombre es: " + this.name);
        pistola = GameObject.Find("/bot/armasBot/pistolaBot");
        escopeta = GameObject.Find("/bot/armasBot/escopetaBot");
        ametralladora = GameObject.Find("/bot/armasBot/ametralladoraBot");
        
        //Seteando el animador para el bot.
        animadorBot = new AnimadorBot();
        anim = GetComponent<Animator>();
        animadorBot.setAnim(anim);
        animadorBot.setearCaer();

        //Seteando el emisor de balas.
        emisorBalas = new emisorBalaBot();

        //Seteando el gestor de armas. Los objetos que se mandan por parametro se nullean, ¿Porque?
        gestorArmas = new gestionArmasBot();
        gestorArmas.setAnimador(animadorBot);
        gestorArmas.setEmisorArmas(emisorBalas);
        gestorArmas.setMostrarArmas(mostrarArmas);
        gestorArmas.setBotPlayer(this);

        //Seteando el mostrar armas, esta clase llama al bot para indicarle que arma mostrar.
        mostrarArmas = new mostrarArmasBot();
        mostrarArmas.setAux(this);

        thisRigibody = gameObject.AddComponent<Rigidbody>();
        moveSpeed = Constants.moveSpeedBot;
        DataGame.IdPlayers.Add(this.name[this.name.Length - 1]);
        audioSource = GetComponent<AudioSource>();
        audioFall = ((AudioClip)Resources.Load("Sounds/PlayerFall"));
        audioWalk = ((AudioClip)Resources.Load("Sounds/PlayerWalk"));
        audioRun = ((AudioClip)Resources.Load("Sounds/PlayerRun"));
        audioPistola = ((AudioClip)Resources.Load("Sounds/WeaponGun"));
        audioAmetralladora = ((AudioClip)Resources.Load("Sounds/WeaponMachineGun"));
        audioEscopeta = ((AudioClip)Resources.Load("Sounds/WeaponShotgun"));
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            Shoot();
        }
        Move();  
    }

    private void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (isThisPositionCloseToOtherPosition(transform.position, player.transform.position))
        {
            isPlayerInRange = true;
        } else
        {
            Vector3 moveDirection = transform.position - player.transform.position;
            transform.Translate(-moveDirection.normalized * moveSpeed * Time.deltaTime);
            animadorBot.moverse();
            //ACA VIENE LO DE DETECTAR SI VA A PISAR EL AGUA O NO
           // Debug.Log(DetectWaterInThisDirection(-moveDirection.normalized * moveSpeed * Time.deltaTime));
            isPlayerInRange = false;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioWalk);
            }
        }
    }

    private bool DetectWaterInThisDirection(Vector3 positionBot)
    {
        
        //positionBot.
        return false;
    }

    private void RotateBot(GameObject target)
    {
        transform.LookAt(target.transform.position);
    }

    private void Shoot()
    {
        //Obtengo las armas del bot.
        GameObject armas = transform.GetChild(2).gameObject;
        GameObject arma;
        if(armas.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            arma = armas.transform.GetChild(1).gameObject;
            frecuency = Constants.frecuencyWeaponShotgun;
        } else if (armas.transform.GetChild(2).gameObject.activeInHierarchy)
        {
            arma = armas.transform.GetChild(2).gameObject;
            frecuency = Constants.frecuencyWeaponMachineGun;
        } else if (armas.transform.GetChild(3).gameObject.activeInHierarchy)
        {
            arma = armas.transform.GetChild(3).gameObject;
            frecuency = Constants.frecuencyWeaponGun;
        }
        else
        {
            arma = null;
        }
        if(arma != null && !isPlayerShooting) {
            PlaySoundShoot(arma);
            isPlayerShooting = true;
            StartCoroutine(WaitForShoot(arma, armas.transform.GetChild(0).gameObject));
        }
    }

    private IEnumerator WaitForShoot(GameObject arma, GameObject emisorBalasGameObject)
    {
        RotateBot(GameObject.FindGameObjectWithTag("Player"));
        emisorBalas.disparar(arma, emisorBalasGameObject);
        yield return new WaitForSeconds(frecuency);
        isPlayerShooting = false;
    }

    private bool isThisPositionCloseToOtherPosition(Vector3 position1, Vector3 position2)
    {
        Double distanceX = position1.x - position2.x;
        Double distanceZ = position1.z - position2.z;
        return distanceX < 20 && distanceX > -20 && distanceZ < 20 && distanceZ > -20;
    }

    private void mostrarlasArmas()
    { 
        pistola.SetActive(true);
        escopeta.SetActive(true);
        ametralladora.SetActive(false);
    }

    public void mostrarPistola()
    {
        print("Un bot me pidio que mostrara la pistola!");
        pistola.SetActive(true);
        escopeta.SetActive(false);
        ametralladora.SetActive(false);
    }


    public void mostrarEscopeta()
    {
        print("Un bot me pidio que mostrara la escopeta!");
        pistola.SetActive(false);
        escopeta.SetActive(true);
        ametralladora.SetActive(false);
    }


    public void mostrarAmetralladora()
    {
        print("Un bot me pidio que mostrara la ametralladora!");
        pistola.SetActive(false);
        escopeta.SetActive(false);
        ametralladora.SetActive(true);
    }

    public void ImpactDamgeAndreduceLife(double damage)
    {
        this.life -= damage;
        if (this.life <= 0)
        {
            this.Die();
        }
    }

    public void Die()
    {
        DataGame.IdPlayers.Remove(id);
        gameObject.SetActive(false); //Lo saco del juego.
    }
    void OnCollisionStay() //this hapen when the player touch the floor
    {
        isGrounded = true;
        //Se le avisa al animador, que el personaje esta en el suelo!
        this.animadorBot.llegoalSuelo();
        this.animadorBot.setearIdle();
        
    }
    public void Jump()
    {
        if (isGrounded)
        {
            thisRigibody.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
            this.animadorBot.saltar();
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision colision) {
        if (colision.gameObject.name == "suelo")
        {
            isGrounded = true; //Le aviso al animador que toco el suelo.
            this.animadorBot.llegoalSuelo();
            audioSource.PlayOneShot(audioFall);
        }

        if (colision.gameObject.name == "bala")
        {
            //Si aca obtengo el tipo de arma, se lo descuento al player de las constantes
            Debug.Log(colision.gameObject);
            ImpactDamgeAndreduceLife(20f);
            Destroy(colision.gameObject);
        }
    }

    private void PlaySoundShoot(GameObject arma)
    {
        if (arma.tag == "ametralladoraBot" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioAmetralladora);
        }
        else if (arma.tag == "pistolaBot" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioPistola);
        }
        else if (arma.tag == "escopetaBot" && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioEscopeta);
        }
    }
}