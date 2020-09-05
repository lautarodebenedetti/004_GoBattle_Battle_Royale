using System.Collections.Generic;
using UnityEngine;

public static class DataGame
{
    private static float valueSliderForest, valueSliderWater, valueSliderRompibleObject, valueSliderNaturalDisasters;
    private static bool isViewInthirdPerson = true;
    private static bool isSoundActive = true;
    private static string language = "es";
    private static List<int> idPlayers = new List<int>();
    private static Mapa actualMap = null;
    private static TypeOfLand typeOfLand;
    private static int cantBots;

    public static float ValueSliderForest
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
    public static float ValueSliderWater
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
    public static float ValueSliderRompibleObject
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
    public static float ValueSliderNaturalDisasters
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
    public static bool IsViewInthirdPerson
    {
        get
        {
            return isViewInthirdPerson;
        }
        set
        {
            isViewInthirdPerson = value;
        }
    }
    public static bool IsSoundActive
    {
        get
        {
            return isSoundActive;
        }
        set
        {
            isSoundActive = value;
        }
    }
    public static string Language
    {
        get
        {
            return language;
        }
        set
        {
            language = value;
        }
    }
    public static List<int> IdPlayers
    {
        get
        {
            return idPlayers;
        }
        set
        {
            idPlayers = value;
        }
    }
    public static Mapa ActualMap
    {
        get
        {
            return actualMap;
        }
        set
        {
            actualMap = value;
        }
    }
    public static TypeOfLand TypeOfLand
    {
        get
        {
            return typeOfLand;
        }
        set
        {
            typeOfLand = value;
        }
    }
    public static int CantBots
    {
        get
        {
            return cantBots;
        }
        set
        {
            cantBots = value;
        }
    }
}
