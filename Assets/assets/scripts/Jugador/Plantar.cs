using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plantar : MonoBehaviour
{
    public GameObject HUDPlantar;
    public GameManager manager;
    private bool puedePlantar = false;
    public GameObject maiz,Tomate,plantaMaiz,PlantaTomatera, PlantaBerenjena;
    Vector3 posPlantar;
    GameObject zonaPlantacion;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && puedePlantar) 
        {
            GameObject tomatera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/TomatoPlant_01");
            if (tomatera.active && this.GetComponent<BarraDeEstamina>().verEstaminaActual() >=10 )
            {
                this.GetComponent<MovimientoJugador>().enabled = false;
                animator.SetFloat("velocidad", 0f, 0.1f, Time.deltaTime);
                animator.SetBool("plantando", true);
                StartCoroutine("esperarAnimacion");
                StartCoroutine("esperarPlantarTomate");
            }

            GameObject PlantaMaizActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Corn_Plant");
            if (PlantaMaizActivo.active && this.GetComponent<BarraDeEstamina>().verEstaminaActual() >=10)
            {
                this.GetComponent<MovimientoJugador>().enabled = false;
                animator.SetFloat("velocidad", 0f, 0.1f, Time.deltaTime);
                animator.SetBool("plantando", true);
                StartCoroutine("esperarAnimacion");
                StartCoroutine("esperarPlantarMaiz");
            }

            GameObject PlantaBerenjenaActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Eggplant_Plant");
            if (PlantaBerenjenaActivo.active && this.GetComponent<BarraDeEstamina>().verEstaminaActual() >=10) 
            {
                this.GetComponent<MovimientoJugador>().enabled = false;
                animator.SetFloat("velocidad", 0f, 0.1f, Time.deltaTime);
                animator.SetBool("plantando", true);
                StartCoroutine("esperarAnimacion");
                StartCoroutine("esperarPlantarBerenjena");
            }
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("triggerPlantacionPruebas"))
        {
            if (!other.GetComponent<zonaOcupada>().estaOcupado())
            {
                GameObject tomatera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/TomatoPlant_01");
                GameObject PlantaMaizActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Corn_Plant");
                GameObject PlantaBerenjenaActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Eggplant_Plant");


                if (tomatera.active || PlantaMaizActivo.active || PlantaBerenjenaActivo.active)
                {
                    puedePlantar = true;
                    zonaPlantacion = other.gameObject;
                    posPlantar = new Vector3(other.transform.position.x, other.transform.position.y - 0.3f, other.transform.position.z);
                }
            }
        }
    }

    [System.Obsolete]
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("triggerPlantacionPruebas"))
        { 
            HUDPlantar.active = false;
            puedePlantar = false;
        }
    }

    IEnumerator esperarAnimacion()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("plantando", false);
        animator.SetFloat("velocidad", 0f, 0.1f, Time.deltaTime);
    }

    IEnumerator esperarPlantarTomate()
    {
        yield return new WaitForSeconds(8);
        this.GetComponent<BarraDeEstamina>().restarEstamina(10);
        print(this.GetComponent<BarraDeEstamina>().verEstaminaActual());
        Instantiate(PlantaTomatera, posPlantar, Quaternion.identity);
        manager.GetComponent<Bolsa>().usarObjetoInventario("Tomatera (USE) 1");
        GameManager.objetosInventario[1].restarCantidad(1);
        zonaPlantacion.GetComponent<zonaOcupada>().establecerOcupado();
        this.GetComponent<MovimientoJugador>().enabled = true;
    }

    IEnumerator esperarPlantarMaiz()
    {
        yield return new WaitForSeconds(8);
        this.GetComponent<BarraDeEstamina>().restarEstamina(10);
        print(this.GetComponent<BarraDeEstamina>().verEstaminaActual());
        Instantiate(plantaMaiz, posPlantar, Quaternion.identity);
        manager.GetComponent<Bolsa>().usarObjetoInventario("PlantaMaiz (USE) 2");
        GameManager.objetosInventario[3].restarCantidad(1);
        zonaPlantacion.GetComponent<zonaOcupada>().establecerOcupado();
        this.GetComponent<MovimientoJugador>().enabled = true;
    }

    IEnumerator esperarPlantarBerenjena()
    {
        yield return new WaitForSeconds(8);
        this.GetComponent<BarraDeEstamina>().restarEstamina(10);
        print(this.GetComponent<BarraDeEstamina>().verEstaminaActual());
        Instantiate(PlantaBerenjena, posPlantar, Quaternion.identity);
        manager.GetComponent<Bolsa>().usarObjetoInventario("PlantaBerenjena (USE) 2");
        GameManager.objetosInventario[5].restarCantidad(1);
        zonaPlantacion.GetComponent<zonaOcupada>().establecerOcupado();
        this.GetComponent<MovimientoJugador>().enabled = true;
    }

}
