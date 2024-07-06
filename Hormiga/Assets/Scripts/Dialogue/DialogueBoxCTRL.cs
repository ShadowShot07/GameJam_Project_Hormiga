using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueBoxCTRL : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueTxt;
    public bool dialogueStarted;

    [SerializeField] private TMP_Text actorNameText;
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private Button answer1Button;
    [SerializeField] private Button answer2Button;

    private DialogueSceneData currentDialogueSceneData;

    private string currentDialogueText;
    
    private List<DialogueAnswerData> answers;

    private DialogueAnswerData[]  answersArray;

    private int currentDialogueDataIndex = 0;

    private Movement inputMap;

    private bool isReadyForNewLine = false;
    private bool isAnswering = false;
    private bool isLastDialogue = false;

    private string lastBranchId;

    private int currentSuccessPoints = 0;


    private void Awake()
    {
        dialoguePanel.SetActive(false);
        answerPanel.SetActive(false);
        inputMap = new Movement();
    }

    void Update()
    {
        if (inputMap.Player.SkipText.WasPressedThisFrame())
        {
            if (isReadyForNewLine)
            {
                NextDialogueLine();
                dialogueStarted = true;
            }
            else
            {
                if (!isAnswering)
                {
                    StopAllCoroutines();
                    dialogueTxt.text = currentDialogueText;
                    ShowAnswers();
                }
            }

        }
    }

    private void OnEnable()
    {
        inputMap.Player.Enable();
    }

    private void OnDisable()
    {
        inputMap.Player.Disable();
    }

    public void SetDialogueData(DialogueSceneData dialogueSceneData, Vector3 origin)
    {
        currentDialogueSceneData = dialogueSceneData;
        if (!currentDialogueSceneData.IsEmpty())
        {
            currentDialogueText = currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetDialogue();
            answers = currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetAnswers();
            this.transform.position = origin + new Vector3(0f, 10f);
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        dialogueStarted = true;
        isReadyForNewLine = false;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        isReadyForNewLine = false;
        currentDialogueDataIndex++;
        if (currentDialogueDataIndex < currentDialogueSceneData.DialogueCount() - 3) //Current dialogue hasn't got conclusion dialogues
        {
            if (lastBranchId != "")
            {
                if (currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetBranchId() != lastBranchId && currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetBranchId() != "")
                {
                    currentDialogueDataIndex++;
                }
            }
            else
            {
                if (currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetBranchId() != "")
                {
                    currentDialogueDataIndex++;
                }
            }
            currentDialogueText = currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetDialogue();
            answers = currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetAnswers();
            StartCoroutine(ShowLine());
        }
        else if (currentDialogueDataIndex >= currentDialogueSceneData.DialogueCount() - 3 && !isLastDialogue)
        {
            isLastDialogue = true;
            currentDialogueText = currentDialogueSceneData.GetConclusionDialogue(currentSuccessPoints).GetDialogue();
            StartCoroutine(ShowLine()); 
        }
        else// Current dialogue has finished
        {
            dialogueStarted = false;
            dialoguePanel.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        actorNameText.text = DialogueManager.instance.actorNames_eng[(int)currentDialogueSceneData.GetSceneDialogue(currentDialogueDataIndex).GetActorName()];
        dialogueTxt.text = string.Empty;
        if (currentDialogueText != null)
        {
            foreach (char ch in currentDialogueText)
            {
                dialogueTxt.text += ch;
                if (!char.IsWhiteSpace(ch))
                {
                    yield return new WaitForSeconds(0.05f);
                }
                else 
                {
                    yield return new WaitForSeconds(0.1f);
                }
                
            }

            // Comprobar si hay respuestas
            ShowAnswers();

        }
        else
        {
            print("dialogue is full");
        }
    }

    private void ShowAnswers()
    {
        if (answers.Count > 0)
        {
            isAnswering = true;
            // Randomizar respuestas

            List<DialogueAnswerData> copiedAnswers = new List<DialogueAnswerData>();
            for (int i=0; i<answers.Count;i++)
            {
                copiedAnswers.Add(answers[i]);
            }
            int random = Random.Range(0, 2);
            List<DialogueAnswerData> shuffledAnswers = new List<DialogueAnswerData>();
            shuffledAnswers.Add(copiedAnswers[random]);
            copiedAnswers.RemoveAt(random);
            shuffledAnswers.Add(copiedAnswers[0]);

            // Rellenar respuestas

            answer1Button.GetComponentInChildren<TMP_Text>().text = shuffledAnswers[0].GetAnswerText();
            answer2Button.GetComponentInChildren<TMP_Text>().text = shuffledAnswers[1].GetAnswerText();

            // Limpiamos antiguos listeners
            answer1Button.onClick.RemoveAllListeners();
            answer2Button.onClick.RemoveAllListeners();

            // Cada botón deberia tener el valor de respuesta
            answer1Button.onClick.AddListener(delegate { OnAnswerButtonPressed(shuffledAnswers[0].GetAnswerValue()); });
            answer2Button.onClick.AddListener(delegate { OnAnswerButtonPressed(shuffledAnswers[1].GetAnswerValue()); });


            // Mostrar respuestas
            answerPanel.SetActive(true);
        }

        else
        {
            // Siguiente DialogueData
            isReadyForNewLine = true;
            lastBranchId = "";
        }
    }

    public void OnAnswerButtonPressed(int answerValue)
    {
        if (answerValue == 1)
        {
            lastBranchId = "A";
        }
        else 
        {
            lastBranchId = "B";
        }
        currentSuccessPoints += answerValue;
        print("Current succes points: " + currentSuccessPoints);
        //DialogueManager.instance.AddAnswerValueToDialogueScore(answerValue);
        isAnswering = false;
        answerPanel.SetActive(false);
        NextDialogueLine();
    }
}
