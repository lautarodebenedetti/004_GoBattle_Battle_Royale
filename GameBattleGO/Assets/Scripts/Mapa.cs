using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Mapa : System.Object
{
    public char[,] map;
    public byte[] imagenMapa;
    public string nombreMapa;
    public TypeOfLand typeOfLand;
    private float valueSliderForest, valueSliderWater, valueSliderRompibleObject, valueSliderNaturalDisasters;

    public Mapa(char[,] matriz, byte[] imagen, string nombre, TypeOfLand typeOfLand)
    {
        map = matriz;
        imagenMapa = imagen;
        nombreMapa = nombre;
        this.typeOfLand = typeOfLand; // D --> Desierto, B --> Bosque, N --> Nieve!
    }

    public char[,] getMapa()
    {
        return map;
    }

    public void setMapa(char[,] m)
    {
        map = m;
    }

    public string getNombre()
    {
        return nombreMapa;
    }

    public void setNombreMapa(string n)
    {
        nombreMapa = n;
    }

    public byte[] getImage()
    {
        return imagenMapa;
    }

    public void setImage(byte[] i)
    {
        imagenMapa = i;
    }
    public float ValueSliderForest
    {
        get
        {
            return valueSliderForest;
        }
        set
        {
            valueSliderForest = value;
        }
    }
    public float ValueSliderWater
    {
        get
        {
            return valueSliderWater;
        }
        set
        {
            valueSliderWater = value;
        }
    }
    public float ValueSliderRompibleObject
    {
        get
        {
            return valueSliderRompibleObject;
        }
        set
        {
            valueSliderRompibleObject = value;
        }
    }
    public float ValueSliderNaturalDisasters
    {
        get
        {
            return valueSliderNaturalDisasters;
        }
        set
        {
            valueSliderNaturalDisasters = value;
        }
    }

    public override bool Equals(object obj)
    {
        return obj is Mapa mapa &&
               EqualityComparer<char[,]>.Default.Equals(this.map, mapa.map) &&
               EqualityComparer<byte[]>.Default.Equals(imagenMapa, mapa.imagenMapa) &&
               nombreMapa == mapa.nombreMapa &&
               typeOfLand == mapa.typeOfLand;
    }

    public override int GetHashCode()
    {
        var hashCode = 1785314512;
        hashCode = hashCode * -1521134295 + EqualityComparer<char[,]>.Default.GetHashCode(map);
        hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(imagenMapa);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombreMapa);
        hashCode = hashCode * -1521134295 + typeOfLand.GetHashCode();
        return hashCode;
    }
}