using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels; 

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
            if (result.Data["Logro1"].Value == "True")
            {
                GameManager.setLogro1Completado();
            }
            if (result.Data["Logro2"].Value == "True")
            {
                GameManager.setLogro2Completado();
            }
            if (result.Data["Logro3"].Value == "True")
            {
                GameManager.setLogro3Completado();
            }
            if (result.Data["Logro4"].Value == "True")
            {
                GameManager.setLogro4Completado();
            }
        } else
        {
            Debug.Log("Los datos del jugador no son correctos o no son suficientes");
        }
    }

    public void GuardarDatosJugador(string guardarEstamina, string guardarDinero, string logro1, string logro2, string logro3, string logro4, string balon)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> {
                {"Estamina", guardarEstamina },
                {"Dinero", guardarDinero },
                {"Logro1", logro1},
                {"Logro2", logro2},
                {"Logro3", logro3},
                {"Logro4", logro4},
                {"balon", balon}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
    }

    void datosEnviados(UpdateUserDataResult result)
    {
        Debug.Log("Datos enviados correctamente"); 
    }
}
