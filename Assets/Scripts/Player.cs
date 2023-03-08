using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private GameObject player;

    public Sprite[] sprites;

    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PhysicsEngine physicsEngine = GetComponent<PhysicsEngine>();
        player = GameObject.Find("Player");
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void Update()
    {
        //Press mouse, and the player will jump
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (player.transform.position.y >= 4.7f)
        {
            player.transform.position = new Vector3(-0.5f, 4.7f, 0f);
        }
    }

    private void Jump()
    {
        PhysicsEngine physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.JumpForce(10f);
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

}
