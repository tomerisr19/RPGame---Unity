using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace UnityStandardAssets.Characters.FirstPerson
{

    public class Npc1 : MonoBehaviour
    {
        public GameObject triggerText;
        public GameObject DialogObject;
        public RigidbodyFirstPersonController rigid;

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                triggerText.SetActive(true);
                triggerText.GetComponent<TextMeshProUGUI>().text = "Lets take the cassle back !";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DialogObject.SetActive(true);
                    //other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    triggerText.SetActive(false);
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}
