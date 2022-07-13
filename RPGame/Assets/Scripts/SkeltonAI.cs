using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeltonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Animator anim;

    private PlayerData playerData;

    private bool isAttaking;
    private float updateTime = 0;
    public float damgeTaken = 10;
    

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        playerData = FindObjectOfType<PlayerData>();
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
    }

    IEnumerator Attak()
    {
        if (!isAttaking)
        {
            isAttaking = true;
            anim.SetBool("Attak", true);
            yield return new WaitForSeconds(1.2f);
            playerData.TakeDamage(damgeTaken);
            isAttaking = false;
        }
        
    }
    private void LateUpdate()
    {
        transform.LookAt(player.transform);
        if (updateTime > 2)
        {
            nav.destination = player.transform.position;
            updateTime = 0;
        }
    }

}
