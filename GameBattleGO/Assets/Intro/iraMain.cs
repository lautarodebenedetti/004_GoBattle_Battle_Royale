using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iraMain : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}