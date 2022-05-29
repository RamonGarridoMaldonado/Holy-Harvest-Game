using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool ActivarInventario;
    public Image ImageItemEquipado;
    public GameObject jugador;

    public GameObject Selector;
    public int ID;

    public GameObject Opciones;
    public Image[] Seleccion;
    public Sprite[] Seleccion_Sprite;
    public int ID_Select;

    private void OnTriggerEnter(Collider collision)
    {
        // Compruebo si el objeto tiene la etiqueta "Item"
        if (collision.CompareTag("Item"))
        {
            // Recorro la lista de la bolsa
            for (int i=0;i<Bag.Count;i++)
            {
                // Compruebo si la imagen del objeto no está activa
                if (!Bag[i].GetComponent<Image>().enabled)
                {
                    // En tal caso, la activo
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = collision.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();

        if (ActivarInventario)
        {
            inv.SetActive(true);
            jugador.SetActive(false);
        } 
        else
        {
            inv.SetActive(false);
            jugador.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Esto hace que el inventario se active o desactive con la misma letra
            ActivarInventario = !ActivarInventario;
        }
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.D) && ID<Bag.Count-1)
        {
            ID++;
        }
        if (Input.GetKeyDown(KeyCode.A) && ID > 0)
        {
            ID--;
        }
        if (Input.GetKeyDown(KeyCode.W) && ID > 6)
        {
            ID -= 7;
        }
        if (Input.GetKeyDown(KeyCode.S) && ID < 14)
        {
            ID += 7;
        }
        // La posicion del selector es igual a la posición del id seleccionado
        Selector.transform.position = Bag[ID].transform.position;


        // Selecciona la imagen del item seleccionado y lo pone el el item equipado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivarInventario = false;
            ImageItemEquipado.sprite = Bag[ID].GetComponent<Image>().sprite;
        }
    }
}
