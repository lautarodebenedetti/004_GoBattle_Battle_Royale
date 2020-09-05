using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class generadorSuelo : MonoBehaviour
{
    public int dimX;
    public int dimY;
    public static TypeOfLand typeOfLand;
    public static int densidadAgua = 13;
    public static int densidadVegetacion = 25;
    public static int densidadObjetos = 25;
    public static int densidadArmas = 10; //La suma de armas y munición = 25!
    public static int densidadMunicion = 15;
    public static char[,] vectorMapa;
    public Mapa mapaActual;
    private GameObject suelo;
    public GameObject sueloBosque;
    public GameObject sueloDesierto;
    public GameObject sueloNieve;
    public GameObject agua; //Nota de diseño: buscar un shader más copado para el agua.
    public Transform empty;
    public GameObject arbol1;
    public GameObject arbol2;
    public GameObject arbol3;
    public GameObject arbol4;
    public GameObject arbol5;
    public GameObject objetoRompible1;
    public GameObject objetoRompible2;
    public GameObject nada;
    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject municionPistola;
    public GameObject municionEscopeta;
    public GameObject municionAmetralladora;
    public Camera camara;
    
    void Start()
    {
        char[,] vectorMapa;
        Mapa mapa = DataGame.ActualMap;
        GetValuesOfDataGame();
        if (mapa != null)
        {
            vectorMapa = mapa.map;
        } else
        {
            //Al iniciar el juego creo el mapa: genero el mapa con las dimensiones x e y y las densidades.
            vectorMapa = generadorVectorMapa.construirVectorMapa(dimX, dimY, densidadVegetacion, densidadAgua, densidadObjetos, densidadArmas, densidadMunicion);
        }
        //Lo dibujo.
        dibujarMapa(vectorMapa);
        //El mapa creado pasa a ser el mapa actual!
        mapaActual = new Mapa(vectorMapa, capturar(), "Mapa", typeOfLand);
        GeneradorPersonajes gp = gameObject.AddComponent(typeof(GeneradorPersonajes)) as GeneradorPersonajes;
        gp.agregarBots(5, vectorMapa);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            print("LLAMANDO A CAPTURA DE MAPA!");
            capturar();
        }
    }

    public void SaveMap()
    {
        persistenciaMapas.GuardarMapas(mapaActual);
    }

    GameObject generarObjetosRompibles(char x)
    {
        GameObject a = null;
        int tipo = Random.Range(1, 4);
        switch (tipo)
        {
            case 1:
                a = objetoRompible1;
                break;
            case 2:
                a = objetoRompible2;
                break;
            case 3:
                a = nada;
                break;
        }
        return a;
        }

    GameObject generarVegetacion(char x)
    {
        GameObject a = null;
        int tipo = Random.Range(1, 6);
        switch (tipo)
        {
            case 1:
                a = arbol1;
                break;
            case 2:
                a = arbol2;
                break;
            case 3:
                a = arbol3;
                break;
            case 4:
                a = arbol4;
                break;
            case 5:
                a = arbol5;
                break;
        }
        return a;
    }


    GameObject generarVegetacion(char x, char tipoMapa)
    {
        //IDEA: ÁRBOLES POR CADA TIPO DE MAPA!
        GameObject a = null;
        int tipo = Random.Range(1, 5);
        switch (tipo)
        {
            case 1:
                a = arbol1;
                break;
            case 2:
                a = arbol2;
                break;
            case 3:
                a = arbol3;
                break;
            case 4:
                a = arbol4;
                break;
        }
        return a;
    }

    GameObject generarSuelo(char x)
    {
        GameObject objeto = null;
        if (x == 'A')
        {
            //objeto = agua;
            objeto = nada;
        }
        else
        {
            objeto = suelo;
            objeto.name = "suelo";
        }
        return objeto;
    }

    public char devolverTipoAleatorio()
    {
        bool tipo = Random.Range(0, 2) == 0;
        if (tipo){ return 'N'; }
        else { return 'A'; }
    }
    
    public static void setDensidadAgua(int d)
    {
        densidadAgua = d;
        if (d >= 100)
        {
            densidadAgua = 25;
        }
        if (d < 0)
        {
            densidadAgua = 0;
        }
    }

    public static void setDensidadVegetacion(int d)
    {
        densidadVegetacion = d;
        if (d >= 100)
        {
            densidadVegetacion = 25;
        }
        if (d < 0)
        {
            densidadVegetacion = 0;
        }
    }
    public static void setDensidadObjetos(int d)
    {
        densidadObjetos = d;
        if (d >= 100)
        {
            densidadObjetos = 25;
        }
        if (d < 0)
        {
            densidadObjetos = 0;
        }
    }


    public static void setDensidadArmas(int d)
    {
        densidadArmas = d;
        if (d >= 100)
        {
            densidadArmas = 25;
        }
        if (d < 0)
        {
            densidadArmas = 0;
        }
    } 

    public int getDensidadObjetos()
    {
        return densidadObjetos;
    }

    public int getDensidadAgua()
    {
        return densidadAgua;
    }

    public int getDensidadVegetacion()
    {
        return densidadVegetacion;
    } 

    public int getDensidadArmas()
    {
        return densidadArmas;
    }

    public static char[,] getVectorMapa()
    {
        return vectorMapa;
    }

    public void CentrarCamara(int actX, int actY, Vector3 posActual)
    {
        float posY = 100; //Zoom con respecto al mapa!
        if (dimX<10 && dimY < 10)
        {
           posY = 30; //Si el mapa es más chico, acerco la camara.
        }
        if(dimX/2 == actX && dimY / 2 == actY)
        {
            float posX = posActual.x;
            float posZ = posActual.z;
            camara.transform.position = new Vector3(posX, posY, posZ);
        }
    }
    public byte[] capturar()
    {
        int ancho = 200;
        int alto = 200;
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
        System.IO.File.WriteAllBytes(Application.persistentDataPath+filename, imagen);

        return imagen;
    }

    private void GetValuesOfDataGame()
    {
        densidadAgua = (int)(DataGame.ValueSliderWater * 50);
        densidadVegetacion = (int)(DataGame.ValueSliderForest * 50);
        densidadObjetos = (int)(DataGame.ValueSliderRompibleObject * 50);
        typeOfLand = DataGame.TypeOfLand;
        //   bool naturalDisasters = (int)Math.Round(DataGame.ValueSliderNaturalDisasters);
        // this will be for the rain and snow in the game
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

                //Creo el tipo de suelo: agua o tierra.
                Instantiate(generarSuelo(vectorMapa[i, j]), empty.position, empty.rotation);
                CentrarCamara(i, j, posicionEmpty);
                //Le agrego un árbol aleatorio o un objeto si no hay agua...
                if (vectorMapa[i, j] != 'A')
                {
                    if (vectorMapa[i, j] == 'W')
                    {
                        Vector3 posicionArbol = new Vector3(posIniX + (i * 5) + 2, empty.position.y + (6), posIniZ + (j * 5));
                        //Instantiate(generarVegetacion(vectorMapa[i, j]), posicionArbol, empty.rotation);
                        Instantiate(generarArmamento(vectorMapa[i, j]), posicionArbol, empty.rotation);
                    }


                    if (vectorMapa[i, j] == 'T')
                    {
                        Vector3 posicionArbol = new Vector3(posIniX + (i * 5) + 2, empty.position.y + (5), posIniZ + (j * 5));
                        Instantiate(generarVegetacion(vectorMapa[i, j]), posicionArbol, empty.rotation);
                    }
                    if (vectorMapa[i, j] == 'O')
                    {
                        Vector3 posicionObjeto = new Vector3(posIniX + (i * 5) + 2, empty.position.y + (5.5f), posIniZ + (j * 5));
                        Instantiate(generarObjetosRompibles(vectorMapa[i, j]), posicionObjeto, empty.rotation);
                    }

                    if (vectorMapa[i, j] == 'M')
                    {
                        Vector3 posicionObjeto = new Vector3(posIniX + (i * 5) + 2, empty.position.y + (4.57f), posIniZ + (j * 5));
                        Instantiate(generarMunicion(vectorMapa[i, j]), posicionObjeto, empty.rotation);
                    }
                }
            }
        }
    }

    private GameObject generarArmamento(char v)
    {
        GameObject a = null;

        int tipo = Random.Range(1, 4);
        switch (tipo)
        {
            case 1:
                a = arma1;
                a.name = "pistola";
                break;
            case 2:
                a = arma2;
                a.name = "escopeta";
                break;
            case 3:
                a = arma3;
                a.name = "ametralladora";
                break;
        }
        return a;
    }


    private GameObject generarMunicion(char v)
    {
        GameObject a = null;

        int tipo = Random.Range(1, 4);
        switch (tipo)
        {
            case 1:
                a = municionPistola;
                a.name = "municionPistola";
                break;
            case 2:
                a = municionEscopeta;
                a.name = "municionEscopeta";
                break;
            case 3:
                a = municionAmetralladora;
                a.name = "municionAmetralladora";
                break;
        }
        return a;
    }


    private void setTipoSuelo()
    {
        if (typeOfLand == TypeOfLand.FOREST)
        {
            suelo = sueloBosque;
            return;
        } else if (typeOfLand == TypeOfLand.DESERT)
        {
            suelo = sueloDesierto;
            return;
        } else if (typeOfLand == TypeOfLand.SNOW)
        {
            suelo = sueloNieve;
            return;
        }
        suelo = sueloBosque;
        return;
    }

}
