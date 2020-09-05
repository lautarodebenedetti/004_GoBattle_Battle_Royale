using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateGameCooperativeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }


    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ButtonAddNewMap()
    {
        SceneManager.LoadScene("CreateMapScene");
    }

    public void ButtonPlay()
    {
        SceneManager.LoadScene("GenerarMapa");
    }
}
