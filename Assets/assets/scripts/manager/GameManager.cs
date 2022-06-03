using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject HUDPlantar, HUDComprarTerreno;
    private static GameObject HUDRegar,jugador;
    public GameManager manager;
    public GameObject HUDComprar, HUDInventario, Planta, CanvasTienda, TomateraPlanta, MaizPlanta, BerenjenaPlanta,regadera,berenjena;
    public static GameObject logrosMuebles;
    public static int dinero = 11111, mueblesComprados;
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
        logrosMuebles = GameObject.Find("Templo Logros/LogrosMuebles/TriggerLogrosMuebles");

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

        bolsa.verificarSlotVacio(TomateraPlanta, "Tomatera (USE) 1", 10);
        bolsa.verificarSlotVacio(MaizPlanta, "PlantaMaiz (USE) 2", 10);
        bolsa.verificarSlotVacio(BerenjenaPlanta, "PlantaBerenjena (USE) 2", 10);
        bolsa.verificarSlotVacio(regadera, "Regadera (USE)", 100);
        //bolsa.verificarSlotVacio(berenjena, "Berenjena (USE) 1", 30);
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

    public static void establecerDinero(int dineroGuardado)
    {
        dinero = dineroGuardado;
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

    public static float obtenerEstamina()
    {
        return jugador.GetComponent<BarraDeEstamina>().verEstaminaActual();
    }

    public static void establecerEstamina(float estaminaGuardada)
    {
       jugador.GetComponent<BarraDeEstamina>().setEstamina(estaminaGuardada);

    }

    public Dictionary<string,int> obtenerBolsa()
    {
        return manager.GetComponent<Bolsa>().obtenerObjetosBolsa();
    }

    public static string getLogro1Conseguido() {
        bool logro1 = logrosMuebles.GetComponent<LogrosMuebles>().isLogro1Completado();
        return logro1.ToString();
    }

    public static string getLogro2Conseguido() {
        bool logro2 = logrosMuebles.GetComponent<LogrosMuebles>().isLogro2Completado();
        return logro2.ToString();
    }

    public static string getLogro3Conseguido() {
        bool logro3 = logrosMuebles.GetComponent<LogrosMuebles>().isLogro3Completado();
        return logro3.ToString();
    }

    public static string getLogro4Conseguido() {
        bool logro4 = logrosMuebles.GetComponent<LogrosMuebles>().isLogro4Completado();
        return logro4.ToString();
    }
}
