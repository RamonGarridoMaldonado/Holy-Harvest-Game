using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dormir : MonoBehaviour
{
    public GameObject HUDDormir,jugador;
    
    float tiempoPuedeDormir = 20;
    bool puedeDormir = true;
    public TextMeshPro textoContador;
    TextMeshPro textoClonado;
    int segundos, minutos, horas, segundosMostrar;
    public GameObject pantallaCarga,obeja1,obeja2,obeja3,HUDInventario;

    void Start()
    {
        Vector3 posTexto = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        textoClonado = Instantiate(textoContador, posTexto, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoPuedeDormir -= Time.deltaTime;
        segundos = Convert.ToInt32(tiempoPuedeDormir);
        horas = (segundos / 3600);
        minutos = ((segundos - horas * 3600) / 60);
        segundosMostrar = segundos - (horas * 3600 + minutos * 60);

        if (Input.GetKeyDown(KeyCode.E) && puedeDormir && tiempoPuedeDormir<=0)
        {
            dormir();
        }

        if (tiempoPuedeDormir <= 0)
        {
            textoClonado.SetText("Puede dormir");
            tiempoPuedeDormir = 0;
        } else
        {
            textoClonado.SetText(minutos.ToString() + " : " + segundosMostrar.ToString());
        }
        textoClonado.transform.LookAt(Camera.main.transform);
        textoClonado.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        HUDDormir.SetActive(true);
        puedeDormir = true;
    }

    private void OnTriggerExit(Collider other)
    {
        HUDDormir.SetActive(false);
        puedeDormir = false;
    }

    private void dormir()
    {
        jugador.GetComponent<BarraDeEstamina>().llenarEstamina();
        tiempoPuedeDormir = 20;
        StartCoroutine("pantallaCargaDormir");
    }

    IEnumerator pantallaCargaDormir()
    {
        HUDInventario.SetActive(false);
        jugador.SetActive(false);
        pantallaCarga.SetActive(true);
        yield return new WaitForSeconds(1f);
        obeja1.SetActive(true);
        yield return new WaitForSeconds(1f);
        obeja2.SetActive(true);
        yield return new WaitForSeconds(1f);
        obeja3.SetActive(true);
        yield return new WaitForSeconds(2f);
        obeja1.SetActive(false);
        obeja2.SetActive(false);
        obeja3.SetActive(false);
        pantallaCarga.SetActive(false);
        jugador.SetActive(true);
        HUDInventario.SetActive(true);
        yield return new WaitForSeconds(1);
    }
}
