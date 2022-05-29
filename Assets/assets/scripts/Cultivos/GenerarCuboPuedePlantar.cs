using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarCuboPuedePlantar : MonoBehaviour
{

    Vector3 posicionCuboPuedePlantar;
    GameObject cuboPuedePlantar,HUDPlantar;

    private void Start()
    {
        HUDPlantar = GameObject.Find("HUD/HUDPlantar");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            if (!this.GetComponent<zonaOcupada>().estaOcupado())
            {
                GameObject tomatera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/TomatoPlant_01");
                GameObject PlantaMaizActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Corn_Plant");
                GameObject PlantaBerenjenaActivo = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Eggplant_Plant");

                if (tomatera.activeSelf || PlantaMaizActivo.activeSelf || PlantaBerenjenaActivo.activeSelf)
                {
                    // Añade un cubo de color verde mostrando que si puede plantar
                    HUDPlantar.SetActive(true);
                    cuboPuedePlantar = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cuboPuedePlantar.GetComponent<Collider>().isTrigger = true;
                    cuboPuedePlantar.name = "CuboPuedePlantar";
                    cuboPuedePlantar.transform.position = this.transform.position;
                    cuboPuedePlantar.GetComponent<MeshRenderer>().material.color = Color.green;
                    //posicionCuboPuedePlantar = new Vector3(other.bounds.size.x, other.bounds.size.y, other.bounds.size.z);
                    posicionCuboPuedePlantar = this.GetComponent<Collider>().bounds.size;
                    cuboPuedePlantar.transform.localScale = this.transform.localScale;
                }

                if (!!tomatera.activeSelf && !!PlantaMaizActivo.activeSelf && !!PlantaBerenjenaActivo.activeSelf)
                {
                    Destroy(cuboPuedePlantar);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            HUDPlantar.SetActive(false);
            Destroy(cuboPuedePlantar);
        }
    }
}
