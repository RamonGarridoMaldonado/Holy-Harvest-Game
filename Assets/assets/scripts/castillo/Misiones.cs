using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    public GameObject HUDmision, HUDMisionRechazada, HUDMisionAceptada, HUDMisionTerminada, HUDMisionRecursosInsuficientes, personaje;
    private bool Terminada = false, Rechazada = false, Aceptada = false, recursosInsuficientes = false, dentro = false;
    public GameObject camaraPrincipal, camaraConversacion;
    Animator animator;
    public GameManager manager;
    private bool hablando = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = personaje.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hablando)
        {
            Cursor.visible = true;
        }
        if (Aceptada && !HUDMisionAceptada.activeSelf)
        {
            OcultarTodosHUD();
            HUDMisionAceptada.SetActive(true);
        }
        if (Rechazada && !HUDMisionRechazada.activeSelf)
        {
            OcultarTodosHUD();
            HUDMisionRechazada.SetActive(true);
        }

        if (dentro && Input.GetKeyDown(KeyCode.Space))
        {
            salirConversacion();
        }

        if (Terminada && !HUDMisionTerminada.activeSelf)
        {
            OcultarTodosHUD();
            HUDMisionTerminada.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hablando = true;
        if (other.tag == "HablarJugador")
        {
            Cursor.visible = true;
            personaje.GetComponent<MovimientoJugador>().enabled = false;
            this.transform.LookAt(personaje.transform);
            dentro = true;
            animator.SetFloat("velocidad", 0f, 0f, Time.deltaTime);
            camaraConversacion.SetActive(true);
            camaraPrincipal.SetActive(false);
            if (!Terminada && !Rechazada && !Aceptada && !recursosInsuficientes)
            {
                OcultarTodosHUD();
                Cursor.visible = true;
                HUDmision.SetActive(true);
            }

            if (Aceptada)
            {
                OcultarTodosHUD();
                Cursor.visible = true;
                HUDMisionAceptada.SetActive(true);
            }

            if (Rechazada)
            {
                OcultarTodosHUD();
                Cursor.visible = true;
                HUDMisionRechazada.SetActive(true);
            }
            if (recursosInsuficientes)
            {
                OcultarTodosHUD();
                Cursor.visible = true;
                HUDMisionRecursosInsuficientes.SetActive(true);
            }
            if (Terminada)
            {
                OcultarTodosHUD();
                Cursor.visible = true;
                HUDMisionTerminada.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hablando = false;
        if (other.tag == "HablarJugador")
        {
            if (Aceptada)
            {
                Terminada = true;
            }
            salirConversacion();
        }
    }


    public void AceptarMision()
    {
        bool encontrado = false;
        foreach (var item in manager.GetComponent<Bolsa>().obtenerObjetosBolsa())
        {
            if (item.Key == "Berenjena (USE) 1" && item.Value >= 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    encontrado = true;
                    manager.GetComponent<Bolsa>().usarObjetoInventario("Berenjena (USE) 1");
                }
                Aceptada = true;
                GameManager.setSumarDinero(4500);
            }
        }
        if (!encontrado)
        {
            recursosInsuficientes = true;
        }
    }

    public void RechazarMision()
    {
        Rechazada = true;
    }

    private void salirConversacion()
    {
        Aceptada = false;
        Rechazada = false;
        personaje.GetComponent<MovimientoJugador>().enabled = true;
        dentro = false;
        personaje.SetActive(true);
        camaraConversacion.SetActive(false);
        camaraPrincipal.SetActive(true);
        HUDmision.SetActive(false);
        HUDMisionAceptada.SetActive(false);
        HUDMisionRechazada.SetActive(false);
        HUDMisionRecursosInsuficientes.SetActive(false);
        HUDMisionTerminada.SetActive(false);
    }

    private void OcultarTodosHUD()
    {
        HUDmision.SetActive(false);
        HUDMisionAceptada.SetActive(false);
        HUDMisionRechazada.SetActive(false);
        HUDMisionRecursosInsuficientes.SetActive(false);
        HUDMisionTerminada.SetActive(false);
    }
}
