using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaOcupada : MonoBehaviour
{
    public bool ocupado = false;

    public bool estaOcupado()
    {
        return ocupado;
    }

    public void establecerOcupado()
    {
        ocupado = true;
    }

    public void establecerNoOcupado()
    {
        ocupado = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cosecha"))
        {
            ocupado = false;
        }
    }
}
