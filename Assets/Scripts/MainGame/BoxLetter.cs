using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLetter : MonoBehaviour
{
    public int index;
    public bool isFree;
    public bool Wrong = false;
    public bool ÝpucuBoxletter;
    public BoxLetterManager manager;

    private void Start()
    {
        manager = gameObject.GetComponentInParent<BoxLetterManager>();
    }
    private void Update()
    {
        if (isFree == false)
        {
            this.gameObject.GetComponent<Image>().sprite = manager.letterSprite[0];
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = manager.letterSprite[1];
        }
    }
}
