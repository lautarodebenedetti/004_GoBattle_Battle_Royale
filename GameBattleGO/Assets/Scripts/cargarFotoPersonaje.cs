using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class cargarFotoPersonaje : MonoBehaviour
{
    public RawImage img;
    Texture2D foto;
    byte[] fileData;

    // Start is called before the first frame update
    void Start()

    {
        //Carga la foto del personaje en la rawImage
        string filePath = Application.persistentDataPath + "personaje.jpg";
        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            foto = new Texture2D(2, 2);
            foto.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            img.texture = (Texture)foto;
        }
    }


    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TunearPersonaje");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
