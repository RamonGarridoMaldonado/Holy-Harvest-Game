using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueblesComprados : MonoBehaviour
{
    public bool balonC = false, plantaC = false, estanteriaLibrosC = false, lavadorC = false, librosAbajoC = false, mesaAbajoC = false, silla1C = false, sillonArribaC = false, sillonFueraC = false, sillonPlantaBajaC = false, vitroceramicaC = false, mesitaArribaC = false, mesitaArriba2C = false;

    #region Funciones para activar los muebles
    public void balonComprado()
    {
        balonC = true;
        GameObject mueble = GameObject.Find("Casa/House/Ball_1");
        mueble.SetActive(true);
    }

    public void plantaComprada()
    {
        plantaC = true;
        GameObject mueble = GameObject.Find("Casa/House/House_Plant_1");
        mueble.SetActive(true);
    }

    public void estanteriaLibrosComprado()
    {
        estanteriaLibrosC = true;
        GameObject mueble = GameObject.Find("Casa/House/BookCase_2");
        mueble.SetActive(true);
    }

    public void lavadorComprado()
    {
        lavadorC = true;
        GameObject mueble = GameObject.Find("Casa/House/Sink_1");
        mueble.SetActive(true);
    }

    public void librosAbajoComprado()
    {
        librosAbajoC = true;
        GameObject mueble = GameObject.Find("Casa/House/Books_1_1");
        mueble.SetActive(true);
    }

    public void mesaAbajoComprada()
    {
        mesaAbajoC = true;
        GameObject mueble = GameObject.Find("Casa/House/CoffeTable_1");
        mueble.SetActive(true);
    }

    public void silla1Comprada()
    {
        silla1C = true;
        GameObject mueble = GameObject.Find("Casa/House/Chair_7");
        mueble.SetActive(true);
    }

    public void sillonArribaComprado()
    {
        sillonArribaC = true;
        GameObject mueble = GameObject.Find("Casa/House/Couch_1");
        mueble.SetActive(true);
    }

    public void sillonFueraComprado()
    {
        sillonFueraC = true;
        GameObject mueble = GameObject.Find("Casa/House/Chair_4");
        mueble.SetActive(true);
    }

    public void sillonPlantaBajaComprado()
    {
        sillonPlantaBajaC = true;
        GameObject mueble = GameObject.Find("Casa/House/Couch_3");
        mueble.SetActive(true);
    }

    public void vitroceramicaComprada()
    {
        vitroceramicaC = true;
        GameObject mueble = GameObject.Find("Casa/House/Cooker_1");
        mueble.SetActive(true);
    }

    public void mesitaArribaComprada()
    {
        mesitaArribaC = true;
        GameObject mueble = GameObject.Find("Casa/House/Headboard_1_2");
        mueble.SetActive(true);
    }

    public void mesitaArriba2Comprada()
    {
        mesitaArriba2C = true;
        GameObject mueble = GameObject.Find("Casa/House/Headboard_1_1");
        mueble.SetActive(true);
    }

    #endregion

    #region Set y Get
    public bool getBalonC()
    {
        return balonC;
    }

    public void setBalonC()
    {
        balonC = true;
    }

    public bool getPlantaC()
    {
        return plantaC;
    }

    public void setPlantaC()
    {
        plantaC = true;
    }

    public bool getEstanteriaLibrosC()
    {
        return estanteriaLibrosC;
    }

    public void setestanteriaLibrosC()
    {
        estanteriaLibrosC = true;
    }

    public bool getLavadorC()
    {
        return lavadorC;
    }

    public void setLavadorC()
    {
        lavadorC = true;
    }

    public bool getLibrosAbajoC()
    {
        return librosAbajoC;
    }

    public void setlibrosAbajoC()
    {
        librosAbajoC = true;
    }

    public bool getMesaAbajoC()
    {
        return mesaAbajoC;
    }

    public void setMesaAbajoC()
    {
        mesaAbajoC = true;
    }

    public bool getSilla1C()
    {
        return silla1C;
    }

    public void setsilla1C()
    {
        silla1C = true;
    }

    public bool getSillonArribaC()
    {
        return sillonArribaC;
    }

    public void setsillonArribaC()
    {
        sillonArribaC = true;
    }

    public bool getSillonFueraC()
    {
        return sillonArribaC;
    }

    public void setSillonArribaC()
    {
        sillonArribaC = true;
    }

    public bool getsillonFueraC()
    {
        return sillonFueraC;
    }

    public void setsillonFueraC()
    {
        sillonFueraC = true;
    }

    public bool getSillonPlantaBajaC()
    {
        return sillonPlantaBajaC;
    }

    public void setSillonPlantaBajaC()
    {
        sillonPlantaBajaC = true;
    }

   public bool getVitroceramicaC()
    {
        return vitroceramicaC; 
    }

    public void setVitroceramicaC()
    {
        vitroceramicaC = true;
    }

    public bool getMesitaArribaC()
    {
        return mesitaArribaC;
    }

    public void setMesitaArribaC()
    {
        mesitaArribaC = true;
    }

    public bool getMesitaArriba2C()
    {
        return mesitaArriba2C;
    }

    public void setMesitaArriba2C()
    {
        mesitaArriba2C = true;
    }
    #endregion
}
