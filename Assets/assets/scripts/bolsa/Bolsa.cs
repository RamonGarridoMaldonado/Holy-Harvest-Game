using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bolsa : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] backPack;
    private bool estaInstanciado;
    public GameObject inv;
    public bool ActivarInventario;
    public GameObject jugador;
    Text textoCantidad;

    // Diccionario para guardar los objetos (String para el nombre del objeto e Int para la cantidad)
    public Dictionary<string,int> objetosBolsa = new Dictionary<string, int>();

    // Esta función sirve para controlar que slots están vacíos y cuales ocupados
    public void verificarSlotVacio(GameObject itemToAdd, string nombreItem, int cantidadAgregar)
    {
        estaInstanciado = false;
        for (int i=0;i<slots.Length;i++)
        {
            // Comprueba si el siguiente slot está vacio o está en uso
            if (slots[i].transform.childCount>0)
            {
                slots[i].GetComponent<SlotScript>().estaEnUso = true;
            }
            // En el caso de que no esté vacío
            else if (!estaInstanciado && !slots[i].GetComponent<SlotScript>().estaEnUso)
            {
                // Creamos el item en la casilla vacía
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
                    textoCantidad = slots[i].GetComponentInChildren<Text>();
                    textoCantidad.text = cantidadAgregar.ToString();
                    break; 
                }
                else
                {
                    for (int j=0;j<slots.Length;j++)
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

    public void usarObjetoInventario (string nombreItem) 
    {
        for (int i=0;i<slots.Length;i++) {
            print(nombreItem);
            if (slots[i].transform.GetChild(0).gameObject.name == nombreItem) {
                print(slots[i].transform.GetChild(0).gameObject.name + " " + nombreItem);
                foreach (var objectos in objetosBolsa)
                {
                    print (objectos.Key +" Cantidad: "+ objectos.Value);
                }
                objetosBolsa[nombreItem]--;
                print("\n\n");
                foreach (var objectos in objetosBolsa)
                {
                    print(objectos.Key + " Cantidad: " + objectos.Value);
                }
                textoCantidad = slots[i].GetComponentInChildren<Text>();
                textoCantidad.text = objetosBolsa[nombreItem].ToString();
                if (objetosBolsa[nombreItem] <= 0) {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    slots[i].GetComponent<SlotScript>().estaEnUso = false;
                    objetosBolsa.Remove(nombreItem);
                    GameManager.guardarItems();
                    organizarBolsa();
                }
                break;
            }
        }
    }

    private void organizarBolsa () {
        for (int i=0;i<slots.Length;i++) {
            // Si no está usado el slot
            if (!slots[i].GetComponent<SlotScript>().estaEnUso) {
                for (int j=0;j<slots.Length;j++) {
                    if (slots[j].GetComponent<SlotScript>().estaEnUso) {
                        // Mueve el objeto al anterior slot y especifica que ahora está en uso.
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


    private void Update()
    {
        // Al activar el inventario se activa el cursor y se desactiva el jugador para que no pueda moverse mientras está en el menú  
        if (ActivarInventario)
        {
            Cursor.visible = true;
            inv.SetActive(true);
            jugador.SetActive(false);
        }
        // Si el inventario está desactivado, se vuelve a activar el gameObject del jugador jugador para que pueda volver a moverse
        else
        {
            Cursor.visible = false;
            inv.SetActive(false);
            jugador.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Esto hace que el inventario se active o desactive con la misma letra
            ActivarInventario = !ActivarInventario;
        }
    }
}
