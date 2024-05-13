using TMPro;
using UnityEngine;

public class EndGameText : MonoBehaviour
{
    TextMeshProUGUI text;
    public LevelManager LevelManager;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(LevelManager.ActiveLevel != LevelManager.Spriteler.Count)
        {
            if (SaveManager.Instance.saveData.isTurkish)
            {
                text.text = LevelManager.Spriteler[LevelManager.ActiveLevel].ulkeIsmý;
            }
            else
            {
                text.text = LevelManager.Spriteler[LevelManager.ActiveLevel].EU_ulke;
            }
        }
        
    }
}
