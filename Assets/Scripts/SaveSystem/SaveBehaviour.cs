using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveBehaviour
{
    public static void SaveData<T>(string key, T saveData)
    {
        string gameDataJson = DataBehaviour.Serialize<T>(saveData);
        PlayerPrefs.SetString(key, gameDataJson);
    }
    
    public static T LoadData<T>(string key)
    {
        string gameDataJson = PlayerPrefs.GetString(key);
        return DataBehaviour.DeSerialize<T>(gameDataJson);
    }
}
