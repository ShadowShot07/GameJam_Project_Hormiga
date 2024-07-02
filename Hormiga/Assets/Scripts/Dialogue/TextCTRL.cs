using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TextCTRL : MonoBehaviour
{
    [TextArea(4 , 6)] public string[] dialogueLines;
    public GameObject dialoguePanel;
    public TMP_Text dialogueTxt;
    public bool dialogueStarted;
    int lineIndex;

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
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;

        StartCoroutine(ShowLine());
    }

    private void NexDialogueLine()
    {
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

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueTxt.text += ch;

            yield return new WaitForSeconds(0.05f);
        }
    }
}
