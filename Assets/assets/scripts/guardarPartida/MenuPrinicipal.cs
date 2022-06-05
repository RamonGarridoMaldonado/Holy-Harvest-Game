using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrinicipal : MonoBehaviour
{
    public GameObject HUDPrincipal, HUDClasificacion;
    public Text textoPuntuacion;


    public void continuarPartida() {
        SceneManager.LoadScene("Granja 2");
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("RegistrarLogear");
    }

    public void verEscenaPuntuaciones() {
        SceneManager.LoadScene("VerPuntuacion");
    }
}
