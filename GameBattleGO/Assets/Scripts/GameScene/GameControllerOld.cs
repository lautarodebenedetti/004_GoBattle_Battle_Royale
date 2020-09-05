using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerOld : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeFPSWithThirdPerson()
    {
        if (firstPersonCamera.activeInHierarchy) { 
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        } else
        {
            firstPersonCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
        }
    }
}
