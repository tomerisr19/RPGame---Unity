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

    private bool isWalking;
    private bool isShooting;

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
        if (skeltonAI.isDie == false)
        {
            
            if (Input.GetKeyDown(KeyCode.T) && !skeltonAI.isDie)
            {
                nav.destination = skelton.transform.position;
                StartCoroutine(Attak());
            }
            else
            {
                anim.SetBool("isShooting", false);
                isShooting = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distFromPlayer = Vector3.Distance(this.transform.position, player.transform.position);
            anim.SetBool("isWalking", true);
            if (distFromPlayer <= 30f)
            {
                transform.LookAt(player.transform);
                if (updateTime > 2)
                {
                    nav.destination = player.transform.position;
                    updateTime = 0;
                }
            }

        }
        
    }

    IEnumerator Attak()
    {
        if (!isShooting)
        {            
            isShooting = true;
            anim.SetBool("isShooting", true);
            yield return new WaitForSeconds(1.2f);
            skeltonAI.TakeDamage(20);
            isShooting = false;
        }

    }

    private void LateUpdate()
    {
        if (skeltonAI.isDie == false)
        {
            float dist = Vector3.Distance(this.transform.position, skelton.transform.position);
            if (dist <= 30f)
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
}
