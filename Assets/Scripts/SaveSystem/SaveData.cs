using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SaveData")]
public class SaveData : ScriptableObject
{
    public int HintCount;
    public int GenelLevel;
    public int MeslekerLevel;
    public int SporLevel;
    public int HayvanlarLevel;
    public int BayraklarLevel;
    public int SehirlerLevel;

    public bool isTurkish;
    public bool GoAds;
    public bool oneTime = true;
    public SaveData()
    {
        oneTime = true;
        isTurkish = true;
        HintCount = 0;
        GenelLevel = 0;
        MeslekerLevel = 0;
        SporLevel = 0;
        HayvanlarLevel = 0;
        BayraklarLevel = 0;
        SehirlerLevel = 0;

    }
}
