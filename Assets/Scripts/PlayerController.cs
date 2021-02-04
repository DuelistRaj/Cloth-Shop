using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;

    private Character character;

    private SpriteRenderer spriteRenderer;

    public VectorValue startingPosition;

    private void Awake()
    {
        character = GetComponent<Character>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        transform.position = startingPosition.initialValue;
        character.Animator.MoveY = startingPosition.spriteDirection;
    }

    public void HandleUpdate()
    {
        if(!character.IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
                input.y = 0;

            if (input != Vector2.zero)
            {
                spriteRenderer.flipX = false;

                if (input.x > 0)
                    spriteRenderer.flipX = true;

                StartCoroutine(character.Move(input));

                startingPosition.spriteDirection = input.y;
            }
        }

        character.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.X))
            Interact();
    }

    private void Interact()
    {
        var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractablesLayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
}
