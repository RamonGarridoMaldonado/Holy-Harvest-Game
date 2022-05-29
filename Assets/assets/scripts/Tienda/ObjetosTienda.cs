using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosTienda : MonoBehaviour
{
    public GameObject itemToAdd;
    public int cantidadObjeto;
    Bolsa bolsa;
    GameManagerSingleton gameManager;

    public GameObject HUDInventario;
    public Text TextoDinero;

    public string nombreObjeto;
    public int precioVenta;
    public int precioCompra;

    Text textoPrecio;

    private void Start()
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
        gameManager = GameManagerSingleton.instance;
        bolsa = gameManager.GetComponent<Bolsa>();
        nombreObjeto = itemToAdd.name;
        textoPrecio = gameObject.GetComponentInChildren<Text>();
        textoPrecio.text = precioCompra.ToString()+ " $";
    } 

    public void comprarObjeto() {
        if (precioCompra<=GameManager.getDinero()) {
            GameManager.setRestarDinero(precioCompra);
            bolsa.verificarSlotVacio(itemToAdd,itemToAdd.name, cantidadObjeto);
            TextoDinero.text = GameManager.getDinero().ToString() + " $";
        }
    }
}
