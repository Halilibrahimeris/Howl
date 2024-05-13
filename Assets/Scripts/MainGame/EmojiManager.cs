using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManager : MonoBehaviour
{
    public Emoji[] Emojis;
    public GameObject[] EmojiBackGround;
    public LevelManager LevelManager;   
    public GameObject Emojiler;
    private void Start()
    {
        SpawnEmojis();
    }

    public void SpawnEmojis()
    {
        for (int i = 0; i < LevelManager.Spriteler[LevelManager.ActiveLevel].sprite.Length; i++)
        {
            var emoji = Instantiate(Emojiler);
            emoji.transform.parent = this.transform;
            emoji.transform.localScale = Vector3.one;
            emoji.GetComponentInChildren<Emoji>().spriteId = i;
            Emojis[i] = emoji.GetComponentInChildren<Emoji>();
            EmojiBackGround[i] = emoji;
        }
    }
    public void DestroyEmojis()
    {
        for (int i = 0; i < LevelManager.Spriteler[LevelManager.ActiveLevel].sprite.Length; i++)
        {
            Destroy(EmojiBackGround[i]);
        }
    }
}
