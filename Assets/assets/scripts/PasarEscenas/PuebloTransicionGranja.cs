using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloTransicionGranja : MonoBehaviour
{
    private bool puede;
    public GameObject HUDnpcBote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && puede)
        {
            SceneManager.LoadScene("TransicionGranjaPueblo");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        puede = true;
        HUDnpcBote.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        puede = false;
        HUDnpcBote.SetActive(false);

    }
}
