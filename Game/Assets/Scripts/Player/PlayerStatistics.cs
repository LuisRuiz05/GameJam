using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{
    public PlayerMovement player;

    public int maxLife = 3;
    public int currentLife;
    public bool hasShield;

    [Header("Available Sprites")]
    public Sprite heart;
    public Sprite damagedHeart;
    public Sprite shield;

    [Header("Slots")]
    public Image heartSlot01;
    public Image heartSlot02;
    public Image heartSlot03;
    public Image shieldSlot;

    void Start()
    {
        currentLife = 3;

        heartSlot01.sprite = heart;
        heartSlot02.sprite = heart;
        heartSlot03.sprite = heart;
        
        shieldSlot.sprite = shield;
        shieldSlot.enabled = false;
    }

    public void UpdateUI()
    {
        shieldSlot.enabled = hasShield ? true : false;

        if(currentLife == 3)
        {
            heartSlot01.sprite = heart;
            heartSlot02.sprite = heart;
            heartSlot03.sprite = heart;
        }
        if (currentLife == 2)
        {
            heartSlot01.sprite = heart;
            heartSlot02.sprite = heart;
            heartSlot03.sprite = damagedHeart;
        }
        if (currentLife == 1)
        {
            heartSlot01.sprite = heart;
            heartSlot02.sprite = damagedHeart;
            heartSlot03.sprite = damagedHeart;
        }
        if (currentLife <= 0)
        {
            heartSlot01.sprite = damagedHeart;
            heartSlot02.sprite = damagedHeart;
            heartSlot03.sprite = damagedHeart;
            StartCoroutine(DeathScreen());
        }

    }

    public void UseShield()
    {
        player.speed = 6f;
        UpdateUI();
        StartCoroutine(ShieldCountdown());
    }

    public IEnumerator ShieldCountdown()
    {
        hasShield = true;
        yield return new WaitForSeconds(13);
        hasShield = false;
        player.speed = 3f;
        UpdateUI();
    }

    IEnumerator DeathScreen()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(2);
    }
}
