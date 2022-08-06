using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

public class SkeltonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Animator anim;

    private PlayerData playerData;

    public Slider skeltonHealthSlider;

    public float maxHealth;
    public float curHealth;

    public bool isDie = false;
    private bool isAttaking;


    private float updateTime = 0;
    public float damgeTaken = 10;
    

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        playerData = FindObjectOfType<PlayerData>();
        skeltonHealthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        skeltonHealthSlider.value = curHealth;
    }

    private void Update()
    {
        updateTime += Time.deltaTime;

        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist <= 4)
        {
            StartCoroutine(Attak());
        }
        else
        {
            anim.SetBool("Attak", false);
            isAttaking = false;
        }
        if (curHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("die");
        nav.enabled = false;
        Destroy(gameObject, 2);
        isDie = true;
    }

   

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        skeltonHealthSlider.value = curHealth;
        if (curHealth <= 0)
        {
            // mashuSheOseSheOONofel.SetActive
        }
    }

    IEnumerator Attak()
    {
        if (!isAttaking)
        {
            isAttaking = true;
            anim.SetBool("Attak", true);
            yield return new WaitForSeconds(1.2f);
            playerData.TakeDamage(0);
            isAttaking = false;
        }
        
    }
    private void LateUpdate()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist <= 30f)
        {
            transform.LookAt(player.transform);
            if (updateTime > 2 && !isDie)
            {
                nav.destination = player.transform.position;
                updateTime = 0;
            }
        }      
    }

}
