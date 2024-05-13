using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    Button button;
    public int ScenesId; 
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OpenLevel);
    }
    void OpenLevel()
    {
        GameManager.instance.LevelId = ScenesId;
        SceneManager.LoadScene(ScenesId);
    }
}
