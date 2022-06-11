using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarHuevos : MonoBehaviour
{

    public GameObject huevo;
    bool puedeGenerar = true;
    bool acariciada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeGenerar) StartCoroutine("GenerarHuevo");
    }

    IEnumerator GenerarHuevo()
    {
        int tiempoAleatorio = 0;
        if (!acariciada)
        {
            tiempoAleatorio = UnityEngine.Random.Range(40, 60);
        }else
        {
            tiempoAleatorio = UnityEngine.Random.Range(30, 50);

        }
        Vector3 posHuevo = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
        puedeGenerar = false;
        yield return new WaitForSeconds(tiempoAleatorio);
        Instantiate(huevo, posHuevo, Quaternion.identity);
        puedeGenerar = true;
    }

    public void setAcariciada()
    {
        acariciada = true;
    }
}
