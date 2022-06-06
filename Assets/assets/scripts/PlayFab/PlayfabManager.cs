using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balon, planta, estanteriaLibros, lavador, librosAbajo;
    static string email, pass, usuario;

    public void BotonRegistrar()
    {
        InputField emailInput = GameObject.Find("HUD/InputEmail").GetComponent<InputField>();
        InputField passInput = GameObject.Find("HUD/InputPassword").GetComponent<InputField>();
        InputField NombreUsuarioInput = GameObject.Find("HUD/InputNombreUsuario").GetComponent<InputField>();

        if (passInput.text.Length < 6)
        {
            Text textoInformacion = GameObject.Find("HUD/TextoInformacion").GetComponent<Text>();
            textoInformacion.text = "La contraseña debe tener mas de 6 digitos";
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passInput.text,
            DisplayName = NombreUsuarioInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, OnError);
    }

    void OnRegisterSucces (RegisterPlayFabUserResult result)
    {
        Debug.Log("Registrado y logeado");
        SceneManager.LoadScene("MenuInicial");
    }

    public void botonAcceder()
    {
            InputField emailInput = GameObject.Find("HUD/InputEmail").GetComponent<InputField>();
            InputField NombreUsuarioInput = GameObject.Find("HUD/InputPassword").GetComponent<InputField>();
            InputField passInput = GameObject.Find("HUD/InputPassword").GetComponent<InputField>();
            email = emailInput.text;
            pass = passInput.text;
            var request = new LoginWithEmailAddressRequest
            {
                Email = emailInput.text,
                Password = passInput.text,
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, LoginOnSucces, OnError);
    }

    public void botonRecuperarPass()
    {
        InputField emailInput = GameObject.Find("HUD/InputEmail").GetComponent<InputField>();
        InputField passInput = GameObject.Find("HUD/InputPassword").GetComponent<InputField>();

        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "5B837"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        Text textoInformacion = GameObject.Find("HUD/TextoInformacion").GetComponent<Text>();
        textoInformacion.text = "Revisa tu correo, te hemos enviado un mensaje para recuperar su contraseña";
    }
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = pass
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    void LoginOnSucces (LoginResult result)
    {
        SceneManager.LoadScene("MenuInicial");
    }

    void OnSuccess(LoginResult result)
    {
        CargarDatosJugador();
        Debug.Log("Se ha realizado el Login correctamente / Cuenta creada");
    }

    void OnError (PlayFabError error)
    {
        Debug.Log(error);
        if (SceneManager.GetActiveScene().name.Equals("RegistrarLogear"))
        {
            if (error.ToString().Contains("User not found"))
            {
                Text textoInformacion = GameObject.Find("HUD/TextoInformacion").GetComponent<Text>();
                textoInformacion.text = "Usuario/Contraseña incorrecto";
            }

            if (error.ToString().Contains("Email address is not valid"))
            {
                Text textoInformacion = GameObject.Find("HUD/TextoInformacion").GetComponent<Text>();
                textoInformacion.text = "Introduce un correo valido";
            }

            if (error.ToString().Contains("Email address already exists"))
            {
                Text textoInformacion = GameObject.Find("HUD/TextoInformacion").GetComponent<Text>();
                textoInformacion.text = "Usuario existente";
            }
        }
    }

    public void EnviarDineroATabla()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "MoneyScore", 
                    Value = GameManager.getDinero()
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, TablaActualizada, OnError);
    }

    public void TablaActualizada(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Mandado al LeaderBoard correctamente");
    }

    public void obtenerTablaLideres()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "MoneyScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }

    public void OnleaderboardGet (GetLeaderboardResult result)
    {
        Text textoPuntuacion = GameObject.Find("HUDClasificacion/TextoPuntuaciones").GetComponent<Text>();
        textoPuntuacion.text = "";

            foreach (var item in result.Leaderboard)
            {
                if (SceneManager.GetActiveScene().name.Equals("VerPuntuacion"))
                {
                    textoPuntuacion.text = textoPuntuacion.text + (item.Position + 1) + "               " + item.DisplayName + "               " + item.StatValue + "\n";
                }
                Debug.Log(item.Position + 1 + " " + item.PlayFabId + " " + item.StatValue + "\n");
            }
    }

    public void CargarDatosJugador()
    {
        if (!SceneManager.GetActiveScene().name.Equals("VerPuntuacion") || !SceneManager.GetActiveScene().name.Equals("MenuInicial"))
        {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), datosRecividos, OnError);
        }
    }


    public void datosRecividos (GetUserDataResult result)
    {
        if (!SceneManager.GetActiveScene().name.Equals("VerPuntuacion") || !SceneManager.GetActiveScene().name.Equals("MenuInicial"))
        {
            if (result.Data != null && result.Data.ContainsKey("Dinero") && result.Data.ContainsKey("Estamina"))
            {
                GameManager.establecerDinero(int.Parse(result.Data["Dinero"].Value));
                GameManager.establecerEstamina(float.Parse(result.Data["Estamina"].Value));

                if (SceneManager.GetActiveScene().name.Equals("Pueblo"))
                {
                    if (result.Data["balon"].Value == "True")
                    {
                        GameObject imagenBalonVendido = balon.transform.Find("imagenVendido").gameObject;
                        imagenBalonVendido.SetActive(true);
                        GameManager.setBalonComprado();
                    }
                    else
                    {
                        GameObject imagenBalonVendido = balon.transform.Find("imagenVendido").gameObject;
                        imagenBalonVendido.SetActive(false);
                    }

                    if (result.Data["planta"].Value == "True")
                    {
                        GameObject imagenPlantavendida = planta.transform.Find("imagenVendido").gameObject;
                        imagenPlantavendida.SetActive(true);
                        GameManager.setPlantaComprado();
                    }
                    else
                    {
                        GameObject imagenPlantavendida = planta.transform.Find("imagenVendido").gameObject;
                        imagenPlantavendida.SetActive(false);
                    }

                    if (result.Data["estanteriaLibros"].Value == "True")
                    {
                        GameObject imagenEstanteriaLibrosVendido = estanteriaLibros.transform.Find("imagenVendido").gameObject;
                        imagenEstanteriaLibrosVendido.SetActive(true);
                        GameManager.setEstanteriaLibros();
                    }
                    else
                    {
                        GameObject imagenEstanteriaLibrosVendido = estanteriaLibros.transform.Find("imagenVendido").gameObject;
                        imagenEstanteriaLibrosVendido.SetActive(false);
                    }

                    if (result.Data["lavador"].Value == "True")
                    {
                        GameObject imagenLavadorVendido = lavador.transform.Find("imagenVendido").gameObject;
                        imagenLavadorVendido.SetActive(true);
                        GameManager.setLavador();
                    }
                    else
                    {
                        GameObject imagenLavadorVendido = lavador.transform.Find("imagenVendido").gameObject;
                        imagenLavadorVendido.SetActive(false);
                    }

                    if (result.Data["librosAbajo"].Value == "True")
                    {
                        GameObject imagenLibrosabajoVendido = librosAbajo.transform.Find("imagenVendido").gameObject;
                        imagenLibrosabajoVendido.SetActive(true);
                        GameManager.setLibrosAbajo();
                    }
                    else
                    {
                        GameObject imagenLavadorVendido = librosAbajo.transform.Find("imagenVendido").gameObject;
                        imagenLavadorVendido.SetActive(false);
                    }
                }


                else if (SceneManager.GetActiveScene().name.Equals("Granja 2"))
                {
                    if (result.Data["balon"].Value == "True")
                    {
                        Camera.main.GetComponent<MueblesComprados>().balonComprado();
                    }

                    if (result.Data["planta"].Value == "True")
                    {
                        Camera.main.GetComponent<MueblesComprados>().plantaComprada();
                    }

                    if (result.Data["estanteriaLibros"].Value == "True")
                    {
                        Camera.main.GetComponent<MueblesComprados>().estanteriaLibrosComprado();
                    }

                    if (result.Data["lavador"].Value == "True")
                    {
                        Camera.main.GetComponent<MueblesComprados>().lavadorComprado();
                    }

                    if (result.Data["librosAbajo"].Value == "True")
                    {
                        Camera.main.GetComponent<MueblesComprados>().librosAbajoComprado();
                    }

                    int cantidad = int.Parse(result.Data["cantidadMuebles"].Value);
                    if (cantidad >= 1)
                    {
                        GameManager.activarLogro1();
                    }

                    if (cantidad >= 3)
                    {
                        GameManager.activarLogro2();
                    }

                    if (cantidad >= 5)
                    {
                        GameManager.activarLogro3();
                    }

                    if (result.Data["ZonaComprada"].Value == "True")
                    {
                        GameManager.setPlantacionComprada();
                    }
                }
            }
            else
            {
                Debug.Log("Los datos del jugador no son correctos o no son suficientes");
            }
        }
    }

    public void GuardarDatosJugador(string guardarEstamina, string guardarDinero, string balon, string planta, string estanterialibros, string lavador, string librosAbajo, string zonaComprada)
    {
        if (!SceneManager.GetActiveScene().name.Equals("VerPuntuacion") || !SceneManager.GetActiveScene().name.Equals("MenuInicial"))
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> {
                {"Estamina", guardarEstamina },
                {"Dinero", guardarDinero },
                {"ZonaComprada", zonaComprada}
            }
            };
            PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
        }
    }

    public void GuardarDatosJugadorPueblo (string guardarEstamina, string guardarDinero, string balon, string planta, string estanterialibros, string lavador, string librosAbajo)
    {
        if (!SceneManager.GetActiveScene().name.Equals("VerPuntuacion") || !SceneManager.GetActiveScene().name.Equals("MenuInicial"))
        {
            int cantidadMuebles = 0;
            if (balon.Equals("True")) cantidadMuebles++;
            if (planta.Equals("True")) cantidadMuebles++;
            if (estanterialibros.Equals("True")) cantidadMuebles++;
            if (lavador.Equals("True")) cantidadMuebles++;
            if (librosAbajo.Equals("True")) cantidadMuebles++;

            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> {
                    {"Estamina", guardarEstamina },
                    {"Dinero", guardarDinero },
                    {"balon", balon},
                    {"planta",planta},
                    {"estanteriaLibros",estanterialibros },
                    {"lavador",lavador },
                    {"librosAbajo", librosAbajo},
                    {"cantidadMuebles", cantidadMuebles.ToString() }
                }
            };
            PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
        }
    }

    void datosEnviados(UpdateUserDataResult result)
    {
        Debug.Log("Datos enviados correctamente"); 
    }
}
