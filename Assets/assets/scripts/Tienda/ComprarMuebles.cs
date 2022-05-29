using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarMuebles : MonoBehaviour
{
    public GameObject imagenVendido, HUDInventario;
    public Text TextoDinero;

    public void comprarBalon() {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 200)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Ball_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(200);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarPlanta() {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 250)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/House_Plant_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(250);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarEstanteriaLibros()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/BookCase_2");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarLavador()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Sink_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarLibrosAbajo()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 150)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Books_1_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(150);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarMesaAbajo()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 450)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/CoffeTable_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(450);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarSilla1()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 150)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Chair_7");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(150);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarSillonArriba()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Couch_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarSillonFuera()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 450 )
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Chair_4");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(450);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarSillonPlantaBaja()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Couch_3");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarVitroceramica()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Cooker_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarMesitaArriba()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 500)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Headboard_1_2");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(500);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }

    public void comprarMesitaArriba2()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                GameManager.anadirCompraMueble();
                GameObject mueble = GameObject.Find("Casa/House/Headboard_1_1");
                mueble.SetActive(true);
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
}
