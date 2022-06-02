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
        Debug.Log("Se ha realizado el Login correctamente / Cuenta creada");
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

    public void GuardarDatosJugador(string guardarEstamina, string guardarDinero)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> {
                {"Estamina", guardarEstamina },
                {"Dinero", guardarDinero },
            }
        };
        PlayFabClientAPI.UpdateUserData(request, datosEnviados, OnError);
    }

    void datosEnviados(UpdateUserDataResult result)
    {
        Debug.Log("Datos enviados correctamente"); 
    }
}
