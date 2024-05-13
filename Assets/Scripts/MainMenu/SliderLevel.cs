using UnityEngine.UI;
using UnityEngine;

public class SliderLevel : MonoBehaviour
{
    Slider slider;
    LevelScript LevelScript;
    private void Start()
    {
        ChangeSlider();
    }
    private void Update()
    {
        ChangeSlider();
    }
    public void ChangeSlider()
    {
        LevelScript = GetComponentInParent<LevelScript>();
        slider = GetComponent<Slider>();
        switch (LevelScript.ScenesId)
        {
            case 1:
                slider.value = SaveManager.Instance.saveData.GenelLevel;
                break;
            case 2:
                slider.value = SaveManager.Instance.saveData.MeslekerLevel;
                break;
            case 3:
                slider.value = SaveManager.Instance.saveData.SporLevel;
                break;
            case 4:
                slider.value = SaveManager.Instance.saveData.HayvanlarLevel;
                break;
            case 5:
                slider.value = SaveManager.Instance.saveData.BayraklarLevel;
                break;
            case 6:
                slider.value = SaveManager.Instance.saveData.SehirlerLevel;
                break;
            default:
                break;
        }
    }
}
