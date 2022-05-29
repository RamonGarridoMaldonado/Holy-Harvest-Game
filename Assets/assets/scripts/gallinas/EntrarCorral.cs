using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarCorral : MonoBehaviour
{
    public GameObject HUDEntrarGranja;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        HUDEntrarGranja.active = true;
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        HUDEntrarGranja.active = false;
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && HUDEntrarGranja.active)
        {
            // Entrar en el corral
            SceneManager.LoadScene("corral");
        }
    }
}
