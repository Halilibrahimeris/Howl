using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SetActiveLevel
{
    public string LevelName;
    public int ActiveLevel;
    public int LevelId;
    public bool SetLevel;
}

public class ResetSave : MonoBehaviour
{
    public List<SetActiveLevel> leveller;
    public bool SetLevel;
    public int HintCount;
    public bool SetHintCount;
    private void Update()
    {
        if (SetHintCount)
        {
            SaveManager.Instance.saveData.HintCount = HintCount;
            SetHintCount = false;
        }
        if (SetLevel)
        {
            foreach (var item in leveller)
            {
                switch (item.LevelId)
                {
                    case 1:
                        if (item.SetLevel)
                        {
                            SaveManager.Instance.saveData.GenelLevel = item.ActiveLevel;
                        }
                        break;
                    case 2:
                        if (item.SetLevel)
                        {
                            SaveManager.Instance.saveData.BayraklarLevel = item.ActiveLevel;
                        }
                        break;
                    case 3:
                        if (item.SetLevel)
                        {
                            SaveManager.Instance.saveData.BayraklarLevel = item.ActiveLevel;
                        }
                        break;
                    case 4:
                        if (item.SetLevel)
                        {
                            //hayvn
                            SaveManager.Instance.saveData.HayvanlarLevel = item.ActiveLevel;
                        }
                        break;
                    case 5:
                        if (item.SetLevel)
                        {
                            //spor
                            SaveManager.Instance.saveData.SporLevel = item.ActiveLevel;
                        }
                        break;
                    case 6:
                        if (item.SetLevel)
                        {
                            //sehir
                            SaveManager.Instance.saveData.SehirlerLevel = item.ActiveLevel;
                        }
                        break;
                    default:
                        break;
                }
                SetLevel = false;
            }
        }
    }
    public void ChangeLanguageTR()
    {
        SaveManager.Instance.saveData.isTurkish = true;
    }
    public void ChangeLanguageEU()
    {
        SaveManager.Instance.saveData.isTurkish = false;
    }
    public void ResetSave_()
    {
        SaveManager.Instance.saveData.GenelLevel = 0;
        SaveManager.Instance.saveData.BayraklarLevel = 0;
        SaveManager.Instance.saveData.HayvanlarLevel = 0;
        SaveManager.Instance.saveData.MeslekerLevel = 0;
        SaveManager.Instance.saveData.SehirlerLevel = 0;
        SaveManager.Instance.saveData.SporLevel = 0;
    }

}
