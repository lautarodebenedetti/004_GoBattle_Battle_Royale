using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generadorVectorMapa : MonoBehaviour
{
    public static int dimX;
    public static int dimY;
    public static char[,] mapa;

    public static char[,] construirVectorMapa(int X, int Y, int densidadArboles, int densidadAgua, int densidadObjetos, int densidadArmas, int densidadMunicion)
    {
        dimX = X;
        dimY = Y;
        return construirVectorDensidades(dimX, dimY, densidadArboles, densidadAgua, densidadObjetos, densidadArmas, densidadMunicion);
    }
    private static char[,] construirVectorDensidades(int dimX, int dimY, int densidadArboles, int densidadAgua, int densidadObjetos, int densidadArmas, int densidadMunicion)
    {
        mapa = new char[dimX,dimY];
        int cantidadArboles = calcularDensidad(densidadArboles);
        int cantidadAgua = calcularDensidad(densidadAgua);
        int cantidadObjetos = calcularDensidad(densidadObjetos);
        int cantidadArmas = calcularDensidad(densidadArmas);
        int cantidadMunicion = calcularDensidad(densidadMunicion);
        int cantidadNada = (dimX * dimY) - cantidadArboles - cantidadAgua - cantidadObjetos;

        agregarAgua(mapa, cantidadAgua);
        agregarArboles(mapa, cantidadArboles);
        agregarObjetos(mapa, cantidadObjetos);
        agregarArmas(mapa, cantidadArmas);
        agregarMunicion(mapa, cantidadMunicion);
        return mapa;
    }

    private static void agregarArboles(char[,] mapa, int cantidadArboles)
    {
        int arbolesActual = 0;
        while (arbolesActual < cantidadArboles)
        {
            int ejeX = Random.Range(0, dimX);
            int ejeY = Random.Range(0, dimY);
            if (mapa[ejeX, ejeY] != 'A' && mapa[ejeX, ejeY] != 'O')
            {
                mapa[ejeX, ejeY] = 'T';
                arbolesActual++;
            }
        }
    }

    private static void agregarAgua(char[,] mapa, int cantidadAgua)
    {
        int aguaActual = 0;
        while (aguaActual < cantidadAgua)
        {
            int ejeX = Random.Range(0, dimX);
            int ejeY = Random.Range(0, dimY);
            if (mapa[ejeX, ejeY] != 'A')
            {
                mapa[ejeX, ejeY] = 'A';
                aguaActual++;
            }
        }
    }
    private static void agregarObjetos(char[,] mapa, int cantidadObjetos)
    {
        int objetosActual = 0;
        while (objetosActual < cantidadObjetos)
        {
            int ejeX = Random.Range(0, dimX);
            int ejeY = Random.Range(0, dimY);
            if (mapa[ejeX, ejeY] != 'A' && mapa[ejeX, ejeY] != 'T')
            {
                mapa[ejeX, ejeY] = 'O';
                objetosActual++;
            }
        }
    }

    private static void agregarArmas(char[,] mapa, int cantidadArmas)
    {
        int armasActual = 0;
        while (armasActual < cantidadArmas)
        {
            int ejeX = Random.Range(0, dimX);
            int ejeY = Random.Range(0, dimY);
            if (mapa[ejeX, ejeY] != 'A' && mapa[ejeX, ejeY] != 'T' && mapa[ejeX, ejeY]!='O')
            {
                mapa[ejeX, ejeY] = 'W';
                armasActual++;
            }
        }
    }


    private static void agregarMunicion(char[,] mapa, int cantidadMunicion)
    {
        int municionActual = 0;
        while (municionActual < cantidadMunicion)
        {
            int ejeX = Random.Range(0, dimX);
            int ejeY = Random.Range(0, dimY);
            if (mapa[ejeX, ejeY] != 'A' && mapa[ejeX, ejeY] != 'T' && mapa[ejeX, ejeY] != 'O' && mapa[ejeX,ejeY] != 'W')
            {
                mapa[ejeX, ejeY] = 'M';
                municionActual++;
            }
        }
    }

    private static int calcularDensidad(int d)
    {
        int total = dimX * dimY;
        int cant = (total * d) / 100;
        return cant;
    }

    public static char[,] getVectormapa()
    {
        return mapa;
    }
}