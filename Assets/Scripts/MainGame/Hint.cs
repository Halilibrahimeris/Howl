using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hint : MonoBehaviour
{
    Button button;
    public BoxLetterManager BoxLetterManager;
    public LetterManager LetterManager;
    int i = 0;
    int deActiveIndex;
    TextMeshProUGUI text;
    public Image image;
    AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        //button.onClick.AddListener(GiveHint);
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = SaveManager.Instance.saveData.HintCount.ToString();
        if (SaveManager.Instance.saveData.HintCount == 0)
        {
            image.enabled = true;
            text.gameObject.SetActive(false);
        }
        else
        {
            image.enabled = false;
            text.gameObject.SetActive(true);
        }
        Debug.Log(SaveManager.Instance.saveData.HintCount);
    }
    public void AdsHint()
    {

        Debug.Log("Ipucu Verir");
        int sayý = Random.Range(0, BoxLetterManager.harfdizisi.Length);
        Debug.Log("random Sayý" + sayý);
        if (BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree == false)
        {
            //cevabý ver
            FindRandomIndex(sayý);
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().ÝpucuGetLetter = true;
            Debug.Log("deactive index" + deActiveIndex);
            BoxLetterManager.boxletters[sayý].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[sayý].ToString();
            BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree = true;
            BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().ÝpucuBoxletter = true;

        }
        else
        {
            while (BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree != false && BoxLetterManager.harfdizisi.Length + 30 != i)
            {
                sayý = Random.Range(0, BoxLetterManager.harfdizisi.Length);
                i += 1;
            }
            FindRandomIndex(sayý);
            BoxLetterManager.boxletters[sayý].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[sayý].ToString();
            BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree = true;
            BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().ÝpucuBoxletter = true;
            Debug.Log("deactive index" + deActiveIndex);
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().ÝpucuGetLetter = true;
        }
        i = 0;
        BoxLetterManager.dogrusayac = 0;
        BoxLetterManager.CheckAnswer();
    }
    public void GiveHint()
    {
        _audio.Play();
        if (SaveManager.Instance.saveData.HintCount > 0)
        {
            Debug.Log("Ipucu Verir");
            int sayý = Random.Range(0, BoxLetterManager.harfdizisi.Length);
            Debug.Log("random Sayý" + sayý);
            if (BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree == false)
            {
                //cevabý ver
                FindRandomIndex(sayý);
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().ÝpucuGetLetter = true;
                Debug.Log("deactive index" + deActiveIndex);
                BoxLetterManager.boxletters[sayý].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[sayý].ToString();
                BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree = true;
                BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().ÝpucuBoxletter = true;

            }
            else
            {
                while (BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree != false && BoxLetterManager.harfdizisi.Length + 5 != i)
                {
                    sayý = Random.Range(0, BoxLetterManager.harfdizisi.Length);
                    i += 1;
                }
                FindRandomIndex(sayý);
                BoxLetterManager.boxletters[sayý].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[sayý].ToString();
                BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().isFree = true;
                BoxLetterManager.boxletters[sayý].GetComponent<BoxLetter>().ÝpucuBoxletter = true;
                Debug.Log("deactive index" + deActiveIndex);
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().ÝpucuGetLetter = true;
            }
            Debug.Log(SaveManager.Instance.saveData.HintCount + "\tHint sayýsý");
            SaveManager.Instance.saveData.HintCount -= 1;
            i = 0;
            BoxLetterManager.dogrusayac = 0;
            BoxLetterManager.CheckAnswer();
        }  
    }
    private void Update()
    {
        SetHintCount();
    }
    public void FindRandomIndex(int index)
    {
        for (int i = 0; i < LetterManager.rastgeleSayýlar.Length; i++)
        {
            if(index == LetterManager.rastgeleSayýlar[i])
            {
                deActiveIndex = i;
            }
        }
    }
    public void SetHintCount()
    {
        if (SaveManager.Instance.saveData.HintCount == 0)
        {
            image.enabled = true;
            text.gameObject.SetActive(false);
        }
        if (SaveManager.Instance.saveData.HintCount > 0)
        {
            image.enabled = false;
            text.gameObject.SetActive(true);
            text.text = SaveManager.Instance.saveData.HintCount.ToString();
        }
    }
}
