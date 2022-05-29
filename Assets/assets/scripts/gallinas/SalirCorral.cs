using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirCorral : MonoBehaviour
{
    public GameObject HUDSalirCorral;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("gallina"))
        {
            HUDSalirCorral.active = true;
        }
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("gallina"))
        {
            HUDSalirCorral.active = false ;
        }
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && HUDSalirCorral.active)
        {
            // Salir a pueblo
            SceneManager.LoadScene("Granja");
        }
    }
}
