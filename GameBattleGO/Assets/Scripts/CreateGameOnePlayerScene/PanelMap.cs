using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMap : MonoBehaviour
{
    private readonly persistenciaMapas persistenciaMapas;
    private HashSet<Mapa> mapas;
    public GameObject panelMaps;
    public GameObject mapPrefab;
    void Start()
    {
        mapas = persistenciaMapas.CargarMapas();
        CreateMapsObjects();
    }

    void Update()
    {
        
    }
    private void CreateMapsObjects()
    {
        foreach(Mapa map in mapas)
        {
            addMapToPanelMaps(CreateMapObject(map));
        }
    }

    private void addMapToPanelMaps(GameObject map)
    {
        map.transform.SetParent(panelMaps.transform);
    }

    private GameObject CreateMapObject(Mapa map)
    {
        GameObject newMap = Instantiate(mapPrefab);
        newMap.GetComponent<Map>().nombreMapa = map.nombreMapa;
        newMap.GetComponent<Map>().map = map.map;
        newMap.GetComponent<Map>().typeOfLand = map.typeOfLand;
        newMap.GetComponent<Map>().imagenMapa = map.imagenMapa;
        newMap.GetComponent<Map>().ValueSliderForest = map.ValueSliderForest;
        newMap.GetComponent<Map>().ValueSliderNaturalDisasters = map.ValueSliderNaturalDisasters;
        newMap.GetComponent<Map>().ValueSliderRompibleObject = map.ValueSliderRompibleObject;
        newMap.GetComponent<Map>().ValueSliderWater = map.ValueSliderWater;
        //    newMap.gameObject.transform.localScale = new Vector3(0.87f, 0.87f, 0.87f);
        newMap.gameObject.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
        newMap.GetComponent<RawImage>().texture = LoadPreviewMap(map.typeOfLand);
        return newMap;
    }

    private Texture LoadPreviewMap(TypeOfLand typeOfLand)
    {
        Debug.Log(typeOfLand);
        if (typeOfLand == TypeOfLand.FOREST)
        {
            return (Texture)Resources.Load("Images/CreateGameOnePlayerController/PreviewMapForest");
        }
        else if (typeOfLand == TypeOfLand.DESERT)
        {
            return (Texture)Resources.Load("Images/CreateGameOnePlayerController/PreviewMapDesert");
        }
        else if (typeOfLand == TypeOfLand.SNOW)
        {
            return (Texture)Resources.Load("Images/CreateGameOnePlayerController/PreviewMapSnow");
        }
        return (Texture)Resources.Load("Images/CreateGameOnePlayerController/PreviewMapForest");
    }
}
