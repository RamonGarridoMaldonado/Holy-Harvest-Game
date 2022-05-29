using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolsaTienda : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] backPack;
    private bool estaInstanciado;
    public bool ActivarInventario;
    Text textoCantidad;

    // Diccionario para guardar los objetos (String para el nombre del objeto e Int para la cantidad)
    public Dictionary<string, int> objetosBolsa = new Dictionary<string, int>();

    // Esta funci�n sirve para controlar que slots est�n vac�os y cuales ocupados
    public void verificarSlotVacio(GameObject itemToAdd, string nombreItem, int cantidadAgregar)
    {
        estaInstanciado = false;
        for (int i = 0; i < slots.Length; i++)
        {
            // Comprueba si el siguiente slot est� vacio o est� en uso
            if (slots[i].transform.childCount > 0)
            {
                slots[i].GetComponent<SlotScript>().estaEnUso = true;
            }
            // En el caso de que no est� vac�o
            else if (!estaInstanciado && !slots[i].GetComponent<SlotScript>().estaEnUso)
            {
                // Creamos el item en la casilla vac�a
                if (!objetosBolsa.ContainsKey(nombreItem))
                {
                    // Instanciamos el item en la bolsa
                    GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
                    item.transform.SetParent(slots[i].transform, false);
                    item.transform.localPosition = new Vector3(0, 0, 0);
                    item.name = item.name.Replace("(Clone)", "");
                    estaInstanciado = true;
                    slots[i].GetComponent<SlotScript>().estaEnUso = true;
                    objetosBolsa.Add(nombreItem, cantidadAgregar);
                    print(cantidadAgregar);
                    textoCantidad = slots[i].GetComponentInChildren<Text>();
                    textoCantidad.text = cantidadAgregar.ToString();
                    break;
                }
                else
                {
                    for (int j = 0; j < slots.Length; j++)
                    {
                        if (slots[j].transform.GetChild(0).gameObject.name == nombreItem)
                        {
                            objetosBolsa[nombreItem] += cantidadAgregar;
                            textoCantidad = slots[j].GetComponentInChildren<Text>();
                            textoCantidad.text = objetosBolsa[nombreItem].ToString();
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    public void usarObjetoInventario(string nombreItem)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.GetChild(0).gameObject.name == nombreItem)
            {
                objetosBolsa[nombreItem]--;
                textoCantidad.text = objetosBolsa[nombreItem].ToString();

                if (objetosBolsa[nombreItem] <= 0)
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    slots[i].GetComponent<SlotScript>().estaEnUso = false;
                    objetosBolsa.Remove(nombreItem);
                }
                break;
            }
        }
    }

    private void organizarBolsa()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            // Si no est� usado el slot
            if (!slots[i].GetComponent<SlotScript>().estaEnUso)
            {
                for (int j = 0; j < slots.Length; j++)
                {
                    if (slots[j].GetComponent<SlotScript>().estaEnUso)
                    {
                        // Mueve el objeto al anterior slot y especifica que ahora est� en uso.
                        Transform moverObjeto = slots[j].transform.GetChild(0).transform;
                        moverObjeto.transform.SetParent(slots[i].transform, false);
                        moverObjeto.transform.localPosition = new Vector3(0, 0, 0);
                        slots[i].GetComponent<SlotScript>().estaEnUso = true;
                        slots[j].GetComponent<SlotScript>().estaEnUso = false;
                        break;
                    }
                }
            }
        }
    }
}
