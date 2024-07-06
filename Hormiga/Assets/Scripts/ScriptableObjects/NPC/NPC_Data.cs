using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPC/newNPCData")]
public class NPC_Data : ScriptableObject
{
	[SerializeField] private DialogueManager.Actors npcName;
	[SerializeField] private Sprite npcSprite;
	[SerializeField] private DialogueSceneData npcDialogue;


	public DialogueManager.Actors GetNpcName()
	{
		return npcName;
	}

	public Sprite GetNpcSprite()
    {
		return npcSprite;
    }

	public DialogueSceneData GetNpcDialogue()
	{
		return npcDialogue;
	}


}
