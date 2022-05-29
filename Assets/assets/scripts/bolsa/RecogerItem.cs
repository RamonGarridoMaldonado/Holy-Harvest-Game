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
        }
    }
}
