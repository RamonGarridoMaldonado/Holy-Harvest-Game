using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{
    public void exit()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.EnviarDineroATabla();
        pfb.GuardarDatosJugador(GameManager.obtenerEstamina().ToString(), GameManager.getDinero().ToString(), GameManager.getLogro1Conseguido(),
        GameManager.getLogro2Conseguido(), GameManager.getLogro3Conseguido(), GameManager.getLogro4Conseguido());
    }
}
