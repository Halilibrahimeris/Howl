using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterManager : MonoBehaviour
{
    public string[] letters =  {"A","B","C","�","D","E","F","G","�","H","I","�","J","K","L","M","N","O","�","P","R","S","�","T","U","�","V","Y","Z"};
    public LevelManager levelManager;
    public GameObject letter;
    public GameObject[] _gameObjectLetters = new GameObject[12];
    public int Olu�acakHarfler;
    public char[] harfdizisi;
    public int[] rastgeleSay�lar;
    public int sayac = 0;
    public bool isFull = false;
    private void Start()
    {
        SpawnLetters();
    }
    void SpawnLetters()
    {
        if (SaveManager.Instance.saveData.isTurkish == true)//dil se�ene�i t�rk�e ise
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].ulkeIsm�.ToCharArray();//Aktif leveldeki cevab� al�p bunu diziye at�yor
        }
        else
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].EU_ulke.ToCharArray();
        }
        rastgeleSay�lar = RastgeleSayilariOlustur(0, Olu�acakHarfler-1);//rastgele indeksler olu�turuyor ve bunu diziye at�yor
        for (int i = 0; i < Olu�acakHarfler; i++)//Input harflerini olu�turan d�ng�
        {
            var letters_ = Instantiate(letter);//belirledi�imiz prefabi spawnl�yor
            letters_.transform.parent = this.transform;// o prefab� bunun childi yap�yor
            letters_.transform.localScale = new Vector2(1f, 1f);//spawnlanan objenin boyutunu ayarl�yoruz
            int rastgeleSay� = rastgeleSay�lar[i];//spawnlana objenin rastgele konumu ayarl�yor
            if(rastgeleSay� >= harfdizisi.Length || harfdizisi[rastgeleSay�].ToString() == " ")//rastgele ayarlanan konum harf dizimizden b�y�k ise veya bo�luk i�eriyor ise
            {
                int say�letter = Random.Range(0, 29);
                letters_.GetComponent<GetLetter>().LetterName = letters[say�letter].ToString();
                letters_.GetComponent<GetLetter>().rastgele = true;
            }
            else
            {
                letters_.GetComponent<GetLetter>().LetterName = harfdizisi[rastgeleSay�].ToString();
                letters_.GetComponent<GetLetter>().rastgele = false;
            }
            _gameObjectLetters[i] = letters_;
        }
    }
    public void RenameLetters()//harfleri yeniden adland�r�yoruz
    {
        if (SaveManager.Instance.saveData.isTurkish == true)
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].ulkeIsm�.ToCharArray();
        }
        else
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].EU_ulke.ToCharArray();
        }
        rastgeleSay�lar = RastgeleSayilariOlustur(0, 9);
        for (int i = 0; i < 10; i++)
        {
            int rastgeleSay� = rastgeleSay�lar[i];
            if (rastgeleSay� >= harfdizisi.Length || harfdizisi[rastgeleSay�].ToString() == " ")
            {
                int say�letter = Random.Range(0, 29);
                _gameObjectLetters[i].GetComponent<GetLetter>().LetterName = letters[say�letter].ToString();
                _gameObjectLetters[i].GetComponentInChildren<TextMeshProUGUI>().text = letters[say�letter];
            }
            else
            {
                _gameObjectLetters[i].GetComponent<GetLetter>().LetterName = harfdizisi[rastgeleSay�].ToString();
                _gameObjectLetters[i].GetComponentInChildren<TextMeshProUGUI>().text = harfdizisi[rastgeleSay�].ToString();
            }
        }
    }
    int[] RastgeleSayilariOlustur(int min, int max)//rastgele say� olu�turma fonksiyonu
    {
        if (max - min + 1 < max)
        {
            throw new System.InvalidOperationException("�retilecek say� adedi maksimum de�ere e�it veya daha b�y�k olmal�d�r.");
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
