using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoNPCs : MonoBehaviour
{
    public float velocidad = 10f;
    public Transform punto1, punto2, punto3, punto4, punto5, punto6;
    private Transform siguientePunto;
    bool movimiento = true,hablando = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        int numeroAleatorio = UnityEngine.Random.Range(1, 6);
        switch (numeroAleatorio)
        {
            case 1:
                siguientePunto = punto1;
                break;
            case 2:
                siguientePunto = punto2;
                break;
            case 3:
                siguientePunto = punto3;
                break;
            case 4:
                siguientePunto = punto4;
                break;
            case 5:
                siguientePunto = punto5;
                break;
            case 6:
                siguientePunto = punto6;
                break;
        }
        transform.LookAt(new Vector3(siguientePunto.position.x, transform.position.y, siguientePunto.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (movimiento)
        {
            animator.SetBool("Caminando", true);
            transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
        }
        else if (!movimiento)
        {
            animator.SetBool("Caminando", false);
        }

        if (hablando)
        {
            animator.SetBool("Hablando", true);
        } else if (!hablando)
        {
            animator.SetBool("Hablando", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Punto")
        {
            int numeroAleatorio = UnityEngine.Random.Range(1, 6);
            switch (numeroAleatorio)
            {
                case 1:
                    siguientePunto = punto1;
                    break;
                case 2:
                    siguientePunto = punto2;
                    break;
                case 3:
                    siguientePunto = punto3;
                    break;
                case 4:
                    siguientePunto = punto4;
                    break;
                case 5:
                    siguientePunto = punto5;
                    break;
                case 6:
                    siguientePunto = punto6;
                    break;
            }
            transform.LookAt(new Vector3(siguientePunto.position.x, transform.position.y, siguientePunto.position.z));
            StartCoroutine("EsperarSiguientePunto");
        }

        if (other.tag == "HablarJugador")
        {
            print("Colision detectada con el jugador");
            movimiento = false;
            hablando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HablarJugador")
        {
            movimiento = true;
            hablando = false;
        }
    }

    IEnumerator EsperarSiguientePunto()
    {
        movimiento = false;
        int tiempoAleatorio = UnityEngine.Random.Range(1, 3);
        yield return new WaitForSeconds(tiempoAleatorio);
        movimiento = true;
    }
}

