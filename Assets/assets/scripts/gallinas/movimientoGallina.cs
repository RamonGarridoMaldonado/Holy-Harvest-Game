using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoGallina : MonoBehaviour
{
    float velocidad = 2f;
    public Transform punto1, punto2, punto3, punto4, punto5, punto6;
    private Transform siguientePunto;
    bool movimiento = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        int numeroAleatorio = UnityEngine.Random.Range(1, 6);
        switch(numeroAleatorio)
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
            animator.SetBool("Turn Head", false);
            animator.SetBool("Run", true);
            transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
        } else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Turn Head", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Punto")
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
    }

    IEnumerator EsperarSiguientePunto()
    {
        movimiento = false;
        int tiempoAleatorio = UnityEngine.Random.Range(1, 3);
        yield return new WaitForSeconds(tiempoAleatorio);
        movimiento = true;
    }
}
