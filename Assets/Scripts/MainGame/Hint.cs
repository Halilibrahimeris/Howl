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
        int say� = Random.Range(0, BoxLetterManager.harfdizisi.Length);
        Debug.Log("random Say�" + say�);
        if (BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree == false)
        {
            //cevab� ver
            FindRandomIndex(say�);
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().�pucuGetLetter = true;
            Debug.Log("deactive index" + deActiveIndex);
            BoxLetterManager.boxletters[say�].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[say�].ToString();
            BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree = true;
            BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().�pucuBoxletter = true;

        }
        else
        {
            while (BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree != false && BoxLetterManager.harfdizisi.Length + 30 != i)
            {
                say� = Random.Range(0, BoxLetterManager.harfdizisi.Length);
                i += 1;
            }
            FindRandomIndex(say�);
            BoxLetterManager.boxletters[say�].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[say�].ToString();
            BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree = true;
            BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().�pucuBoxletter = true;
            Debug.Log("deactive index" + deActiveIndex);
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
            LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().�pucuGetLetter = true;
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
            int say� = Random.Range(0, BoxLetterManager.harfdizisi.Length);
            Debug.Log("random Say�" + say�);
            if (BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree == false)
            {
                //cevab� ver
                FindRandomIndex(say�);
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().�pucuGetLetter = true;
                Debug.Log("deactive index" + deActiveIndex);
                BoxLetterManager.boxletters[say�].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[say�].ToString();
                BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree = true;
                BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().�pucuBoxletter = true;

            }
            else
            {
                while (BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree != false && BoxLetterManager.harfdizisi.Length + 5 != i)
                {
                    say� = Random.Range(0, BoxLetterManager.harfdizisi.Length);
                    i += 1;
                }
                FindRandomIndex(say�);
                BoxLetterManager.boxletters[say�].GetComponentInChildren<TextMeshProUGUI>().text = BoxLetterManager.harfdizisi[say�].ToString();
                BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().isFree = true;
                BoxLetterManager.boxletters[say�].GetComponent<BoxLetter>().�pucuBoxletter = true;
                Debug.Log("deactive index" + deActiveIndex);
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<Button>().interactable = false;
                LetterManager._gameObjectLetters[deActiveIndex].GetComponent<GetLetter>().�pucuGetLetter = true;
            }
            Debug.Log(SaveManager.Instance.saveData.HintCount + "\tHint say�s�");
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
        for (int i = 0; i < LetterManager.rastgeleSay�lar.Length; i++)
        {
            if(index == LetterManager.rastgeleSay�lar[i])
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
