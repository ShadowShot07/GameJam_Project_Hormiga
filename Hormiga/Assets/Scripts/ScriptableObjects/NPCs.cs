using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MadNesst/NPC/newNPC")]
public class NPCs : ScriptableObject
{
	public string npcName;
	public Sprite npcSprite;
	public Animator npcAnm;
	public bool inInYourTeam = false;

}
