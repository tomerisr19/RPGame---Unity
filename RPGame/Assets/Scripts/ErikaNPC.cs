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

    public bool isDie = false;
    private bool isAttaking;

    private float updateTime = 0;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skeltonAI = FindObjectOfType<SkeltonAI>();
    }

    private void Update()
    {
        updateTime += Time.deltaTime;
        if (skeltonAI.isDie)
        {
            nav.enabled = false;
        }
        else
        {
            float dist = Vector3.Distance(this.transform.position, skelton.transform.position);
            if (dist <= 5)
            {
                StartCoroutine(Attak());
            }
            else
            {
                anim.SetBool("Attak", false);
                isAttaking = false;
            }
        }        
    }  

    IEnumerator Attak()
    {
        if (!isAttaking)
        {
            isAttaking = true;
            anim.SetBool("Attak", true);
            skeltonAI.TakeDamage(50);
            yield return new WaitForSeconds(2f);         
            isAttaking = false;
        }
    }
    private void LateUpdate()
    {
        if (!skeltonAI.isDie)
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
