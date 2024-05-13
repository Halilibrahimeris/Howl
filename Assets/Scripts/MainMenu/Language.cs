using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    private void Start()
    {
        if (SaveManager.Instance.saveData.oneTime == true)
        {
            gameObject.SetActive(true);
            SaveManager.Instance.saveData.oneTime = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
