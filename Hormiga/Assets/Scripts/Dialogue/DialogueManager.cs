using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private int currentDialogueScore = 0;

    [SerializeField] private DialogueBoxCTRL dialogueBox;

    public Vector3 currentActorPosition;
    public GameObject player;
    [SerializeField] private PlayerController playerController;

    private List<Actors> convincedActors = new List<Actors>();

    public enum Actors
    {
        QUEEN,
        PRINCESS,
        NPC_ANTS,
        TWICE_SOLDIER_ANT,
        HYSTERICANT,
        NANNY_ANT,
        SCIANTIST,
        WIDE_EXOSKELETON
    }

    // Cambiar a diccionario con 3 idiomas
    public string[] actorNames_eng = new string[] { "Queen", "The Princess", "NPC Ants", "Twice Soldier Ant", "Hystericant", "Nanny Ant", "Sciantist", "Wide Exoskeleton" };


    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Found more than one AudioManager in the scene!!!");
            Debug.LogError("Destroying new instance!!!");
            Destroy(this);

        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddAnswerValueToDialogueScore(int value)
    {
        currentDialogueScore += value;
        if (currentDialogueScore >= 2)
        {
            
        }
    }

    public void AddConvincedActor(Actors actor)
    {
        convincedActors.Add(actor);
    }

    public void StartDialogue(DialogueSceneData dialogueScene, Vector3 actorPosition)
    {
        dialogueBox.gameObject.SetActive(true);
        currentActorPosition = actorPosition;
        dialogueBox.SetDialogueData(dialogueScene);
        // Quitar movimiento player
        DisablePlayerMovement();
    }

    public void EndDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
    }

    public void EnablePlayerMovement()
    {
        playerController.ActionEnable();
    }
    public void DisablePlayerMovement()
    {
        playerController.ActionDisable();
    }

}
