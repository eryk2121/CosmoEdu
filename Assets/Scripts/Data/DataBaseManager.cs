using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa jest odpowiedzialna za bazê danych
public class DataBaseManager : Singleton<DataBaseManager>
{
    [field: SerializeField]
    private string PathData { get; set; }
    [field: SerializeField]
    private Data Data { get; set; }

    // Na starcie wczytuje bazê danych
    private void Start ()
    {
        DontDestroyOnLoad(this);
        Data.LoadData(PathData);
    }

    // Przy zamkniêciu aplikacji zapisujê bazê danych
    private void OnApplicationQuit()
    {
        Data.SaveData(PathData);
    }

}
