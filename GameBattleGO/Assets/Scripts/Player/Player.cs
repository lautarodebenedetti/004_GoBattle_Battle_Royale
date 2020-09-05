using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick joystick;

    private int id = 01;
    private double life = 100;
    private float moveSpeed = 0.1f;
    private float jumpForce = 3.5f;
    private double score;
    private bool isGrounded = true;
    private Rigidbody thisRigibody;
    private Transform camTransform;
    private bool isThePlayerIntheAir = true;
    private AudioSource audioSource;
    private AudioClip audioFall;
    private AudioClip audioWalk;
    private AudioClip audioRun;
    public GameObject characterPlayer;

    void Start()
    {
        thisRigibody = gameObject.AddComponent<Rigidbody>();
        thisRigibody.maxAngularVelocity = terminalRotationSpeed;
        thisRigibody.drag = drag;
        moveSpeed = Constants.moveSpeedPlayer;
        DataGame.IdPlayers.Add(01);
        audioSource = GetComponent<AudioSource>();
        audioFall = ((AudioClip)Resources.Load("Sounds/PlayerFall"));
        audioWalk = ((AudioClip)Resources.Load("Sounds/PlayerWalk"));
        audioRun = ((AudioClip)Resources.Load("Sounds/PlayerRun"));
    }

    private void Update()
    {
        MoveVector = PoolInput();    //Get the original input.
        MoveVector = RotateView();   //Rotate the player in base of the camera.
        Move();                      //Move the player.
    }
    public void ImpactDamgeAndreduceLife(double damage)
    {
        this.life -= damage;
        if(this.life <= 0)
        {
            this.Die();
        }
    }

    public void Die()
    {
        DataGame.IdPlayers.Remove(id);
    }
    void OnCollisionStay() //this hapen when the player touch the floor
    {
        isGrounded = true;
        //Se le avisa al animador, que el personaje esta en el suelo!
        animador.estaCayendo = false;
        animador.estaenelSuelo = true;
        if (isThePlayerIntheAir && transform.position.y <= 7.18)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioFall);
            isThePlayerIntheAir = false;
        }
    }
    void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.name == "bala")
        {
            ImpactDamgeAndreduceLife(20f);
            Destroy(colision.gameObject);
        }
    }
    public void Jump()
    {
        if (isGrounded) {
            thisRigibody.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
            animador.saltar();
            isGrounded = false;
            isThePlayerIntheAir = true;
        }
        //ACA VA EL SONIDO DE SALTO
    }

    public void Shoot()
    {
        GameObject.Find("emitterBala").GetComponent<emisorBala>().Shoot();
    }


    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
            dir.Normalize();
        return dir;
    }

    private void Move()
    {
        // thisRigibody.AddForce((MoveVector * moveSpeed)); // this generate a rotation, is only usefull for generate a circle
        RotateCharacter(characterPlayer);
        transform.Translate(MoveVector * moveSpeed);
        if (MoveVector.x > 0.2 && !audioSource.isPlaying || MoveVector.z > 0.2 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioRun);
        }
        else if (MoveVector.x > 0 && !audioSource.isPlaying || MoveVector.z > 0 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioWalk);
        }
        else if (MoveVector.x <= 0 && MoveVector.y <= 0 && audioSource.isPlaying || MoveVector.z <= 0 && MoveVector.y <= 0 && audioSource.isPlaying)
        {
            // audioSource.Stop();
        }
    }

    private Vector3 RotateView()
    {
        if (camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(MoveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * MoveVector.magnitude;
        }
        else
        {
            //    camTransform = Camera.main.transform;
            camTransform = GetCameraTransform();
            return MoveVector;
        }
    }

    private Transform GetCameraTransform()
    {
        if (GameObject.Find("FirstPersonCamera") != null && GameObject.Find("FirstPersonCamera").GetComponent<Camera>().enabled)
        {
            return GameObject.Find("FirstPersonCamera").GetComponent<Camera>().transform;
        }
        else if (GameObject.Find("ThirdPersonCamera") != null && GameObject.Find("ThirdPersonCamera").GetComponent<Camera>().enabled)
        {
            return GameObject.Find("ThirdPersonCamera").GetComponent<Camera>().transform;
        }
        else
        {
            return Camera.main.transform;
        }
    }
    private void RotateCharacter(GameObject character)
    {

        if (0 <= joystick.Horizontal() && joystick.Horizontal() <= 1)
        {
            if (0 <= joystick.Vertical() && joystick.Vertical() <= 1)
            {
                character.transform.rotation = Quaternion.Euler(0, joystick.Horizontal() * 90, 0);
            }
            else if (-1 <= joystick.Vertical() && joystick.Vertical() < 0)
            {
                character.transform.rotation = Quaternion.Euler(0, 90 - joystick.Vertical() * 90, 0);
            }
        }
        else if (-1 <= joystick.Horizontal() && joystick.Horizontal() < 0)
        {
            if (-1 <= joystick.Vertical() && joystick.Vertical() < 0)
            {
                character.transform.rotation = Quaternion.Euler(0, 180 - joystick.Horizontal() * 90, 0);
            }
            else if (0 <= joystick.Vertical() && joystick.Vertical() < 1)
            {
                character.transform.rotation = Quaternion.Euler(0, 270 + joystick.Vertical() * 90, 0);
            }
        }
    }
}
