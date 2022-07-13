using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogObject;

    private void Start()
    {
        triggerText.SetActive(false);
        DialogObject.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogObject.SetActive(true);
                other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        triggerText.SetActive(false);
    }
}
