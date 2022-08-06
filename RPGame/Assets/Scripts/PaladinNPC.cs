using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using System;

public class PaladinNPC : MonoBehaviour
{

    private NavMeshAgent nav;
    public GameObject skelton;
    private Animator animator;
    private SkeltonAI skeltonAI;

    private bool isAttaking = false;

    private float updateTime = 0;

    //animator.SetInteger("State", 1);


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        skeltonAI = FindObjectOfType<SkeltonAI>();
    }

    void Update()
    {
        //updateTime += Time.deltaTime;

        //if (nav.enabled)
        //{
        //    transform.LookAt(skelton.transform);
        //    nav.SetDestination(skelton.transform.position);
        //    animator.SetInteger("state", 1);
        //}           
        //if (!skeltonAI.isDie)
        //{
        //    float dist = Vector3.Distance(this.transform.position, skelton.transform.position);
        //    if (dist <= 30f)
        //    {
        //        animator.SetInteger("state", 1);
        //        transform.LookAt(skelton.transform);
        //        if (updateTime > 2)
        //        {
        //            nav.destination = skelton.transform.position;
        //            updateTime = 0;
        //        }
        //    }              
        //    if (dist <= 4)
        //    {
        //        StartCoroutine(Attack());
        //    }
        //}

        updateTime += Time.deltaTime;
        if (skeltonAI.isDie)
        {
            nav.enabled = false;
        }
        else
        {
            float dist = Vector3.Distance(this.transform.position, skelton.transform.position);
            if (dist <= 2f)
            {
                StartCoroutine(Attack());
            }
            else
            {
                animator.SetInteger("state", 1);
                isAttaking = false;
            }
        }

        /*
        if(Input.GetKeyDown(KeyCode.Z))
            animator.SetInteger("State", 1); // idle fight
        if (Input.GetKeyDown(KeyCode.X))
            animator.SetInteger("State", 0); // idle
        if (Input.GetKeyDown(KeyCode.C))
            StartCoroutine(GetHitAndGetUp());
        */
    }

    IEnumerator Attack()
    {
        if (!isAttaking)
        {
            isAttaking = true;
            animator.SetInteger("state", 2);
            yield return new WaitForSeconds(2f);
            skeltonAI.TakeDamage(30);
            animator.SetInteger("state", 1);
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
