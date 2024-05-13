using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RestartButton : MonoBehaviour
{
    Button button;
    public BoxLetterManager BoxLetterManager;
    public LetterManager LetterManager;
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(RestartLetters);
    }
    public void RestartLetters()
    {

        for (int i = 0; i < BoxLetterManager.harfdizisi.Length; i++)
        {
            if(BoxLetterManager.boxletters[i].GetComponent<BoxLetter>().ÝpucuBoxletter == true)
            {

            }
            else
            {
                BoxLetterManager.boxletters[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                BoxLetterManager.boxletters[i].GetComponent<Image>().sprite = BoxLetterManager.letterSprite[0];
                BoxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree = false;
                BoxLetterManager.boxletters[i].GetComponent<BoxLetter>().Wrong = false;
                LetterManager.isFull = false;
            }
            if(BoxLetterManager.harfdizisi[i].ToString() == " ")
            {
                BoxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree = true;
            }
        }
        for (int i = 0; i < LetterManager._gameObjectLetters.Length; i++)
        {
            if (LetterManager._gameObjectLetters[i].GetComponent<GetLetter>().ÝpucuGetLetter == true)
            {

            }
            if(LetterManager._gameObjectLetters[i].GetComponent<GetLetter>().ÝpucuGetLetter == false)
            {
                LetterManager._gameObjectLetters[i].GetComponent<Button>().interactable = true;
            }
            
        }
        LetterManager.sayac = 0;
        LetterManager.isFull = false;
    }
    
}
