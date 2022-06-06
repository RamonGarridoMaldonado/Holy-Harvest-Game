using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TemporizadorCultivos : MonoBehaviour
{
    public float tiempoCosechar;
    public GameObject cosecha;
    public TextMeshPro textoContador;
    TextMeshPro textoClonado;
    bool puedeRegar = true, dentroRango = false, regada = false;
    GameObject regadera, jugador;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
        GameObject jugador = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR");
        Vector3 posTexto = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        textoClonado = Instantiate(textoContador, posTexto, Quaternion.identity);
        animator = jugador.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        tiempoCosechar -= Time.deltaTime;
        int tiempoMostrar = Convert.ToInt32(tiempoCosechar);
        if (tiempoCosechar<=0) {
            Destroy(textoClonado);
            cosechar();
        }

        if (regada)
        {
            textoClonado.SetText(tiempoMostrar.ToString()+ "Regado");

        }
        else
        {
            textoClonado.SetText(tiempoMostrar.ToString());

        }
        textoClonado.transform.LookAt(Camera.main.transform);
        textoClonado.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        if (Input.GetKeyDown(KeyCode.Q) && puedeRegar)
        {
            if (dentroRango)
            {
                GameObject regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
                if (regadera.active)
                {
                    print(dentroRango);
                    print(puedeRegar);
                    GameManager.mostrarRegar();
                    //jugador.GetComponent<PlantarRegar>().enabled = false;
                    regar();
                }
            }
        }  
    }

    public void cosechar() {
        Vector3 posCosecha = new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z);
        Instantiate(cosecha, posCosecha, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void regar()
    {
        if (!regada)
        {
            //jugador.GetComponent<BarraDeEstamina>().restarEstamina(10);
            this.regada = true;
            print("regada");
            this.tiempoCosechar -=  4f;
            animator.SetFloat("velocidad", 0f, 0.1f, Time.deltaTime);
            animator.SetBool("regando", true);
            StartCoroutine("esperarAnimacion");
        }
        else
        {
            print("Esta planta ya ha sido regada");
        }
    }

    [Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        print("puede regar");
        dentroRango = true;
        GameObject regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
        if (regadera.active)
        {
            if (!regada) GameManager.mostrarRegar();
        }
    }

    [Obsolete]
    private void OnTriggerExit(Collider other)
    {
        dentroRango = false;
        print("no puede regar");
        print(dentroRango);
        dentroRango = false;
        GameObject regadera = GameObject.Find("Casa/Jugador/Personaje/Ch42_nonPBR/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand/WateringCan_01");
        if (regadera.active)
        {
            GameManager.QuitarRegar();
        }
    }

    IEnumerator esperarAnimacion()
    {
        jugador.GetComponent<MovimientoJugador>().enabled = false;
        print("Entra en la corutina");
        yield return new WaitForSeconds(3);
        animator.SetBool("regando", false);
        jugador.GetComponent<MovimientoJugador>().enabled = true;
    }
}
