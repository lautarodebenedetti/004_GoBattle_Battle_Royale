using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrevisualizadorMapa : MonoBehaviour
{
    public int dimX;
    public int dimY;
    public Transform empty;
    public GameObject sueloBosque;
    public GameObject sueloDesierto;
    public GameObject sueloNieve;
    public GameObject sueloActual;
    public static TypeOfLand typeOfLand;
    private char[,] vectorMapa;
    public Camera camara;
    //DENSIDADES
    private int densidadAgua;
    private int densidadVegetacion;
    private int densidadObjetos;
    public static int densidadArmas = 10; //La suma de armas y munición = 25!
    public static int densidadMunicion = 15;

    void Start()
    {
        char[,] vectorMapa;
        Mapa mapa = DataGame.ActualMap;
        GetValuesOfDataGame();
        if (mapa != null)
        {
            vectorMapa = mapa.map;
        }
        else
        {
            //Al iniciar el juego creo el mapa: genero el mapa con las dimensiones x e y y las densidades.
            vectorMapa = generadorVectorMapa.construirVectorMapa(dimX, dimY, densidadVegetacion, densidadAgua, densidadObjetos, densidadArmas, densidadMunicion);
        }
        //Lo dibujo.
        dibujarMapa(vectorMapa);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void dibujarMapa(char[,] vectorMapa)
    {
        Vector3 posicionEmpty = new Vector3(empty.position.x, empty.position.y, empty.position.z); //Tomo posición empty inicial
        float posIniX = empty.position.x;
        float posIniZ = empty.position.z;
        setTipoSuelo();
        for (int i = 0; i < vectorMapa.GetLength(0); i++)
        {
            for (int j = 0; j < vectorMapa.GetLength(1); j++)
            {
                posicionEmpty = new Vector3(posIniX + (i * 5), empty.position.y, posIniZ + (j * 5) + 3);
                empty.position = posicionEmpty;
                if (vectorMapa[i, j] != 'A') //El previsualizador solo muestra el suelo!
                {
                    Instantiate(sueloActual, empty.position, empty.rotation);
                }
            }
        }
    }

    private void setTipoSuelo()
    {
        if (typeOfLand == TypeOfLand.FOREST)
        {
            sueloActual = sueloBosque;
            return;
        }
        else if (typeOfLand == TypeOfLand.DESERT)
        {
            sueloActual = sueloDesierto;
            return;
        }
        else if (typeOfLand == TypeOfLand.SNOW)
        {
            sueloActual = sueloNieve;
            return;
        }
        sueloActual = sueloBosque;
        return;
    }

    private void GetValuesOfDataGame()
    {
        densidadAgua = (int)(DataGame.ValueSliderWater * 50);
        densidadVegetacion = (int)(DataGame.ValueSliderForest * 50);
        densidadObjetos = (int)(DataGame.ValueSliderRompibleObject * 50);
        typeOfLand = DataGame.TypeOfLand;
    }


    public byte[] capturar()
    {
        int ancho = 250;
        int alto = 250;
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
        string filename = "Test.jpg";
        System.IO.File.WriteAllBytes(Application.persistentDataPath + filename, imagen);
        return imagen;
    }
}
