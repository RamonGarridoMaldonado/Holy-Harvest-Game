using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPartida : MonoBehaviour
{
    public GuardarEstadoJugador estadoJugador;

    public static void Guardar(MonoBehaviour partida)
    {
        PlayerPrefs.SetString("infoJugador",JsonUtility.ToJson(partida));
        Debug.Log(JsonUtility.ToJson(partida));
    }

    public static void CargarPartida(MonoBehaviour partida)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("infoJugador"), partida);
    }

    public void GuardarInformacion()
    {
        Guardar(estadoJugador);
    }

    public void CargarInformacion()
    {
        CargarPartida(estadoJugador);
    }
}
