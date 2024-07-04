using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(TextCTRL))]

public class NpcsValues : MonoBehaviour
{
    [SerializeField]private NPCs npcValues;
    [SerializeField]private string npcName;
    [SerializeField] private string npcSprtName;

    [TextArea(4, 6)] public string[] dialogueLines;

    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        //Setting character's name
        npcName = npcValues.npcName;

        //Setting character's sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = npcValues.npcSprite;

        //Setting character's collider
        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(spriteRenderer.sprite.bounds.size.x + 1.5f , .5f , 1);

    }


}
