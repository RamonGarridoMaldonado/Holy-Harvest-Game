using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuertas : MonoBehaviour
{
    public GameObject puertaDelantera, puertaTrasera;
    AudioSource sonidoCompra;
    bool abierto = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("AbrirPuertas");
    }

    IEnumerator AbrirPuertas()
    {
        if (!abierto)
        {
            sonidoCompra = GameObject.Find("Sonidos/Sonido puertas abriendose").GetComponent<AudioSource>();
            sonidoCompra.Play();
            puertaDelantera.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            puertaTrasera.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(1.7f);
            sonidoCompra.Stop();
            abierto = true;
        }
    }
}
