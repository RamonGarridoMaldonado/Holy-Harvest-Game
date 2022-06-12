using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscucharSonidoMar : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("Se deberia escuchar");
        AudioSource sonidoMar = GameObject.Find("Sonidos/Sonido Mar").GetComponent<AudioSource>();
        sonidoMar.Play();
    }

    public void OnTriggerExit(Collider other)
    {
        AudioSource sonidoMar = GameObject.Find("Sonidos/Sonido Mar").GetComponent<AudioSource>();
        sonidoMar.Stop();
    }
}
