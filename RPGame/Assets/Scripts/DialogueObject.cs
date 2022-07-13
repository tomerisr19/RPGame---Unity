using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
}
public class DialogueObject : MonoBehaviour
{
    private PlayerData data;

    public TextMeshProUGUI DialogueText;

    private int currecntDialougeNum = 0;
    private DialogueOBJ curDialogue = null;

    [Header("Dialogue objects")]
    public DialogueOBJ dialogue1;

    private void Start()
    {
        data = FindObjectOfType<PlayerData>();
    }
    private void OnEnable()
    {
        PlayDialogue(dialogue1);
        curDialogue = dialogue1;
    }

    private void PlayDialogue(DialogueOBJ tempObj)
    {
        if (currecntDialougeNum < tempObj.Dialogues.Length)
        {
            DialogueText.text = tempObj.Dialogues[currecntDialougeNum];
        }
        else
        {
            //end the dialouge
        }
        
    }
    public void next()
    {
        if (curDialogue != null)
        {
            currecntDialougeNum++;
            PlayDialogue(curDialogue);
        }
    }
}
