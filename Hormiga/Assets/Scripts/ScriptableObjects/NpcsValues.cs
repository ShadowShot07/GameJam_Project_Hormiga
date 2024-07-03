using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class NpcsValues : MonoBehaviour
{
    [SerializeField]private NPCs npcValues;
    [SerializeField]private string npcName;
    [SerializeField] private string npcSprtName;
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        npcName = npcValues.npcName;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) print(npcName + " has a sprite renderer.");

        spriteRenderer.sprite = npcValues.npcSprite;
        if (spriteRenderer != null) print("Its sprite is " + spriteRenderer.sprite.name);


    }


}
