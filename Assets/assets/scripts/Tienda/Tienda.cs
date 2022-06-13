using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public GameObject jugador;
    public GameObject HUDComprar;
    public GameObject inventario;
    public GameObject botonComprar;
    public GameObject[] objetosDeLATienda;
    BolsaTienda bolsa;
    private bool puedeComprar = false;
    private bool activarTienda;

    private void Start()
    {
        bolsa = gameObject.GetComponent<BolsaTienda>();
        actualizarTienda();
    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && puedeComprar)
        {
            activarTienda = !activarTienda;
        }

        if (activarTienda)
        {
             HUDComprar.active = true;
            jugador.active = false;
        } else
        {
            HUDComprar.active = false;
            jugador.active = true;
        }
    }

    private void actualizarTienda()
    {
        for (int i=0;i<objetosDeLATienda.Length;i++)
        {
            GameObject ObjetoVender = Instantiate(objetosDeLATienda[i], bolsa.slots[i].transform.position, Quaternion.identity);
            ObjetoVender.transform.SetParent(bolsa.slots[i].transform, false);
            ObjetoVender.transform.localPosition = new Vector3(0, 0, 0);
            ObjetoVender.name = ObjetoVender.name.Replace("(Clone)", "");
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        puedeComprar = true;
        botonComprar.active = true;
        Cursor.visible = true;
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        puedeComprar = false;
        botonComprar.active = false;
        Cursor.visible = false;
    }
}
