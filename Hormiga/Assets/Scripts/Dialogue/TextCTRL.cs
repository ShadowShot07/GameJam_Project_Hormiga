using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class TextCTRL : MonoBehaviour
{
    public Dialogues[] dialogueBoxes;
    [TextArea(4, 6)] public string[] dialogueLines;
    public GameObject dialoguePanel;
    public TMP_Text dialogueTxt;
    public bool dialogueStarted;

    [TextArea(4, 6)] public string[] answerLines;
    public GameObject answerPanel;
    public GameObject[] answerBtns = new GameObject[2];
    public TMP_Text[] answerTxt = new TMP_Text[2];
    public bool isQuest;

    int lineIndex,
    boxIndex;

    void Awake()
    {
        GameObject dialogueCanvas = GameObject.Instantiate(Resources.Load("DialogueCanvas"), transform.position, Quaternion.identity) as GameObject;

        dialoguePanel = dialogueCanvas.transform.GetChild(0).gameObject;

        answerPanel = dialogueCanvas.transform.GetChild(1).gameObject;

        dialogueTxt = dialoguePanel.transform.GetChild(0).gameObject.GetComponent<TMPro.TMP_Text>();

        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtns[i] = answerPanel.transform.GetChild(i).gameObject;
            answerTxt[i] = answerBtns[i].transform.GetChild(0).GetComponent<TMPro.TMP_Text>();
        }
    }
    void Update()
    {
        if (boxIndex < dialogueBoxes.Length) isQuest = dialogueBoxes[boxIndex].isQuest;

        if (gameObject.tag == "NPC")
        {
            if(boxIndex != dialogueBoxes.Length)
            dialogueLines = dialogueBoxes[boxIndex].dialogueLines;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
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

            if(boxIndex != dialogueBoxes.Length) boxIndex++;

        }
    }

    private IEnumerator ShowLine()
    {
        dialogueTxt.text = string.Empty;
        if (dialogueLines[lineIndex] != null)
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
            print("dialogue is null");
        }
    }
}
