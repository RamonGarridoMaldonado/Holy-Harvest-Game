using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarEstadoJugador : MonoBehaviour
{
    public GameObject Jugador;
    public float estamina;
    public Dictionary<string, int> objetosBolsa;

    private void Start()
    {
        estamina = Jugador.GetComponent<BarraDeEstamina>().verEstaminaActual();
        objetosBolsa = this.GetComponent<Bolsa>().obtenerObjetosBolsa();
    }
}
