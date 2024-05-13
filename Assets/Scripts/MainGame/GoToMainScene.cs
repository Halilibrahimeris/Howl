using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GoToMainScene : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(MainScene);
    }
    void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}
