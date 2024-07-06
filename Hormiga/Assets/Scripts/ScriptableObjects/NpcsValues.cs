using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class NpcsValues : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField]private NPC_Data npcValues;
    [SerializeField] private DialogueSceneData dialogueScene;
    
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        npcName = npcValues.npcName;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = npcValues.npcSprite;

        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(spriteRenderer.sprite.bounds.size.x + 1.5f , .5f , 1);
    }


}
