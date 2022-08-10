using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

public class ErikaNPC : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject skelton;
    public GameObject player;
    private Animator anim;

    private SkeltonAI skeltonAI;

    public Slider NPCHealthSlider;

    public float maxHealth;
    public float curHealth;

    public bool isDie = false;
    private bool isAttaking;

    private float updateTime = 0;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skeltonAI = FindObjectOfType<SkeltonAI>();
        NPCHealthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        NPCHealthSlider.value = curHealth;
    }

    private void Update()
    {
        updateTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.V))
        {
            anim.Play("Stable Sword Outward Slash");
            curHealth -= 3;
            NPCHealthSlider.value = curHealth;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.Play("Walking");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Die();
        }
        
        //if (skeltonAI.isDie)
        //{
        //    nav.enabled = false;
        //}
        //else
        //{
        //    float dist = Vector3.Distance(this.transform.position, skelton.transform.position);
        //    if (dist <= 5)
        //    {
        //        StartCoroutine(Attak());
        //    }
        //    else
        //    {
        //        anim.Play("Attak");
        //        isAttaking = false;
        //    }
        //}        
    }

    private void Die()
    {
        anim.SetTrigger("die");
        nav.enabled = false;
        //Destroy(gameObject, 2);
        isDie = true;
    }

    //IEnumerator Attak()
    //{
    //    if (!isAttaking)
    //    {
    //        isAttaking = true;
    //        anim.Play("Attak");
    //        skeltonAI.TakeDamage(50);
    //        yield return new WaitForSeconds(2f);         
    //        isAttaking = false;
    //    }
    //}
    private void LateUpdate()
    {
        if (skelton == null)
        {
            transform.LookAt(player.transform);
        }
        else
        {
            transform.LookAt(skelton.transform);
            if (updateTime > 2)
            {
                nav.destination = skelton.transform.position;
                updateTime = 0;
            }
        }       
    }

}
