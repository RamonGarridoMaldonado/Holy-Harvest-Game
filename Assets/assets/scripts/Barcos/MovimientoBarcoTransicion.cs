using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBarcoTransicion : MonoBehaviour
{
    float velocidad = 22f;
    public Transform punto1;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(punto1.position.x, punto1.position.y, punto1.position.z));
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, velocidad * Time.deltaTime));
    }
}
