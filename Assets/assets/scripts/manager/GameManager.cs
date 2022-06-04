using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject HUDPlantar, HUDComprarTerreno;
    private static GameObject HUDRegar,jugador;
    public static  GameManager manager;
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

    public static void setLogro1Completado()
    {
        logrosMuebles.GetComponent<LogrosMuebles>().setLogro1Completado();
    }

    public static void setLogro2Completado()
    {
        logrosMuebles.GetComponent<LogrosMuebles>().setLogro2Completado();
    }

    public static void setLogro3Completado()
    {
        logrosMuebles.GetComponent<LogrosMuebles>().setLogro3Completado();
    }

    public static void setLogro4Completado()
    {
        logrosMuebles.GetComponent<LogrosMuebles>().setLogro4Completado();
    }

    public static string getBalonComprado()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getBalonC();
        return comprado.ToString();
    }

    public static void setBalonComprado()
    {
        Camera.main.GetComponent<MueblesComprados>().setBalonC();
    }

    public static string getPlantaComprado()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getPlantaC();
        return comprado.ToString();
    }

    public static void setPlantaComprado()
    {
        Camera.main.GetComponent<MueblesComprados>().setPlantaC();
    }

    public static string getEstanteriaLibros()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getEstanteriaLibrosC();
        return comprado.ToString();
    }

    public static void setEstanteriaLibros()
    {
        Camera.main.GetComponent<MueblesComprados>().setestanteriaLibrosC();
    }

    public static string getLavador()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getLavadorC();
        return comprado.ToString();
    }

    public static void setLavador()
    {
        Camera.main.GetComponent<MueblesComprados>().setLavadorC();
    }

    public static string getLibrosAbajo()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getLibrosAbajoC();
        return comprado.ToString();
    }

    public static void setLibrosAbajo()
    {
        Camera.main.GetComponent<MueblesComprados>().setlibrosAbajoC();
    }

    public static string getMesaAbajo()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getMesaAbajoC();
        return comprado.ToString();
    }

    public static void setMesaAbajo()
    {
        Camera.main.GetComponent<MueblesComprados>().setMesaAbajoC();
    }

    public static string getSilla1()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getSilla1C();
        return comprado.ToString();
    }

    public static void setSilla1()
    {
        Camera.main.GetComponent<MueblesComprados>().setsilla1C();
    }

    public static string getSillonArriba()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getSillonArribaC();
        return comprado.ToString();
    }

    public static void setSillonArriba()
    {
        Camera.main.GetComponent<MueblesComprados>().setSillonArribaC();
    }

    public static string getSillonFuera()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getSillonFueraC();
        return comprado.ToString();
    }

    public static void setSillonFuera()
    {
        Camera.main.GetComponent<MueblesComprados>().setsillonFueraC();
    }

    public static string getsillonPlantaBaja()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getSillonPlantaBajaC();
        return comprado.ToString();
    }

    public static void setsillonPlantaBaja()
    {
        Camera.main.GetComponent<MueblesComprados>().setSillonPlantaBajaC();
    }

    public static string getVitroceramica()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getVitroceramicaC();
        return comprado.ToString();
    }

    public static void setVitroceramica()
    {
        Camera.main.GetComponent<MueblesComprados>().setVitroceramicaC();
    }

    public static string getMesitaArriba()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getMesitaArribaC();
        return comprado.ToString();
    }

    public static void setMesitaArriba()
    {
        Camera.main.GetComponent<MueblesComprados>().setMesitaArribaC();
    }

    public static string getMesitaArriba2()
    {
        bool comprado = Camera.main.GetComponent<MueblesComprados>().getMesitaArriba2C();
        return comprado.ToString();
    }

    public static void setMesitaArriba2()
    {
        Camera.main.GetComponent<MueblesComprados>().setMesitaArriba2C();
    }
}
