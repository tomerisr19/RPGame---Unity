using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GateOpening : MonoBehaviour
{
    public Animator anim;
    public GameObject triggerText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerText.SetActive(true);
            triggerText.GetComponent<TextMeshProUGUI>().text = "Press E to open the gate";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                OpenGate();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerText.SetActive(false);
        }

    }

    private void OpenGate()
    {
        anim.enabled = true;
        triggerText.SetActive(false);
        Destroy(gameObject);
    }
}
