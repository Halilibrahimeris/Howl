using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUrl : MonoBehaviour
{
    Button button;
    public string A��lacakURL;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(URL);
    }
    public void URL()
    {
        Application.OpenURL(A��lacakURL);
    }
}
