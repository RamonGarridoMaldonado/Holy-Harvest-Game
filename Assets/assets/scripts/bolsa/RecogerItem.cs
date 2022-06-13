using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerItem : MonoBehaviour
{
    public GameObject itemToAdd;
    public int cantidadObjeto;
    Bolsa bolsa;
    GameManagerSingleton gameManager;

    private void Start()
    {
        gameManager = GameManagerSingleton.instance;
        bolsa = gameManager.GetComponent<Bolsa>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "gallina")
        {
            bolsa.verificarSlotVacio(itemToAdd, itemToAdd.name, cantidadObjeto);
            Destroy(gameObject);
            if (itemToAdd.name.Equals("Tomate (USE)"))
            {
                GameManager.objetosInventario[0].sumarCantidad(1);
                GameManager.objetosInventario[0].getCantidad();
                print("tomate recogido");
            } else if (itemToAdd.name.Equals("Maiz (USE)"))
            {
                GameManager.objetosInventario[4].sumarCantidad(1);
                print("maiz recogido");
            }
            else if (itemToAdd.name.Equals("Berenjena (USE) 1"))
            {
                GameManager.objetosInventario[6].sumarCantidad(1);
                print("berenjena recogido");
            }
            else if (itemToAdd.name.Equals("Huevo (USE) 2"))
            {
                GameManager.objetosInventario[7].sumarCantidad(1);
                GameManager.objetosInventario[7].getCantidad();
                print("huevo recogido");

            }
        }
    }
}
