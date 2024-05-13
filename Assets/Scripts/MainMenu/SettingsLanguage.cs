using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsLanguage : MonoBehaviour
{
    public List<GameObject> Objeler;
    public List<string> türkçeleri;
    public List<string> ingilizceleri;

    public TextMeshProUGUI AnaMetinText;
    public TextMeshProUGUI OnaylamaText;
    private void Start()
    {
        setLanguage();
    }
    public void setLanguage()
    {
        if (SaveManager.Instance.saveData.isTurkish)
        {
            for (int i = 0; i < Objeler.Count; i++)
            {
                Objeler[i].GetComponentInChildren<TextMeshProUGUI>().text = türkçeleri[i];
            }
            AnaMetinText.text = "Tüm kayýtlarýnýz silinecek ve ilerlemeniz sýfýrlanacaktýr. \nKabul ediyor musunuz ? ";
            OnaylamaText.text = "EVET";
        }
        else
        {
            for (int i = 0; i < Objeler.Count; i++)
            {
                Objeler[i].GetComponentInChildren<TextMeshProUGUI>().text = ingilizceleri[i];
            }
            AnaMetinText.text = "All your records will be deleted and your progress will be reset.  \nDo you agree?";
            OnaylamaText.text = "YES";
        }
    }
}
