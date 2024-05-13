using TMPro;
using UnityEngine;

public class MainMenuTexts : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    LevelScript levelScript;
    private void Start()
    {
        levelScript = GetComponent<LevelScript>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        
    }
    private void Update()
    {
        if (SaveManager.Instance.saveData.isTurkish == true)
        {
            switch (levelScript.ScenesId)
            {
                case 1:
                    textMeshProUGUI.text = "Genel";
                    break;

                case 2:
                    textMeshProUGUI.text = "Meslekler";
                    break;
                case 3:
                    textMeshProUGUI.text = "Spor";
                    break;
                case 4:
                    textMeshProUGUI.text = "Hayvanlar";
                    break;
                case 5:
                    textMeshProUGUI.text = "Bayraklar";
                    break;
                case 6:
                    textMeshProUGUI.text = "Þehirler";
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (levelScript.ScenesId)
            {
                case 1:
                    textMeshProUGUI.text = "General";
                    break;

                case 2:
                    textMeshProUGUI.text = "Jobs";
                    break;
                case 3:
                    textMeshProUGUI.text = "Sports";
                    break;
                case 4:
                    textMeshProUGUI.text = "Animals";
                    break;
                case 5:
                    textMeshProUGUI.text = "Flags";
                    break;
                case 6:
                    textMeshProUGUI.text = "Cities";
                    break;
                default:
                    break;
            }
        }
    }
}
