using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarMuebles : MonoBehaviour
{
    public GameObject imagenVendido, HUDInventario;
    public Text TextoDinero;

    #region balon
    public void comprarBalon() {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 200)
            {
                Camera.main.GetComponent<MueblesComprados>().setBalonC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(200);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region planta
    public void comprarPlanta() {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 250)
            {
                Camera.main.GetComponent<MueblesComprados>().setPlantaC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(250);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region estanteria Libros
    public void comprarEstanteriaLibros()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                Camera.main.GetComponent<MueblesComprados>().setestanteriaLibrosC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region lavador
    public void comprarLavador()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                Camera.main.GetComponent<MueblesComprados>().setLavadorC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region libros Abajo
    public void comprarLibrosAbajo()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 150)
            {
                Camera.main.GetComponent<MueblesComprados>().setlibrosAbajoC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(150);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region mesa Abajo
    public void comprarMesaAbajo()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 450)
            {
                Camera.main.GetComponent<MueblesComprados>().setMesaAbajoC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(450);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region silla1
    public void comprarSilla1()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 150)
            {
                Camera.main.GetComponent<MueblesComprados>().setsilla1C();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(150);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Sillon Arriba
    public void comprarSillonArriba()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                Camera.main.GetComponent<MueblesComprados>().setSillonArribaC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Sillon Fuera
    public void comprarSillonFuera()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 450 )
            {
                Camera.main.GetComponent<MueblesComprados>().setsillonFueraC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(450);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Sillon Planta Baja
    public void comprarSillonPlantaBaja()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 600)
            {
                Camera.main.GetComponent<MueblesComprados>().setSillonPlantaBajaC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(600);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Vitroceramica
    public void comprarVitroceramica()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                Camera.main.GetComponent<MueblesComprados>().setVitroceramicaC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Mesita Arriba
    public void comprarMesitaArriba()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 500)
            {
                Camera.main.GetComponent<MueblesComprados>().setMesitaArribaC();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(500);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion

    #region Mesita Arriba 2
    public void comprarMesitaArriba2()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        if (!imagenVendido.activeSelf)
        {
            if (GameManager.getDinero() >= 400)
            {
                Camera.main.GetComponent<MueblesComprados>().setMesitaArriba2C();
                //GameManager.anadirCompraMueble();
                imagenVendido.SetActive(true);
                GameManager.setRestarDinero(400);
                TextoDinero.text = GameManager.getDinero().ToString() + " $";
            }
        }
    }
    #endregion
}
