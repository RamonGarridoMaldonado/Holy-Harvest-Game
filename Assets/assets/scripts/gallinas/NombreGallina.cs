using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NombreGallina : MonoBehaviour
{
    public string nombreGallina;
    public TextMeshPro textoNombre;
    TextMeshPro textoClonado;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 posTexto = new Vector3(transform.position.x, transform.position.y+0.8f, transform.position.z);
        textoClonado = Instantiate(textoNombre, posTexto, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        textoClonado.SetText(nombreGallina);
        textoClonado.transform.LookAt(Camera.main.transform);
        textoClonado.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        textoClonado.transform.position = new Vector3(transform.position.x, transform.position.y+0.8f, transform.position.z);
    }

    public void establecerNombreGallina(string nombre)
    {
        nombreGallina = nombre;
    }
}
