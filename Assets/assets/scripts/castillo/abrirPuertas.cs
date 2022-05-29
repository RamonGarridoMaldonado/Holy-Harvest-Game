using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuertas : MonoBehaviour
{
    public GameObject puertaDelantera, puertaTrasera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("AbrirPuertas");
    }

    IEnumerator AbrirPuertas()
    {
        puertaDelantera.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        puertaTrasera.GetComponent<Animator>().enabled = true;
    }
}
