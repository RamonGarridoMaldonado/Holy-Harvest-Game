using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcariciarGallina : MonoBehaviour
{

    public GameObject jugador, HUDacariciar;
    Animator animator;
    private bool puedeAcariciar = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = jugador.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && puedeAcariciar)
        {
            StartCoroutine("acariciar");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            puedeAcariciar = true;
            HUDacariciar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            puedeAcariciar = false;
            HUDacariciar.SetActive(false);
        }
    }

    IEnumerator acariciar()
    {
        animator.SetBool("acariciando", true);
        jugador.transform.LookAt(this.transform);
        this.GetComponent<movimientoGallina>().enabled = false;
        yield return new WaitForSeconds(8);
        this.GetComponent<generarHuevos>().setAcariciada();
        this.GetComponent<movimientoGallina>().enabled = true;
        animator.SetBool("acariciando", false);
        animator.SetFloat("velocidad", 0.5f, 0.1f, Time.deltaTime);
    }
}
