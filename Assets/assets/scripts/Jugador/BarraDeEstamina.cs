using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeEstamina : MonoBehaviour
{
    public Image barraDeEstamina,imagenCansado,imagenNormal;
    public float EstaminaActual,estaminaMaxima;
    public Text textoEstamina;

    // Update is called once per frame
    void Update() 
    {
        barraDeEstamina.fillAmount= EstaminaActual / 100;
        textoEstamina.text = "";
        textoEstamina.text = EstaminaActual.ToString()+ " / 100" ;
    }

    public void restarEstamina(float restar) {
        EstaminaActual -= restar;
    }

    public float verEstaminaActual() {
        return EstaminaActual;
    }

    public void sumarEstaminaTotal(float sumar)
    {
        estaminaMaxima += sumar;
    }

    public void llenarEstamina() {
        EstaminaActual = estaminaMaxima;
    }

    public void setEstamina(float estaminaGuardada)
    {
        EstaminaActual = estaminaGuardada;
    }
}
