using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public int questNumber;
    public int DialougeNumber;

    [Header("PlayerStats")]
     public float maxHealth;
     public float curHealth;

    [Header("UIComponents")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private void Start()
    {
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
            SceneManager.LoadScene("MainScene");
        }
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
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
