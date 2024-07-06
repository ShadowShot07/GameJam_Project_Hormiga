using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private int currentDialogueScore = 0;

    [SerializeField] private DialogueSceneData dialogueSceneTest;

    [SerializeField] private DialogueBoxCTRL dialogueBox;

    private Actors currentActor;

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
    public string[] actorNames_eng = new string[] { "Queen", "The Princess", "NPC Ants", "Twice Soldier Ant", "Hystericant", "Nanny Ant", "Sciantist" };


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

    public void StartDialogueTest()
    {
        // PAra testeo solo
        Vector3 testOrigin = new Vector3(Screen.width / 2, Screen.height / 2);
        dialogueBox.SetDialogueData(dialogueSceneTest, testOrigin);
        //
    }

    public void StartDialogue(DialogueSceneData dialogueScene, Vector3 origin)
    {
        currentActor = dialogueScene.GetSceneActor();
        dialogueBox.SetDialogueData(dialogueScene, origin);
    }

}
