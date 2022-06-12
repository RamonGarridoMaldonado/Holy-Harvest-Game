using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosVenta : MonoBehaviour
{
   public void venderTomate()
    {
        GameObject manager = GameObject.Find("Manager");
        Text textoInformacion = GameObject.Find("HUD/HUDVenta/TextoInformacion").GetComponent<Text>();
        Text textoDinero = GameObject.Find("HUD/HUDInventario/TextoDinero").GetComponent<Text>();
        bool encontrado = false;
        foreach (var item in manager.GetComponent<Bolsa>().obtenerObjetosBolsa())
        {
            if (item.Key == "Tomate (USE)" && item.Value >= 1)
            {
                AudioSource sonidoCompra = GameObject.Find("Sonidos/Sonido Vender").GetComponent<AudioSource>();
                sonidoCompra.Play();
                manager.GetComponent<Bolsa>().usarObjetoInventario("Tomate (USE)");
                GameManager.setSumarDinero(200);
                textoInformacion.text = "Tomate vendido +200€";
                textoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
        if (!encontrado)
        {
            textoInformacion.text = "No tienes tomate para vender";
        }
    }

    public void venderMaiz()
    {
        GameObject manager = GameObject.Find("Manager");
        Text textoInformacion = GameObject.Find("HUD/HUDVenta/TextoInformacion").GetComponent<Text>();
        Text textoDinero = GameObject.Find("HUD/HUDInventario/TextoDinero").GetComponent<Text>();
        bool encontrado = false;
        foreach (var item in manager.GetComponent<Bolsa>().obtenerObjetosBolsa())
        {
            if (item.Key == "Maiz (USE)" && item.Value >= 1)
            {
                AudioSource sonidoCompra = GameObject.Find("Sonidos/Sonido Vender").GetComponent<AudioSource>();
                sonidoCompra.Play();
                manager.GetComponent<Bolsa>().usarObjetoInventario("Maiz (USE)");
                GameManager.setSumarDinero(500);
                textoInformacion.text = "Maiz vendido +500€";
                textoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
        if (!encontrado)
        {
            textoInformacion.text = "No tienes maiz para vender";
        }
    }

    public void venderBerenjena()
    {
        GameObject manager = GameObject.Find("Manager");
        Text textoInformacion = GameObject.Find("HUD/HUDVenta/TextoInformacion").GetComponent<Text>();
        Text textoDinero = GameObject.Find("HUD/HUDInventario/TextoDinero").GetComponent<Text>();
        bool encontrado = false;
        foreach (var item in manager.GetComponent<Bolsa>().obtenerObjetosBolsa())
        {
            if (item.Key == "Berenjena (USE) 1" && item.Value >= 1)
            {
                AudioSource sonidoCompra = GameObject.Find("Sonidos/Sonido Vender").GetComponent<AudioSource>();
                sonidoCompra.Play();
                manager.GetComponent<Bolsa>().usarObjetoInventario("Berenjena (USE) 1");
                GameManager.setSumarDinero(350);
                textoInformacion.text = "Berenjena vendido +350€";
                textoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
        if (!encontrado)
        {
            textoInformacion.text = "No tienes berenjena para vender";
        }
    }

    public void venderHuevo()
    {
        GameObject manager = GameObject.Find("Manager");
        Text textoInformacion = GameObject.Find("HUD/HUDVenta/TextoInformacion").GetComponent<Text>();
        Text textoDinero = GameObject.Find("HUD/HUDInventario/TextoDinero").GetComponent<Text>();
        bool encontrado = false;
        foreach (var item in manager.GetComponent<Bolsa>().obtenerObjetosBolsa())
        {
            if (item.Key == "Huevo (USE) 2" && item.Value >= 1)
            {
                AudioSource sonidoCompra = GameObject.Find("Sonidos/Sonido Vender").GetComponent<AudioSource>();
                sonidoCompra.Play();
                manager.GetComponent<Bolsa>().usarObjetoInventario("Huevo (USE) 2");
                GameManager.setSumarDinero(150);
                textoInformacion.text = "Huevo vendido +150€";
                textoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
        if (!encontrado)
        {
            textoInformacion.text = "No tienes huevos para vender";
        }
    }
}
