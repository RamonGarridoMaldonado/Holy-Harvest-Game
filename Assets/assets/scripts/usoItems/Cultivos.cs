using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivos : MonoBehaviour
{
    public void usarTomatera()
    {
        GameManager.guardarItems();
        GameObject tomatera;
        tomatera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/TomatoPlant_01");
        tomatera.SetActive(true);
        GameObject HUDBolsa = GameObject.Find("/HUD/HUDBolsa");
        HUDBolsa.SetActive(false);
    }

    
    public void usarPlantaMaiz()
    {
        GameManager.guardarItems();
        GameObject PlantaMaiz;
        PlantaMaiz = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Corn_Plant");
        PlantaMaiz.SetActive(true);
        GameObject HUDBolsa = GameObject.Find("/HUD/HUDBolsa");
        HUDBolsa.SetActive(false);
    }

    public void usarPlantaBerenjena()
    {
        GameManager.guardarItems();
        GameObject PlantaBerenjena;
        PlantaBerenjena = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/Eggplant_Plant");
        PlantaBerenjena.SetActive(true);
        GameObject HUDBolsa = GameObject.Find("/HUD/HUDBolsa");
        HUDBolsa.SetActive(false);
    }
}
