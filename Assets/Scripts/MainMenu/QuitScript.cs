using UnityEngine.UI;
using UnityEngine;
using System;

public class QuitScript : MonoBehaviour
{
    Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
