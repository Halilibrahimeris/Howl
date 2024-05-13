using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetLetter : MonoBehaviour
{
    public string LetterName;
    public Button button;
    public TextMeshProUGUI text;
    public BoxLetterManager boxLetterManager;
    public LetterManager letterManager;
    public AudioSource Audio;
    public bool rastgele;
    public bool ÝpucuGetLetter;
    int index;
    bool free;
    private void Start()
    {
        free = true;
        LetterManager manager = GetComponentInParent<LetterManager>();
        Level parent = manager.GetComponentInParent<Level>();
        boxLetterManager = parent.GetComponentInChildren<BoxLetterManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(_GetLetter);
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text = LetterName;
        letterManager = GetComponentInParent<LetterManager>();
    }

    void _GetLetter()
    {
        if(Audio.isPlaying == false)
        {
            Audio.Play();
            FindFirstFreeBox();
            if (free)
            {
                CheckthisLetterisTrue(index);
                boxLetterManager.boxletters[index].GetComponent<BoxLetter>().isFree = true;
                boxLetterManager.boxletters[index].GetComponentInChildren<TextMeshProUGUI>().text = text.text;
            }
            boxLetterManager.dogrusayac = 0;
            boxLetterManager.CheckAnswer();
            letterManager.sayac += 1;
            if (letterManager.sayac == GetComponentInParent<LetterManager>().harfdizisi.Length)
            {
                letterManager.sayac = 0;
            }

            isEveryBoxFull();
            if (letterManager.isFull)
            {
                if (CheckLettersinEnd())
                {
                    PlayWrongAnim();
                    var Input = letterManager.gameObject;
                    Input.GetComponent<AudioSource>().Play();
                }
            }
        }

    }

    public int FindFirstFreeBox()
    {
        for (int i = 0; i < boxLetterManager.harfdizisi.Length; i++)
        {
            if(boxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree == true)
            {
                free = false;
                Debug.Log(i + "Bu indexde harf var");
            }
            else if(boxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree == false)
            {
                index = i;
                Debug.Log(index);
                button.interactable = false;
                free = true;
                return index;
            }
        }
        boxLetterManager.dogrusayac = 0;
        boxLetterManager.CheckAnswer();
        return 25;
    }
    public bool isEveryBoxFull()
    {
        for (int i = 0; i < boxLetterManager.harfdizisi.Length; i++)
        {
            if(boxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree == true)
            {
                letterManager.isFull = true;
            }
            else
            {
                letterManager.isFull = false;
                return false;
            }
        }
        return true;
    }
    public void ClearAllBox()
    {
        for (int i = 0; i < boxLetterManager.harfdizisi.Length; i++)
        {
            boxLetterManager.boxletters[i].GetComponent<BoxLetter>().isFree = false;
            boxLetterManager.boxletters[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        for (int i = 0; i < letterManager._gameObjectLetters.Length; i++)
        {
            letterManager._gameObjectLetters[i].GetComponent<Button>().interactable = true;
        }
    }
    public void PlayWrongAnim()
    {
        for (int i = 0; i < boxLetterManager.harfdizisi.Length; i++)
        {
            boxLetterManager.boxletters[i].GetComponent<Animator>().SetTrigger("Wrong");
        }
    }
    public void CheckthisLetterisTrue(int index)
    {
        if(LetterName == boxLetterManager.harfdizisi[index].ToString())
        {
            Debug.Log("Bu harf dogru");
        }
        else
        {
            Debug.Log("Bu harf yanlis" + " Index : "+ index);
            boxLetterManager.boxletters[index].GetComponent<BoxLetter>().Wrong = true;
        }
    }
    public bool CheckLettersinEnd()
    {
        for (int i = 0; i < boxLetterManager.harfdizisi.Length; i++)
        {
            if(boxLetterManager.boxletters[i].GetComponent<BoxLetter>().Wrong == true)
            {
                return true;
            }
        }
        return false;
    }


}
