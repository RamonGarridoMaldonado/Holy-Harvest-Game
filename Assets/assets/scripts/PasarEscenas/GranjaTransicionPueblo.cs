using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GranjaTransicionPueblo : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E) && puede) {
            PlayfabManager pfb = new PlayfabManager();
            pfb.EnviarDineroATabla();
            pfb.GuardarDatosJugador(GameManager.obtenerEstamina().ToString(), GameManager.getDinero().ToString(), GameManager.getBalonComprado(), GameManager.getPlantaComprado(), GameManager.getEstanteriaLibros(), GameManager.getLavador(), GameManager.getLibrosAbajo(), GameManager.getPlantacionComprada().ToString());
            pfb.guardarInventario();
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
