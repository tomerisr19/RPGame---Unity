using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayerData : MonoBehaviour
{
    public int questNumber;
    public int DialougeNumber;

    private UIManager uiManager;

    [Header("PlayerStats")]
     public float maxHealth;
     public float curHealth;

    [Header("UIComponents")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    public void TakeDamage(float Damage)
    {
        curHealth -= Damage;
        healthSlider.value = curHealth;
        if (curHealth <= 0)
        {
            uiManager.DeathScreenActive();
        }
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }
  

    public void Respawn()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Heal(float Heal)
    {
        curHealth += Heal;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }


}
