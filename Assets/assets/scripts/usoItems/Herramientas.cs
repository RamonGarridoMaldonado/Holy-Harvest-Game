using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herramientas : MonoBehaviour
{
    public static void usarRegadera()
    {
        GameManager.guardarItems();
        GameObject regadera;
        regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
        regadera.SetActive(true);
    }
}
