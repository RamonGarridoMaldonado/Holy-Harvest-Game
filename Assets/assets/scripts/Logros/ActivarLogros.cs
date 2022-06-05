using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarLogros : MonoBehaviour
{
    public GameObject HUDLogros, logro1, logro2, logro3;

    public void OnTriggerEnter(Collider other)
    {
        HUDLogros.SetActive(true);
        if (GameManager.isLogro1Conseguido())
        {
            logro1.SetActive(true);
        }

        if (GameManager.isLogro2Conseguido())
        {
            logro2.SetActive(true);
        }

        if (GameManager.isLogro3Conseguido())
        {
            logro3.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        HUDLogros.SetActive(false);
        if (GameManager.isLogro1Conseguido())
        {
            logro1.SetActive(false);
        }

        if (GameManager.isLogro2Conseguido())
        {
            logro2.SetActive(false);
        }

        if (GameManager.isLogro3Conseguido())
        {
            logro3.SetActive(false);
        }
    }
}
