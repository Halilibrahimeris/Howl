using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class istenilenSpritelar
{
    public Sprite[] sprite = new Sprite[3];
    public string ulkeIsmý;
    public string EU_ulke;
    public float[] CellSize = new float[2];
    public float[] EU_CellSize = new float[2];
}
public class LevelManager : MonoBehaviour
{
    public int ActiveLevel;
    public List<istenilenSpritelar> Spriteler;

    private void Awake()
    {
        SetActiveLevel();
    }

    public void SetActiveLevel()
    {
        int AcitiveSceneId = SceneManager.GetActiveScene().buildIndex;
        switch (AcitiveSceneId)
        {
            case 1:
                ActiveLevel = SaveManager.Instance.saveData.GenelLevel;
                break;
            case 2:
                Debug.Log("Meslekler Level Güncellenmemiþ" + SaveManager.Instance.saveData.MeslekerLevel);
                ActiveLevel = SaveManager.Instance.saveData.MeslekerLevel;
                break;
            case 3:
                ActiveLevel = SaveManager.Instance.saveData.SporLevel;
                break;
            case 4:
                ActiveLevel = SaveManager.Instance.saveData.HayvanlarLevel;
                break;
            case 5:
                ActiveLevel = SaveManager.Instance.saveData.BayraklarLevel;
                break;
            default:
                break;
        }
    }
}
