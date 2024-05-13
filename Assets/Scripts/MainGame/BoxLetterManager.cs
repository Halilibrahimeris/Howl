using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxLetterManager : MonoBehaviour
{
    public GameObject NextLevelPanel;
    public GameObject EndGamePanel;
    public GameObject BoxLetter;
    public LevelManager levelManager;
    public LetterManager LetterManager;
    public EmojiManager EmojiManager;
    public char[] harfdizisi;
    public GameObject[] boxletters;
    public int dogrusayac;
    public bool bolumgecildi = false;
    public Sprite[] letterSprite;
    GridLayoutGroup grid;
    AudioSource Audio;
    private void Awake()
    {
        CheckScene();
    }
    private void Start()
    {
        Debug.Log(levelManager.Spriteler.Count);
        spawnBoxLetter();
        grid = gameObject.GetComponent<GridLayoutGroup>();
        if (SaveManager.Instance.saveData.isTurkish)
        {
            grid.cellSize = new Vector2(levelManager.Spriteler[levelManager.ActiveLevel].CellSize[0], levelManager.Spriteler[levelManager.ActiveLevel].CellSize[1]);
        }
        else
        {
            grid.cellSize = new Vector2(levelManager.Spriteler[levelManager.ActiveLevel].EU_CellSize[0], levelManager.Spriteler[levelManager.ActiveLevel].EU_CellSize[1]);
        }
    }
    void spawnBoxLetter()
    {
        if(SaveManager.Instance.saveData.isTurkish == true)
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].ulkeIsmý.ToCharArray();
        }
        else
        {
            harfdizisi = levelManager.Spriteler[levelManager.ActiveLevel].EU_ulke.ToCharArray();
        }
        for (int i = 0; i < harfdizisi.Length; i++)
        {
            var _boxLetter = Instantiate(BoxLetter);
            _boxLetter.transform.parent = this.transform;
            _boxLetter.transform.localScale = new Vector2(1f, 1f);
            _boxLetter.GetComponent<BoxLetter>().index = i;
           if(" " == harfdizisi[_boxLetter.GetComponent<BoxLetter>().index].ToString())
            {
                _boxLetter.GetComponentInChildren<TextMeshProUGUI>().text = " ";
                _boxLetter.GetComponent<Image>().enabled = false;
                _boxLetter.GetComponent<BoxLetter>().isFree = true;
            }
            boxletters[i] = _boxLetter;
        }
    }

    void DestroyBoxLetters()
    {
        for (int i = 0; i < harfdizisi.Length; i++)
        {
            Destroy(boxletters[i]);
        }
        spawnBoxLetter();

    }

    public void CheckAnswer()
    {
        for (int i = 0; i < harfdizisi.Length; i++)
        {
            if(boxletters[i].GetComponentInChildren<TextMeshProUGUI>().text.ToString() == harfdizisi[i].ToString())
            {
                dogrusayac += 1;
            }
            else
            {
                dogrusayac = 0;
            }
        }
        if(dogrusayac == harfdizisi.Length && levelManager.ActiveLevel != levelManager.Spriteler.Count)
        {
            Audio = gameObject.GetComponent<AudioSource>();
            Audio.Play();
            NextLevelPanel.SetActive(true);
        }
        if(dogrusayac == harfdizisi.Length && levelManager.ActiveLevel+1 == levelManager.Spriteler.Count)
        {
            Audio = gameObject.GetComponent<AudioSource>();
            Audio.Play();
            EndGamePanel.SetActive(true);
        }
    }
    public void CheckScene()
    {
        int AcitiveSceneId = SceneManager.GetActiveScene().buildIndex;
        switch (AcitiveSceneId)
        {
            case 1:
                SaveManager.Instance.saveData.GenelLevel = levelManager.ActiveLevel;
                break;
            case 2:
                SaveManager.Instance.saveData.MeslekerLevel = levelManager.ActiveLevel;
                break;
            case 3:
                SaveManager.Instance.saveData.SporLevel = levelManager.ActiveLevel;
                break;
            case 4:
                SaveManager.Instance.saveData.HayvanlarLevel = levelManager.ActiveLevel;
                break;
            case 5:
                SaveManager.Instance.saveData.BayraklarLevel = levelManager.ActiveLevel;
                break;
            case 6:
                SaveManager.Instance.saveData.SehirlerLevel = levelManager.ActiveLevel;
                break;
            default:
                break;
        }
    }

    public void BolumGecildi()
    {
        if ((levelManager.ActiveLevel % 3) == 0)
        {
            SaveManager.Instance.saveData.HintCount += 1;
        }
        Debug.Log("Hint sayýsý :" + SaveManager.Instance.saveData.HintCount);
        EmojiManager.DestroyEmojis();
        bolumgecildi = true;
        for (int i = 0; i < LetterManager._gameObjectLetters.Length; i++)
        {
            LetterManager._gameObjectLetters[i].GetComponent<GetLetter>().ÝpucuGetLetter = false;
        }
        Debug.Log("Bolum gecildi");
        dogrusayac = 0;
        levelManager.ActiveLevel += 1;
        CheckScene();
        LetterManager.sayac = -1;
        EmojiManager.SpawnEmojis();
        DestroyBoxLetters();
        LetterManager.RenameLetters();
        for (int i = 0; i < LetterManager._gameObjectLetters.Length; i++)
        {
            LetterManager._gameObjectLetters[i].gameObject.GetComponent<Button>().interactable = true;
        }
        if (SaveManager.Instance.saveData.isTurkish)
        {
            grid.cellSize = new Vector2(levelManager.Spriteler[levelManager.ActiveLevel].CellSize[0], levelManager.Spriteler[levelManager.ActiveLevel].CellSize[1]);
        }
        else
        {
            grid.cellSize = new Vector2(levelManager.Spriteler[levelManager.ActiveLevel].EU_CellSize[0], levelManager.Spriteler[levelManager.ActiveLevel].EU_CellSize[1]);
        }
        NextLevelPanel.SetActive(false);
    }
}
