using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance;

    public void Awake()
    {
        instance = this;
    }
}
