using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject HUDPlantar, HUDComprarTerreno;
    private static GameObject HUDRegar,jugador;
    public GameObject HUDComprar, HUDInventario, Planta, CanvasTienda, TomateraPlanta, MaizPlanta, BerenjenaPlanta,regadera,berenjena;
    public static int dinero = 99999, mueblesComprados;
    public Text TextoDinero;
    Bolsa bolsa;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        bolsa = this.GetComponent<Bolsa>();

        HUDPlantar = GameObject.Find("HUDPlantar");
        HUDRegar = GameObject.Find("HUDRegar");
        HUDComprar = GameObject.Find("HUDComprar");
        HUDInventario = GameObject.Find("HUDInventario");
        HUDComprarTerreno = GameObject.Find("HUDComprarTerreno");
        jugador = GameObject.Find("Jugador/Personaje/Ch42_nonPBR");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        TextoDinero.text = dinero.ToString() + " $";

        HUDComprar.active = false;
        if (HUDPlantar!=null)
        {
            HUDPlantar.active = false;
        }
        if (HUDComprarTerreno!=null) 
        {
            HUDComprarTerreno.active = false;
        }
        if (HUDRegar!=null)
        {
            HUDRegar.active = false;
        }
        Cursor.visible = false;

        print(regadera);

        bolsa.verificarSlotVacio(TomateraPlanta, "Tomatera (USE) 1", 10);
        bolsa.verificarSlotVacio(MaizPlanta, "PlantaMaiz (USE) 2", 10);
        bolsa.verificarSlotVacio(BerenjenaPlanta, "PlantaBerenjena (USE) 2", 10);
        bolsa.verificarSlotVacio(regadera, "Regadera (USE)", 100);
        bolsa.verificarSlotVacio(berenjena, "Berenjena (USE) 1", 30);
    }
    // Update is called once per frame
    void Update()
    {
        if (dinero<=0) {
            bolsa.verificarSlotVacio(TomateraPlanta, "Tomatera (USE)", 5);
            dinero = 1;
        }
    }

    public static void setSumarDinero(int cantidad) {
        dinero += cantidad;
    }

    public static void setRestarDinero(int cantidad) {
        dinero -= cantidad;
    }

    public static int getDinero () {
        return dinero;
    }

    public static void mostrarRegar()
    {
        HUDRegar.SetActive(true);
    }

    public static void QuitarRegar()
    {
        HUDRegar.SetActive(false);
    }

    public static void guardarItems()
    {
        GameObject regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
        regadera.SetActive(false);
        GameObject tomatera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/TomatoPlant_01");
        tomatera.SetActive(false);
        GameObject PlantaMaiz = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Corn_Plant");
        PlantaMaiz.SetActive(false);
        GameObject PlantaBerenjena = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Eggplant_Plant");
        PlantaBerenjena.SetActive(false);  
    }

    public static void anadirCompraMueble()
    {
        mueblesComprados += 1;
    }

    public static int obtenerNumeroMueblesComprados()
    {
        return mueblesComprados;
    } 
}
