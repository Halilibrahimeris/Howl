using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emoji : MonoBehaviour
{
    public int spriteId;
    public LevelManager levelManager;
    public int levelManagerLevel;
    private EmojiManager emojiManager;
    public Image spriteRenderer;
    private void Start()
    {
        emojiManager = GetComponentInParent<EmojiManager>();
        levelManager = emojiManager.LevelManager;
        levelManagerLevel = levelManager.ActiveLevel;
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
        spriteRenderer.sprite = levelManager.Spriteler[levelManager.ActiveLevel].sprite[spriteId];
    }
}
