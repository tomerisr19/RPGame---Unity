using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    private int currectHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currectHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currectHealth += amount;

        float currentHealthPct = (float)currectHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
    }
}
