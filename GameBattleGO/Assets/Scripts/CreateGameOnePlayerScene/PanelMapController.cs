using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMapController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelPreviewMap;
    private TypeOfLand typeOfLand;
    private float valueSliderForest, valueSliderWater, valueSliderRompibleObject;
    private GameObject waterPrefab;
    private GameObject forestFloorPrefab;
    private GameObject forestTreePrefab;
    private GameObject forestWeaponPrefab;
    private GameObject forestAmmunationPrefab;
    private GameObject forestRompibleObjectPrefab;
    private GameObject desertFloorPrefab;
    private GameObject desertTreePrefab;
    private GameObject desertWeaponPrefab;
    private GameObject desertAmmunationPrefab;
    private GameObject desertRompibleObjectPrefab;
    private GameObject snowFloorPrefab;
    private GameObject snowTreePrefab;
    private GameObject snowWeaponPrefab;
    private GameObject snowAmmunationPrefab;
    private GameObject snowRompibleObjectPrefab;

    void Start()
    {
        waterPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/Water");
        forestFloorPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/ForestFloor");
        forestTreePrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/ForestTree");
        forestWeaponPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/ForestWeapon");
        forestAmmunationPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/ForestAmmunation");
        forestRompibleObjectPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/ForestRompibleObject");
        desertFloorPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/DesertFloor");
        desertTreePrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/DesertTree");
        desertWeaponPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/DesertWeapon");
        desertAmmunationPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/DesertAmmunation");
        desertRompibleObjectPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/DesertRompibleObject");
        snowFloorPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/SnowFloor");
        snowTreePrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/SnowTree");
        snowWeaponPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/SnowWeapon");
        snowAmmunationPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/SnowAmmunation");
        snowRompibleObjectPrefab = (GameObject)Resources.Load("Prefabs/PreviewMap/SnowRompibleObject");
        SaveUiValues();
        DrawMap(GenerateMatrix());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsANewChangeInTheValuesOfPanelMap())
        {
            CleanMap();
            DrawMap(GenerateMatrix());
        }
    }

    private void CleanMap()
    {
        foreach (Transform child in panelPreviewMap.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private bool IsANewChangeInTheValuesOfPanelMap()
    {
        if (GameObject.Find("SliderForest").GetComponent<Slider>().value != valueSliderForest ||
            GameObject.Find("SliderWater").GetComponent<Slider>().value != valueSliderWater ||
            GameObject.Find("SliderRompibleObject").GetComponent<Slider>().value != valueSliderRompibleObject ||
            !typeOfLand.Equals(GetTypeOfLand(GameObject.Find("DropdownTypeOfLand").GetComponent<Dropdown>().captionText)))
        {
            SaveUiValues();
            return true;
        }
        return false;
    }
    private void SaveUiValues()
    {
        valueSliderForest = GameObject.Find("SliderForest").GetComponent<Slider>().value;
        valueSliderWater = GameObject.Find("SliderWater").GetComponent<Slider>().value;
        valueSliderRompibleObject = GameObject.Find("SliderRompibleObject").GetComponent<Slider>().value;
        typeOfLand = GetTypeOfLand(GameObject.Find("DropdownTypeOfLand").GetComponent<Dropdown>().captionText);
    }
    private void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] != 'A')
                {
                    if (map[i, j] == 'W')
                    {
                        GameObject weapons = Instantiate(GetPrefabWeaponFromTypeOfLand());
                        weapons.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                        weapons.transform.SetParent(panelPreviewMap.transform);
                    }
                    else if (map[i, j] == 'T')
                    {
                        GameObject forest = Instantiate(GetPrefabTreeFromTypeOfLand());
                        forest.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                        forest.transform.SetParent(panelPreviewMap.transform);
                    }
                    else if (map[i, j] == 'O')
                    {
                        GameObject rompibleObject = Instantiate(GetPrefabRompibleObjectFromTypeOfLand());
                        rompibleObject.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                        rompibleObject.transform.SetParent(panelPreviewMap.transform);
                    }
                    else if (map[i, j] == 'M')
                    {
                        GameObject ammunition = Instantiate(GetPrefabAmmunationFromTypeOfLand());
                        ammunition.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                        ammunition.transform.SetParent(panelPreviewMap.transform);
                    }
                    else
                    {
                        GameObject floor = Instantiate(GetPrefabFloorFromTypeOfLand());
                        floor.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                        floor.transform.SetParent(panelPreviewMap.transform);
                    }
                } else
                {
                    GameObject water = Instantiate(waterPrefab);
                    water.gameObject.transform.localScale = new Vector3(1.76275f, 2.136667f, 2.136667f);
                    water.transform.SetParent(panelPreviewMap.transform);
                }
            }
        }
    }
    
    private GameObject GetPrefabRompibleObjectFromTypeOfLand()
    {
        if (typeOfLand.Equals(TypeOfLand.DESERT))
        {
            return desertRompibleObjectPrefab;
        }
        else if (typeOfLand.Equals(TypeOfLand.SNOW))
        {
            return snowRompibleObjectPrefab;
        }
        else
        {
            return forestRompibleObjectPrefab;
        }
    }
    private GameObject GetPrefabAmmunationFromTypeOfLand()
    {
        if (typeOfLand.Equals(TypeOfLand.DESERT))
        {
            return desertAmmunationPrefab;
        }
        else if (typeOfLand.Equals(TypeOfLand.SNOW))
        {
            return snowAmmunationPrefab;
        }
        else
        {
            return forestAmmunationPrefab;
        }
    }
    private GameObject GetPrefabTreeFromTypeOfLand()
    {
        if (typeOfLand.Equals(TypeOfLand.DESERT))
        {
            return desertTreePrefab;
        }
        else if (typeOfLand.Equals(TypeOfLand.SNOW))
        {
            return snowTreePrefab;
        }
        else
        {
            return forestTreePrefab;
        }
    }
    private GameObject GetPrefabFloorFromTypeOfLand()
    {
        if (typeOfLand.Equals(TypeOfLand.DESERT))
        {
            return desertFloorPrefab;
        }
        else if (typeOfLand.Equals(TypeOfLand.SNOW))
        {
            return snowFloorPrefab;
        }
        else
        {
            return forestFloorPrefab;
        }
    }
    private GameObject GetPrefabWeaponFromTypeOfLand()
    {
        if (typeOfLand.Equals(TypeOfLand.DESERT))
        {
            return desertWeaponPrefab;
        } else if (typeOfLand.Equals(TypeOfLand.SNOW))
        {
            return snowWeaponPrefab;
        } else
        {
            return forestWeaponPrefab;
        }
    }

    private char[,] GenerateMatrix()
    {
        int densityForest = (int)(valueSliderForest * 20);
        int densityWater = (int)(valueSliderWater * 20);
        int densityRompibleObject = (int)(valueSliderRompibleObject * 20);
        int densityWeapon = Constants.densityWeapon;
        int densityAmmunition = Constants.densityAmmunition;
        return generadorVectorMapa.construirVectorMapa(Constants.mapPreviewDimensionX, Constants.mapPreviewDimensionY, densityForest, densityWater, densityRompibleObject, densityWeapon, densityAmmunition);
    }

    private TypeOfLand GetTypeOfLand(Text nameOfLand)
    {
        if (nameOfLand.text.ToUpper().Equals("BOSQUE"))
        {
            return TypeOfLand.FOREST;
        }
        else if (nameOfLand.text.ToUpper().Equals("DESIERTO"))
        {
            return TypeOfLand.DESERT;
        }
        else if (nameOfLand.text.ToUpper().Equals("NIEVE"))
        {
            return TypeOfLand.SNOW;
        }
        return TypeOfLand.FOREST;
    }
}
