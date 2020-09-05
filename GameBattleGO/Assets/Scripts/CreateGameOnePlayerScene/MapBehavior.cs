using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPress()
    {
        ClosePanel();
        DataGame.ActualMap = CreateMapa(gameObject.GetComponent<Map>());
    }

    public Mapa CreateMapa(Map map)
    {
        Mapa mapa = new Mapa(map.map, map.imagenMapa, map.nombreMapa, map.typeOfLand);
        mapa.ValueSliderForest = map.ValueSliderForest;
        mapa.ValueSliderNaturalDisasters = map.ValueSliderNaturalDisasters;
        mapa.ValueSliderRompibleObject = map.ValueSliderRompibleObject;
        mapa.ValueSliderWater = map.ValueSliderWater;
        return mapa;
    }

    public void ClosePanel()
    {
        GameObject.Find("PanelMaps").SetActive(false);
    }
}
