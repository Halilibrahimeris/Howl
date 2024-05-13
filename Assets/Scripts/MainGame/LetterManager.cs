using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterManager : MonoBehaviour
{
    public string[] letters =  {"A","B","C","Ç","D","E","F","G","Ð","H","I","Ý","J","K","L","M","N","O","Ö","P","R","S","Þ","T","U","Ü","V","Y","Z"};
    public LevelManager levelManager;
    public GameObject letter;
    public GameObject[] _gameObjectLetters = new GameObject[12];
    public int OluþacakHarfler;
    public char[] harfdizisi;
    public int[] rastgeleSayýlar;
    public int sayac = 0;
    public bool isFull = false;
    private void Start()
    {
        SpawnLetters();
    }
    void SpawnLetters()
    {
        if (SaveManager.Instance.saveData.isTurkish == true)//dil seçeneði türkçe ise
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].ulkeIsmý.ToCharArray();//Aktif leveldeki cevabý alýp bunu diziye atýyor
        }
        else
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].EU_ulke.ToCharArray();
        }
        rastgeleSayýlar = RastgeleSayilariOlustur(0, OluþacakHarfler-1);//rastgele indeksler oluþturuyor ve bunu diziye atýyor
        for (int i = 0; i < OluþacakHarfler; i++)//Input harflerini oluþturan döngü
        {
            var letters_ = Instantiate(letter);//belirlediðimiz prefabi spawnlýyor
            letters_.transform.parent = this.transform;// o prefabý bunun childi yapýyor
            letters_.transform.localScale = new Vector2(1f, 1f);//spawnlanan objenin boyutunu ayarlýyoruz
            int rastgeleSayý = rastgeleSayýlar[i];//spawnlana objenin rastgele konumu ayarlýyor
            if(rastgeleSayý >= harfdizisi.Length || harfdizisi[rastgeleSayý].ToString() == " ")//rastgele ayarlanan konum harf dizimizden büyük ise veya boþluk içeriyor ise
            {
                int sayýletter = Random.Range(0, 29);
                letters_.GetComponent<GetLetter>().LetterName = letters[sayýletter].ToString();
                letters_.GetComponent<GetLetter>().rastgele = true;
            }
            else
            {
                letters_.GetComponent<GetLetter>().LetterName = harfdizisi[rastgeleSayý].ToString();
                letters_.GetComponent<GetLetter>().rastgele = false;
            }
            _gameObjectLetters[i] = letters_;
        }
    }
    public void RenameLetters()//harfleri yeniden adlandýrýyoruz
    {
        if (SaveManager.Instance.saveData.isTurkish == true)
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].ulkeIsmý.ToCharArray();
        }
        else
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].EU_ulke.ToCharArray();
        }
        rastgeleSayýlar = RastgeleSayilariOlustur(0, 9);
        for (int i = 0; i < 10; i++)
        {
            int rastgeleSayý = rastgeleSayýlar[i];
            if (rastgeleSayý >= harfdizisi.Length || harfdizisi[rastgeleSayý].ToString() == " ")
            {
                int sayýletter = Random.Range(0, 29);
                _gameObjectLetters[i].GetComponent<GetLetter>().LetterName = letters[sayýletter].ToString();
                _gameObjectLetters[i].GetComponentInChildren<TextMeshProUGUI>().text = letters[sayýletter];
            }
            else
            {
                _gameObjectLetters[i].GetComponent<GetLetter>().LetterName = harfdizisi[rastgeleSayý].ToString();
                _gameObjectLetters[i].GetComponentInChildren<TextMeshProUGUI>().text = harfdizisi[rastgeleSayý].ToString();
            }
        }
    }
    int[] RastgeleSayilariOlustur(int min, int max)//rastgele sayý oluþturma fonksiyonu
    {
        if (max - min + 1 < max)
        {
            throw new System.InvalidOperationException("Üretilecek sayý adedi maksimum deðere eþit veya daha büyük olmalýdýr.");
        }

        int[] sayilar = new int[max - min + 1];
        for (int i = 0; i < sayilar.Length; i++)
        {
            sayilar[i] = i + min;
        }

        for (int i = 0; i < sayilar.Length; i++)
        {
            int k = Random.Range(i, sayilar.Length);
            int temp = sayilar[i];
            sayilar[i] = sayilar[k];
            sayilar[k] = temp;
        }

        return sayilar;
    }

}
