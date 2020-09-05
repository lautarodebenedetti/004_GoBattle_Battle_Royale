using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGameOnePlayerController : MonoBehaviour
{
    private new Mapa mapa = null;

    void Start()
    {
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        if (DataGame.ActualMap != null && !DataGame.ActualMap.Equals(mapa))
        {
            LoadMapValues();
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }


    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void NewMap()
    {
        DataGame.ActualMap = null;
        GameObject.Find("PanelMaps").SetActive(false);
        GameObject.Find("DropdownTypeOfLand").GetComponent<Dropdown>().value = GetTypeOfLand(TypeOfLand.FOREST);
        GameObject.Find("PreviewMap").GetComponent<RawImage>().texture = LoadPreviewMap(TypeOfLand.FOREST);
    }

    public void ButtonPlay()
    {
        SaveMapValues();
        SavePlayerValues();
        SceneManager.LoadScene("GenerarMapa");
        //SceneManager.LoadScene("GameScene");
    }

    public void OpenFullPanel(GameObject panelOpen, GameObject panelClose)
    {
        panelOpen.SetActive(true);
        panelClose.SetActive(false);
    }


    public void CloseFullPanel(GameObject panelOpen, GameObject panelClose)
    {
        panelOpen.SetActive(false);
        panelClose.SetActive(true);
    }

    private void SaveMapValues()
    {
        DataGame.ValueSliderForest = GameObject.Find("SliderForest").GetComponent<Slider>().value;
        DataGame.ValueSliderWater = GameObject.Find("SliderWater").GetComponent<Slider>().value;
        DataGame.ValueSliderRompibleObject = GameObject.Find("SliderRompibleObject").GetComponent<Slider>().value;
        DataGame.ValueSliderNaturalDisasters = GameObject.Find("SliderNaturalDisasters").GetComponent<Slider>().value;
        DataGame.TypeOfLand = GetTypeOfLand(GameObject.Find("DropdownTypeOfLand").GetComponent<Dropdown>().captionText);
    }

    private void SavePlayerValues()
    {
        DataGame.IsViewInthirdPerson = GameObject.Find("SliderViewCamera").GetComponent<Slider>().value == 1;
        DataGame.CantBots = (int)Math.Round(GameObject.Find("SliderViewCantBots").GetComponent<Slider>().value);

    }

    private void LoadMapValues()
    {
        mapa = DataGame.ActualMap;
        GameObject.Find("DropdownTypeOfLand").GetComponent<Dropdown>().value = GetTypeOfLand(mapa.typeOfLand);
        GameObject.Find("PreviewMap").GetComponent<RawImage>().texture = LoadPreviewMap(mapa.typeOfLand);
        GameObject.Find("SliderForest").GetComponent<Slider>().value = mapa.ValueSliderForest;
        GameObject.Find("SliderWater").GetComponent<Slider>().value = mapa.ValueSliderWater;
        GameObject.Find("SliderRompibleObject").GetComponent<Slider>().value = mapa.ValueSliderRompibleObject;
        GameObject.Find("SliderNaturalDisasters").GetComponent<Slider>().value = mapa.ValueSliderNaturalDisasters;
    }

    private Texture LoadPreviewMap(TypeOfLand typeOfLand)
    {
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

    private TypeOfLand GetTypeOfLand(Text nameOfLand)
    {
        if (nameOfLand.text.ToUpper().Equals("BOSQUE"))
        {
            return TypeOfLand.FOREST;
        } else if (nameOfLand.text.ToUpper().Equals("DESIERTO"))
        {
            return TypeOfLand.DESERT;
        }
        else if (nameOfLand.text.ToUpper().Equals("NIEVE"))
        {
            return TypeOfLand.SNOW;
        }
        return TypeOfLand.FOREST;
    }

    private int GetTypeOfLand(TypeOfLand typeOfLand)
    {
        if (typeOfLand == TypeOfLand.FOREST)
        {
            return 0;
        }
        else if (typeOfLand == TypeOfLand.DESERT)
        {
            return 1;
        }
        else if (typeOfLand == TypeOfLand.SNOW)
        {
            return 2;
        }
        return 0;
    }
}
