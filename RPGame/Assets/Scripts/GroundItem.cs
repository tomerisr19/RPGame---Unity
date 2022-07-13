using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundItem : MonoBehaviour
{
    public TextMeshProUGUI triggerText;
    public new string name;

    private void OnTriggerStay(Collider other)
    {
        triggerText.gameObject.SetActive(true);
        triggerText.text = "Press E to pick up " + name;
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerText.gameObject.SetActive(false);
    }
}
