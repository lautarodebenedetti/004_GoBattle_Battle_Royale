using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fotografiarPersonaje : MonoBehaviour
{
    public Camera camara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            fotografiar();
        }
    }

    public void fotografiar()
    {
        int ancho = 525;
        int alto = 736;
        RenderTexture rt = new RenderTexture(ancho, alto, 24);
        camara.targetTexture = rt;
        Texture2D screenShot = new Texture2D(ancho, alto, TextureFormat.RGB24, false);
        camara.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, ancho, alto), 0, 0);
        camara.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] imagen = screenShot.EncodeToJPG();
        string filename = "personaje.jpg";
        System.IO.File.WriteAllBytes(Application.persistentDataPath + filename, imagen);
        //print(Application.persistentDataPath + filename);
        return;
    }
}
