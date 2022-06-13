using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public GameObject pantallaCarga,imagenBarco1,imagenBarco2,imagenBarco3,bote;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine("pantallaCargaDormir");
        image = pantallaCarga.gameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator pantallaCargaDormir()
    {
        pantallaCarga.SetActive(true);
        yield return new WaitForSeconds(1f);
        imagenBarco1.SetActive(true);
        yield return new WaitForSeconds(1f);
        imagenBarco2.SetActive(true);
        yield return new WaitForSeconds(1f);
        imagenBarco3.SetActive(true);
        yield return new WaitForSeconds(2f);
        imagenBarco1.SetActive(false);
        imagenBarco2.SetActive(false);
        imagenBarco3.SetActive(false);
        Color color = image.color;
        color.a = 0;
        pantallaCarga.SetActive(false);
        bote.SetActive(true);
        yield return new WaitForSeconds(4f);
        if (SceneManager.GetActiveScene().name.Equals("TransicionGranjaPueblo"))
        {
            SceneManager.LoadScene("Pueblo");
        }
        else if (SceneManager.GetActiveScene().name.Equals("TransicionPuebloGranja"))
        {
            SceneManager.LoadScene("Granja 2");
        }
    }
}
