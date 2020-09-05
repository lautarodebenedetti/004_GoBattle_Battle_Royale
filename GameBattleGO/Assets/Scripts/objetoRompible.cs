using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoRompible : MonoBehaviour
{
    public GameObject objetoRoto;
    public float segundos = 3;
    private AudioSource audioSource;
    private AudioClip audioBreakBox;
    private AudioClip audioBreakVase;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioBreakBox = (AudioClip)Resources.Load("Sounds/BreakBox");
        audioBreakVase = (AudioClip)Resources.Load("Sounds/BreakVase");
    }

    // Update is called once per frame
    void Update()
    { 

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name== "bala")
        {
            romperObjeto();
        }
    }

    void OnMouseDown()//TODO: Cuando armemos colisiones, se tendrá que reemplazar esto!
    {
        //romperObjeto();
    }

    void romperObjeto()
    {
        GameObject aux = Instantiate(objetoRoto,transform.position, transform.rotation); //Guardo el objeto roto instanciado
        if(gameObject.ToString().Contains("caja"))
        {
            aux.AddComponent<AudioSource>();
            aux.GetComponent<AudioSource>().PlayOneShot(audioBreakBox);
        } else if (gameObject.ToString().Contains("jarron"))
        {
            aux.AddComponent<AudioSource>();
            aux.GetComponent<AudioSource>().PlayOneShot(audioBreakVase);
        }
        Destroy(gameObject); //Destruyo el original, lo elimino
        eliminarObjetoRoto(aux,segundos); //El objeto roto pasado un lapso de tiempo especificado en segundos, se eliminará para reducir la cantidad de poligonos!
    }

    void eliminarObjetoRoto(GameObject obj, float seg)
    {
        Object.Destroy(obj, seg);
    }
}
