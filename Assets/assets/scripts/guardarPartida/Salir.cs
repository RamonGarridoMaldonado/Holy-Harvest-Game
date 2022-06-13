using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    public void exit()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.EnviarDineroATabla();
        pfb.GuardarDatosJugador(GameManager.obtenerEstamina().ToString(), GameManager.getDinero().ToString(), GameManager.getBalonComprado(), GameManager.getPlantaComprado(), GameManager.getEstanteriaLibros(), GameManager.getLavador(), GameManager.getLibrosAbajo(),GameManager.getPlantacionComprada().ToString());
        pfb.guardarInventario();
        SceneManager.LoadScene("MenuInicial");
    }

    public void exitPueblo()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.EnviarDineroATabla();
        pfb.GuardarDatosJugadorPueblo(GameManager.obtenerEstamina().ToString(), GameManager.getDinero().ToString(), GameManager.getBalonComprado(), GameManager.getPlantaComprado(), GameManager.getEstanteriaLibros(), GameManager.getLavador(), GameManager.getLibrosAbajo(), GameManager.getPlantacionComprada().ToString());
        pfb.guardarInventario();
        SceneManager.LoadScene("MenuInicial");
    }

    public void salirJuego()
    {
        Application.Quit();
    }
}
