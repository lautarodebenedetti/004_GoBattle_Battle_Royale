using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Button btnSoundOn;
    public Button btnSoundOff;
    public GameObject mainTextures;

    private void Start()
    {
        StartCoroutine(WaitForBringPanel());
    }
    void Update()
    {
        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Quit the application
                Application.Quit();
            }
        }
    }
    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

   public void GoToCreateGameOnePlayerScene()
    {
        SceneManager.LoadScene("CreateGameOnePlayerScene");
    }

    public void GoToPresentation()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GoToCreateGameCooperativeScene()
    {
        SceneManager.LoadScene("CreateGameCooperativeScene");
    }

    public void GoToCreateGameMultiplayerScene()
    {
        SceneManager.LoadScene("CreateGameMultiplayerScene");
    }

    public IEnumerator WaitForBringPanel()
    {
        Debug.Log("ENTRO ACA A MAIN TEXTUREX");
        yield return new WaitForSeconds(1);
        mainTextures.SetActive(true);
    }

    public void SoundOff()
    {
        DataGame.IsSoundActive = false;
        btnSoundOn.gameObject.SetActive(false);
        AudioListener.pause = true;
        btnSoundOff.gameObject.SetActive(true);
    }
    public void SoundOn()
    {
        DataGame.IsSoundActive = true;
        btnSoundOn.gameObject.SetActive(true);
        AudioListener.pause = false;
        btnSoundOff.gameObject.SetActive(false);
    }
}
