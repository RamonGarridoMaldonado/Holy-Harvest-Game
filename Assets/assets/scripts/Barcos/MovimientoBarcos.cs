using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBarcos : MonoBehaviour
{
    float velocidad = 5f;
    public Transform punto1, punto2, punto3, punto4;
    private Transform siguientePunto;
    private int contador=0;

    // Start is called before the first frame update
    void Start()
    {
        siguientePunto = punto1;
        transform.LookAt(new Vector3(siguientePunto.position.x, transform.position.y, siguientePunto.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Punto")
        {
            print(contador);
            contador++;
            if (contador==4)
            {
                Destroy(this.gameObject);
            }
            switch (contador)
            {
                case 1:
                    siguientePunto = punto2;
                    break;
                case 2:
                    siguientePunto = punto3;
                    break;
                case 3:
                    siguientePunto = punto4;
                    break;

            }
        }
        this.transform.LookAt(new Vector3(siguientePunto.position.x, transform.position.y, siguientePunto.position.z));
    }
}
