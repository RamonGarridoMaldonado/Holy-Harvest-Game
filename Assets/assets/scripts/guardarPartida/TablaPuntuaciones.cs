using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TablaPuntuaciones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void verTablaPuntuaciones()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.obtenerTablaLideres();
    }

    public void volver()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
