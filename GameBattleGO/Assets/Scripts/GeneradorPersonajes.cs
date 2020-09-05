using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPersonajes : MonoBehaviour
{
    public GameObject empty;
    public char[,] vectorMapa;
    public int cantBots = 5;
    public int botsAgregados;
    public GameObject bot;

    void Start()
    {
        cantBots = DataGame.CantBots;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void agregarBots(int cantidadBots, char[,]vectorMapa)
    {
        empty = GameObject.Find("generadorBots");
        bot = GameObject.Find("bot");
        int cantBots = cantidadBots;
        Vector3 posicionEmpty = new Vector3(empty.transform.position.x, empty.transform.position.y, empty.transform.position.z); //Tomo posición empty inicial
        float posIniX = empty.transform.position.x;
        float posIniZ = empty.transform.position.z;
        botsAgregados = 0;
        List<(int, int)> posiciones = generarPosicionesRandom(cantBots, vectorMapa.GetLength(0));
        for (int i = 0; i < vectorMapa.GetLength(0); i++)
        {
            for (int j = 0; j < vectorMapa.GetLength(1); j++)
            {
                posicionEmpty = new Vector3(posIniX + (i * 5), empty.transform.position.y, posIniZ + (j * 5));
                empty.transform.position = posicionEmpty;

                if (vectorMapa[i, j] != 'T' && vectorMapa[i, j] != 'A')
                {
                    if (botsAgregados< cantBots && agregarBots(posiciones, i, j))
                    {
                        GameObject botito = Instantiate(bot, empty.transform.position, empty.transform.rotation);
                        botito.name = "bot" + botsAgregados; 
                        botsAgregados++;
                    }
                    instanciarBots(i, j);

                }
            }
        }

    }

    private bool agregarBots(List<(int, int)> posiciones, int posX, int posY)
    {
        var agregar = (posX, posY);
        return posiciones.Contains(agregar);
    }

    private List<(int, int)> generarPosicionesRandom(int bots, int dim)
    {
        List<(int, int)> lista = new List<(int, int)>();
        for (int i = 0; i <= bots; i++)
        {
            int x = Random.Range(0, dim);
            int y = Random.Range(0, dim);
            var random = (x, y);
            lista.Add(random);            
        }
        return lista;
    }

    private void instanciarBots(int x, int y)
    {
        if (cantBots < botsAgregados) { 
        Instantiate(bot, empty.transform.position, empty.transform.rotation);
        botsAgregados++;
    }
    }

}