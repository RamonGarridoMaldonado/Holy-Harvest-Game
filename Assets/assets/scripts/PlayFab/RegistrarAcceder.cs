using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegistrarAcceder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registrarAcceder()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.BotonRegistrar();
    }

    public void Login()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.botonAcceder();
    }

    public void recuperarPass()
    {
        PlayfabManager pfb = new PlayfabManager();
        pfb.botonRecuperarPass();
    }

    public void exit()
    {
        Application.Quit();
    }
}
