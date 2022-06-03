using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogrosMuebles : MonoBehaviour
{

    public GameObject HUDLogrosMuebles, completado1, completado2, completado3, completado4, HUDInventario, HUDMostrarLogro;
    Text TextoDinero;
    public Text textoLogro;
    public bool isCompLogro1 = false,isCompLogro2 = false,isCompLogro3 = false,isCompLogro4 = false;
    GameObject jugador;
    

    // Start is called before the first frame update
    void Start()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        jugador = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.obtenerNumeroMueblesComprados() == 1 && !completado1.activeSelf)
        {
            this.logroCompletado1();
        }

        if (GameManager.obtenerNumeroMueblesComprados() == 5 && !completado2.activeSelf)
        {
            this.logroCompletado2();
        }

        if (GameManager.obtenerNumeroMueblesComprados() == 10 && !completado3.activeSelf)
        {
            this.logroCompletado3();
        }

        if (GameManager.obtenerNumeroMueblesComprados() == 13 && !completado4.activeSelf)
        {
            this.logroCompletado4();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HUDLogrosMuebles.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        HUDLogrosMuebles.SetActive(false);
    }

    public void logroCompletado1()
    {
        isCompLogro1 = true;
        jugador.GetComponent<BarraDeEstamina>().sumarEstaminaTotal(10);
        jugador.GetComponent<BarraDeEstamina>().llenarEstamina();
        GameManager.setSumarDinero(400);
        TextoDinero.text = GameManager.getDinero().ToString() + " $";
        completado1.SetActive(true);
        StartCoroutine(mostrarLogro("Obten Tu primer mueble"));
        HUDMostrarLogro.SetActive(true);
    }

    public void logroCompletado2()
    {
        isCompLogro2 = true;
        jugador.GetComponent<BarraDeEstamina>().sumarEstaminaTotal(10);
        jugador.GetComponent<BarraDeEstamina>().llenarEstamina();
        GameManager.setSumarDinero(2000);
        TextoDinero.text = GameManager.getDinero().ToString() + " $";
        completado2.SetActive(true);
        StartCoroutine(mostrarLogro("Obten 5 muebles"));
        HUDMostrarLogro.SetActive(true);
    }

    public void logroCompletado3()
    {
        isCompLogro3 = true;
        jugador.GetComponent<BarraDeEstamina>().sumarEstaminaTotal(10);
        jugador.GetComponent<BarraDeEstamina>().llenarEstamina();
        GameManager.setSumarDinero(5000);
        TextoDinero.text = GameManager.getDinero().ToString() + " $";
        completado3.SetActive(true);
        StartCoroutine(mostrarLogro("Obten 10 muebles"));
        HUDMostrarLogro.SetActive(true);
    }

    public void logroCompletado4()
    {
        isCompLogro4 = true;
        jugador.GetComponent<BarraDeEstamina>().sumarEstaminaTotal(20);
        jugador.GetComponent<BarraDeEstamina>().llenarEstamina();
        GameManager.setSumarDinero(7500);
        TextoDinero.text = GameManager.getDinero().ToString() + " $";
        completado4.SetActive(true);
        StartCoroutine(mostrarLogro("Obten todos los muebles"));
        HUDMostrarLogro.SetActive(true);
    }

    IEnumerator mostrarLogro(string logro)
    {
        Color color = textoLogro.color;
        color.a = 0;
        textoLogro.text = logro;
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
        {
            color.a = alpha;
            textoLogro.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            color.a = alpha;
            textoLogro.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        HUDMostrarLogro.SetActive(false);
    }


    public bool isLogro1Completado() {
        return isCompLogro1;
    }

    public bool isLogro2Completado() {
        return isCompLogro2;
    }

    public bool isLogro3Completado() {
        return isCompLogro3;
    }

    public bool isLogro4Completado() {
        return isCompLogro4;
    }

    public void setLogro1Completado()
    {
        completado1.SetActive(true);
    }
    public void setLogro2Completado()
    {
        completado2.SetActive(true);
    }

    public void setLogro3Completado()
    {
        completado3.SetActive(true);
    }

    public void setLogro4Completado()
    {
        completado4.SetActive(true);
    }
}
