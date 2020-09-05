using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panelGameMain;
    public GameObject panelGameOver;
    public GameObject particleController;
    public Button btnSound;
    private int percentOfNaturalDisasters;
    private bool activeOnlyOneCoroutineForNarutalDisaster = true;

    void Start()
    {
        GeneratePlayer();
        percentOfNaturalDisasters = (int)Math.Round(DataGame.ValueSliderNaturalDisasters * 100);
        if (!DataGame.IsSoundActive)
        {
            AudioListener.pause = true;
        }
        ChangeSound(btnSound);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                panelGameMain.SetActive(true);
            }
        }
        if (!DataGame.IdPlayers.Contains(01) || DataGame.IdPlayers.Count == 1)
        {
            StartCoroutine(GameOver());
        }
        if (percentOfNaturalDisasters != 0 && activeOnlyOneCoroutineForNarutalDisaster)
        {
            activeOnlyOneCoroutineForNarutalDisaster = false;
            StartCoroutine(ActiveNaturalDisasters());
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
    public void Exit()
    {
        SceneManager.LoadScene("MainScene");
    }
    IEnumerator GameOver()
    {
        panelGameOver.SetActive(true);
        yield return new WaitForSeconds(5);
        Exit();
    }

    private void GeneratePlayer()
    {
        ActiveCameraPlayer();
    }

    private void ActiveCameraPlayer()
    {
        if (DataGame.IsViewInthirdPerson)
        {
            GameObject.Find("FirstPersonCamera").GetComponent<Camera>().gameObject.SetActive(false);
           // GameObject.Find("SightFirstPerson").GetComponent<Text>().gameObject.SetActive(false);
            GameObject.Find("ThirdPersonCamera").GetComponent<Camera>().gameObject.SetActive(true);
           // GameObject.Find("SightThirdPerson").GetComponent<Text>().gameObject.SetActive(true);
        } else
        {
            GameObject.Find("FirstPersonCamera").GetComponent<Camera>().gameObject.SetActive(true);
           // GameObject.Find("SightFirstPerson").GetComponent<Text>().gameObject.SetActive(true);
            GameObject.Find("ThirdPersonCamera").GetComponent<Camera>().gameObject.SetActive(false);
           // GameObject.Find("SightThirdPerson").GetComponent<Text>().gameObject.SetActive(false);
        }
    }

    private IEnumerator ActiveNaturalDisasters()
    {
        yield return new WaitForSeconds((100 - percentOfNaturalDisasters));
        if (DataGame.TypeOfLand == TypeOfLand.SNOW)
        {
            particleController.GetComponent<controladorParticulas>().ActivateParticleSnow();
            yield return new WaitForSeconds(percentOfNaturalDisasters);
            particleController.GetComponent<controladorParticulas>().desactivarParticulas(particleController.GetComponent<controladorParticulas>().particulasNieve);
        } else
        {
            particleController.GetComponent<controladorParticulas>().ActivateParticleRain();
            yield return new WaitForSeconds(percentOfNaturalDisasters);
            particleController.GetComponent<controladorParticulas>().desactivarParticulas(particleController.GetComponent<controladorParticulas>().particulasLluvia);
        }
        StartCoroutine(ActiveNaturalDisasters());
    }

    public void ChangeSound(Button btnSound)
    {
        if (DataGame.IsSoundActive)
        {
            DataGame.IsSoundActive = false;
            AudioListener.pause = false;
            btnSound.GetComponentInChildren<Text>().text = "Sonido: Activado";
        }
        else
        {
            DataGame.IsSoundActive = true;
            AudioListener.pause = true;
            btnSound.GetComponentInChildren<Text>().text = "Sonido: Desactivado";
        }
    }
}
