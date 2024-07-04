using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TextCTRL : MonoBehaviour
{
    [TextArea(4, 6)] public string[] dialogueLines;
    public GameObject dialoguePanel;
    public TMP_Text dialogueTxt;
    public bool dialogueStarted;
    int lineIndex;

    void Awake()
    {
        if (gameObject.tag == "NPC")
        {
            dialogueLines = GetComponent<NpcsValues>().dialogueLines;

            GameObject dialogueCanvas = GameObject.Instantiate(Resources.Load("DialogueCanvas"), transform.position, Quaternion.identity) as GameObject;

            dialoguePanel = dialogueCanvas.transform.GetChild(0).gameObject;

            dialogueTxt = dialoguePanel.transform.GetChild(0).gameObject.GetComponent<TMPro.TMP_Text>();
        }

    }
    void Update()
    {

        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            if(!dialogueStarted)
            {
                StartDialogue();
            }else if(dialogueTxt.text == dialogueLines[lineIndex])
            {
                NexDialogueLine();
            }else
            {
                StopAllCoroutines();
                dialogueTxt.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        print("Start sound");
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;

        StartCoroutine(ShowLine());
    }

    private void NexDialogueLine()
    {
        print("Start sound");
        lineIndex++;
        if(lineIndex < dialogueLines.Length) //Current dialogue hasn't got its final line yet
        {
            StartCoroutine(ShowLine());
        }else   //Current dialogue has finished
        {
            dialogueStarted = false;
            dialoguePanel.SetActive(false);


        }
    }

    private IEnumerator ShowLine()
    {
        dialogueTxt.text = string.Empty;
        if (dialogueLines != null)
        {
            foreach (char ch in dialogueLines[lineIndex])
            {
                dialogueTxt.text += ch;

                yield return new WaitForSeconds(0.05f);
            }
            print("Sound finished");
        }
        else 
        {
            print("dialogue is full");
        }
    }
}
