using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class persistenciaMapas : MonoBehaviour
{
    public static HashSet<Mapa> mapas;
    public static Mapa mapaActual;

    public persistenciaMapas()
    {
        mapas = CargarMapas(); //Al iniciar la persistencia, llamo al crear mapas!
    }

    public static void GuardarMapas(Mapa m)
    {
        print(Application.persistentDataPath + "/Mapas.pps");
        mapas = CargarMapas(); //Me aseguro que el archivo este actualizado!
        imprimirListadeMapas(mapas);

        if (mapas.Contains(m)==false) {
            AddValuesSliderToMap(m);
            mapas.Add(m); //Agrego el nuevo mapa
            //La extensión asignada es pps para los mapas.
            FileStream archivo = new FileStream(Application.persistentDataPath + "/Mapas.pps", FileMode.OpenOrCreate);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(archivo, mapas); //Lo persisto
            print("GUARDO EL MAPA Y CIERRO EL ARCHIVO: " + mapas.Count);
            archivo.Close(); //Cierro el archivo.
            mapas = CargarMapas();
            print("LUEGO DE GUARDAR, LA CANTIDAD DE MAPAS ES DE: " + mapas.Count);
        }
    }

    private static void AddValuesSliderToMap(Mapa m)
    {
        m.ValueSliderForest = DataGame.ValueSliderForest;
        m.ValueSliderNaturalDisasters = DataGame.ValueSliderNaturalDisasters;
        m.ValueSliderRompibleObject = DataGame.ValueSliderRompibleObject;
        m.ValueSliderWater = DataGame.ValueSliderWater;
    }

    private static void imprimirListadeMapas(HashSet<Mapa> mapas)
    {
        print("========IMPRIMIENDO LISTA DE MAPAS GUARDADOS");
        foreach(Mapa m in mapas)
        {
            print("nombre del mapa: "+m.getNombre());
        }
    }

    public static HashSet<Mapa> CargarMapas()
    {
        if (System.IO.File.Exists(Application.persistentDataPath + "/Mapas.pps"))
        {
            //print("Se encontró el archivo!");
            FileStream archivo = new FileStream(Application.persistentDataPath + "/Mapas.pps", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            HashSet<Mapa> aux = b.Deserialize(archivo) as HashSet<Mapa>; //Deserializo como lista de mapas!
            archivo.Close();
            mapas = aux;
            return aux;
        }
        else
        {
            print("No se encontró el archivo, devuelvo la lista vacia...");
            return new HashSet<Mapa>(); //Si el archivo NO existe, entonces devuelvo la lista vacia...
        }
       
    }
    }