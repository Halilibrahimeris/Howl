using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveManager : DontDestroySingleton<SaveManager>
{
    public SaveData saveData;
    private const string USER_DATA_KEY = "user_data";


    private float timer = 5;
    private float maxTime = 1;

    public override void Awake()
    {
        base.Awake();
        if (!LoadPlayerData())
        {
            // SaveDatadaki deðerlerin defult halini ata
            saveData.oneTime = true;
            saveData.GoAds = false;
            saveData.isTurkish = false;
            saveData.GenelLevel = 0;
            saveData.MeslekerLevel = 0;
            saveData.SporLevel = 0;
            saveData.HayvanlarLevel = 0;
            saveData.BayraklarLevel = 0;
            saveData.SehirlerLevel = 0;
            saveData.HintCount = 10;
        }

    }
    
    

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SavePlayerData();
            timer = maxTime;
        }
    }

    public bool LoadPlayerData()
    {
        if (PlayerPrefs.HasKey(USER_DATA_KEY))
        {
            saveData =  SaveBehaviour.LoadData<SaveData>(USER_DATA_KEY);
            
            return true;
        }
        else
        {
            return false;
        }

    }

    public void SavePlayerData()
    {
        SaveBehaviour.SaveData(USER_DATA_KEY, saveData);
    }


}
