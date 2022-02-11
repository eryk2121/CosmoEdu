using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa jest odpowiedzialna za baz� danych
public class DataBaseManager : Singleton<DataBaseManager>
{
    [field: SerializeField]
    private string PathData { get; set; }
    [field: SerializeField]
    private Data Data { get; set; }

    // Na starcie wczytuje baz� danych
    private void Start ()
    {
        DontDestroyOnLoad(this);
        Data.LoadData(PathData);
    }

    // Przy zamkni�ciu aplikacji zapisuj� baz� danych
    private void OnApplicationQuit()
    {
        Data.SaveData(PathData);
    }

}
