using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DialogObject.SetActive(true);
                    //other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}
