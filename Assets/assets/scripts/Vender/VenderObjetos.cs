using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenderObjetos : MonoBehaviour
{

    public GameObject HUDVender;


    public void OnTriggerEnter(Collider other)
    {
        HUDVender.SetActive(true);
        Cursor.visible = true;
    }

    public void OnTriggerExit(Collider other)
    {
        HUDVender.SetActive(false);
        Cursor.visible = false;
    }
}
