using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    public void usartomate()
    {
        GameManager.guardarItems();
        GameObject tomate = GameObject.Find("Personaje/Ch42_nonPBR/Comida/Tomato_03");
        tomate.SetActive(true);
    }
}
