using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBox : MonoBehaviour
{
    public float damage = 20;

    private bool isInField = false;

    private SkeltonAI skel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "skeleton")
        {
            isInField = true;
            skel = other.GetComponent<SkeltonAI>();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "skeleton")
        {
            isInField = false;
            skel = null;
        }
    }

    public void Attak()
    {
        if (isInField)
        {
            skel.TakeDamage(damage);
        }
    }
}
