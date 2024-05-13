using UnityEngine.UI;
using UnityEngine;

public class ScroolBar : MonoBehaviour
{
    public float a;
    public float b = 1f; // Ba�lang�� de�eri
    public float c = 0.55f; // Biti� de�eri
    public float d; // Bu de�er 1 ile 0.55 aras�nda bir say�d�r

    public GameObject Settings;
    //public GameObject Shop;
    private Scrollbar scrollbar;
    public Color transpar;
    private void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
        transpar = Settings.GetComponent<Image>().color;
    }
    private void Update()
    {
        d = scrollbar.value;
        if (d <= 0.25f)
        {
            d = 0.25f;
        }
        if (d >= 1f)
        {
            d = 1f;
        }
        a = (d - c) / (1f - 0.25f);
        transpar.a = a;
        Settings.GetComponent<Image>().color = transpar;
        //Shop.GetComponent<Image>().color = transpar;
        if (scrollbar.value <= 0.25f)
        {
            Settings.gameObject.SetActive(false);
            //Shop.gameObject.SetActive(false);
        }
        else
        {
            Settings.gameObject.SetActive(true);
            //Shop.gameObject.SetActive(true);
        }
    }
}
