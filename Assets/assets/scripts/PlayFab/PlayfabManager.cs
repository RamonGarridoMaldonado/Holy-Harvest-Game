using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        CargarDatosJugador();
        //Debug.Log("Se ha realizado el Login correctamente / Cuenta creada");
    }

    void OnError (PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
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

    void TablaActualizada(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Mandado al LeaderBoard correctamente");
    }

    public void obtenerTablaLideres()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "MoneyScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnleaderboardGet, OnError);
    }

    void OnleaderboardGet (GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void CargarDatosJugador()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), datosRecividos, OnError);
    }

    void datosRecividos (GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("Dinero") && result.Data.ContainsKey("Estamina"))
        {
            GameManager.establecerDinero(int.Parse(result.Data["Dinero"].Value));
            GameManager.establecerEstamina(float.Parse(result.Data["Estamina"].Value));

            if (SceneManager.GetActiveScene().name.Equals("Pueblo"))
            {
                if (result.Data["balon"].Value == "True")
                {
                    GameManager.setBalonComprado();
                }

                if (result.Data["planta"].Value == "True")
                {
                    GameManager.setPlantaComprado();
                }

                if (result.Data["estanteriaLibros"].Value == "True")
                {
                    GameManager.setEstanteriaLibros();
                }

                if (result.Data["lavador"].Value == "True")
                {
                    GameManager.setLavador();
                }

                if (result.Data["librosAbajo"].Value == "True")
                {
                    GameManager.setLibrosAbajo();
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
            }
        } 
        else
        {
            Debug.Log("Los datos del jugador no son correctos o no son suficientes");
        }
    }

    public void GuardarDatosJugador(string guardarEstamina, string guardarDinero, string balon, string planta, string estanterialibros, string lavador, string librosAbajo)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> {
                {"Estamina", guardarEstamina },
                {"Dinero", guardarDinero },
                {"balon", balon},
                {"planta", planta },
                {"estanteriaLibros", estanterialibros },
                {"lavador",lavador },
                {"librosAbajo",librosAbajo },
                
            }
        };
        PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
    }

    public void GuardarDatosJugadorPueblo (string balon, string planta, string estanterialibros, string lavador, string librosAbajo)
    {
        var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> {
                    {"balon", balon},
                    {"planta",planta},
                    {"estanteriaLibros",estanterialibros },
                    {"lavador",lavador },
                    {"librosAbajo", librosAbajo},
                }
        };
        PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
    }

    void datosEnviados(UpdateUserDataResult result)
    {
        Debug.Log("Datos enviados correctamente"); 
    }
}
