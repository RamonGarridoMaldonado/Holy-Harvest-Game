using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComprarTerrenoFinal : MonoBehaviour
{

    public GameObject entrada1, entrada2,entrada3,entrada4,entrada5,entrada6, HUDComprarTerreno, cartel;
    Text TextoDinero;   
    GameObject HUDInventario;
    private bool sePuedeComprar = false;
    public int precioTerreno;
    private bool zonaDestruida = false;

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
         if (Input.GetKeyDown(KeyCode.E) && (GameManager.getDinero()>= precioTerreno) && sePuedeComprar) {
            comprarT();
         }

        if (GameManager.getPlantacionComprada() && !zonaDestruida)
        {
            Destroy(entrada1);
            Destroy(entrada2);
            Destroy(entrada3);
            Destroy(entrada4);
            Destroy(entrada5);
            Destroy(entrada6);
            Destroy(cartel);
            zonaDestruida = true;
        }
    }

    
    private void comprarT() {
        if (GameManager.getDinero()>=precioTerreno && !GameManager.getPlantacionComprada()) {
            Destroy(entrada1);
            Destroy(entrada2);
            Destroy(entrada3);
            Destroy(entrada4);
            Destroy(entrada5);
            Destroy(entrada6);
            Destroy(cartel);
            HUDComprarTerreno.SetActive(false);
            GameManager.setRestarDinero(precioTerreno);
            TextoDinero.text = GameManager.getDinero().ToString() + " $";
            print ("Se ha comprado el terreno");
            GameManager.setPlantacionComprada();
        } else {
            print ("no tienes suficiente dinero");
        }
    }
}
