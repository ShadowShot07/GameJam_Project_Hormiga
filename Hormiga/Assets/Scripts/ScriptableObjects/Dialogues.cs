using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MadNesst/Dialogue/newDialogueBox")]
public class Dialogues : ScriptableObject
{
    [TextArea(4, 6)] public string[] dialogueLines;
    public bool isQuest = false;
    [TextArea(4, 6)] public string[] answerLines;
}
