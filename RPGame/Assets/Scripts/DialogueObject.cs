using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{

[Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
}
    public class DialogueObject : MonoBehaviour
    {
        private PlayerData data;

        public TextMeshProUGUI DialogueText;
        public RigidbodyFirstPersonController rigid;

        [Header("Dialogue objects")]
        public DialogueOBJ dialogue1;

        [Header("NPCS")]
        public Npc1 npc1;

        private void Start()
        {
            data = FindObjectOfType<PlayerData>();
        }
        //private void OnEnable()
        //{
        //    PlayDialogue(dialogue1);
        //    curDialogue = dialogue1;
        //}

        //private void PlayDialogue(DialogueOBJ tempObj)
        //{
        //    if (currecntDialougeNum < tempObj.Dialogues.Length)
        //    {
        //        DialogueText.text = tempObj.Dialogues[currecntDialougeNum];
        //    }
        //    else
        //    {
        //        rigid.enabled = true;
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Cursor.visible = false;
        //        curDialogue = null;
        //        currecntDialougeNum = 0;


        //        this.gameObject.SetActive(false);
        //    }

        //}
        public void next()
        {
            rigid.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
           // curDialogue = null;

            this.gameObject.SetActive(false);
            //if (curDialogue != null)
            //{
            //    currecntDialougeNum++;
            //    PlayDialogue(curDialogue);
            //}
        }
    }
}
