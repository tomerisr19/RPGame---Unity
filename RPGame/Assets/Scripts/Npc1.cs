using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
namespace UnityStandardAssets.Characters.FirstPerson
{

    public class Npc1 : MonoBehaviour
    {
        private NavMeshAgent npcMesh;
        public Transform playerObj;

        private float updateTime = 0;

        public GameObject triggerText;
        public GameObject DialogObject;
        public RigidbodyFirstPersonController rigid;

        private bool isComingToHelp = false;

        private void Start()
        {
            npcMesh = GetComponent<NavMeshAgent>();
        }

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                triggerText.SetActive(true);
                triggerText.GetComponent<TextMeshProUGUI>().text = "I need your help to take the castle back !";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DialogObject.SetActive(true);
                    //other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    triggerText.SetActive(false);
                    isComingToHelp = true;
                }
            }
        }

        private void Update()
        {
            updateTime += Time.deltaTime;

        }

        private void LateUpdate()
        {
            float dist = Vector3.Distance(this.transform.position, playerObj.transform.position);
            if (dist <= 30f)
            {
                transform.LookAt(playerObj.transform);
                if (updateTime > 2 && isComingToHelp)
                {
                    npcMesh.destination = playerObj.transform.position;
                    updateTime = 0;
                }
            }

        }


        void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}
    
