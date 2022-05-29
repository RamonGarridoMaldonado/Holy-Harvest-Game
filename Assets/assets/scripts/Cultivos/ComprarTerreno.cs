using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComprarTerreno : MonoBehaviour
{

    public GameObject entrada1, entrada2, colisionentrar, HUDComprarTerreno, cartel;
    Text TextoDinero;   
    GameObject HUDInventario;
    private bool sePuedeComprar = false;
    public int precioTerreno;

    private void OnTriggerEnter(Collider other)
    {
        HUDComprarTerreno.SetActive(true);
        sePuedeComprar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        HUDComprarTerreno.SetActive(false);
        sePuedeComprar = false;
    }

    private void Start() 
    {
        HUDInventario = GameObject.Find("HUDInventario");
        TextoDinero = HUDInventario.transform.Find("TextoDinero").GetComponent<Text>();
    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.E) && (GameManager.getDinero()>=5000) && sePuedeComprar) {
            comprarT();
         }
     }

    
    private void comprarT() {
        if (GameManager.getDinero()>=precioTerreno) {
            Destroy(entrada1);
            Destroy(entrada2);
            Destroy(colisionentrar);
            Destroy(cartel);
            HUDComprarTerreno.SetActive(false);
            GameManager.setRestarDinero(precioTerreno);
            TextoDinero.text = GameManager.getDinero().ToString() + " $";
            print ("Se ha comprado el terreno");
        } else {
            print ("no tienes suficiente dinero");
        }
    }
}
