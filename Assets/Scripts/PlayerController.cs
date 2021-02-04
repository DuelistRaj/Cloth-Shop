using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour, ShopCustomer
{
    private Vector2 input;

    private Character character;

    private SpriteRenderer spriteRenderer;

    public VectorValue startingPosition;

    private bool isShop;

    public bool IsShop
    {
        get => isShop;
    }

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
        isShop = false;
        var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractablesLayer | GameLayers.i.SellerLayer);

        if(collider != null)
        {
            if (collider.CompareTag("Shop"))
            {
                isShop = true;
            }
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    public void PurchasedOutfit(Outfit.OutfitType outfitType)
    {
        if(outfitType == Outfit.OutfitType.Original)
        {
            startingPosition.walkDownSprites = Outfit.ChangeSpritesDown(Outfit.OutfitType.Original);
            startingPosition.walkUpSprites = Outfit.ChangeSpritesUp(Outfit.OutfitType.Original);
            startingPosition.walkLeftSprites = Outfit.ChangeSpritesLeft(Outfit.OutfitType.Original);
            startingPosition.walkRightSprites = Outfit.ChangeSpritesRight(Outfit.OutfitType.Original);
        }
            
        if (outfitType == Outfit.OutfitType.May)
        {
            startingPosition.walkDownSprites = Outfit.ChangeSpritesDown(Outfit.OutfitType.May);
            startingPosition.walkUpSprites = Outfit.ChangeSpritesUp(Outfit.OutfitType.May);
            startingPosition.walkLeftSprites = Outfit.ChangeSpritesLeft(Outfit.OutfitType.May);
            startingPosition.walkRightSprites = Outfit.ChangeSpritesLeft(Outfit.OutfitType.May);
        }
            
        if (outfitType == Outfit.OutfitType.Wally)
        {
            startingPosition.walkDownSprites = Outfit.ChangeSpritesDown(Outfit.OutfitType.Wally);
            startingPosition.walkUpSprites = Outfit.ChangeSpritesUp(Outfit.OutfitType.Wally);
            startingPosition.walkLeftSprites = Outfit.ChangeSpritesLeft(Outfit.OutfitType.Wally);
            startingPosition.walkRightSprites = Outfit.ChangeSpritesLeft(Outfit.OutfitType.Wally);
        } 
    }

    public bool HasDollar(int spendDollar)
    {
        if (startingPosition.dollarAmount >= spendDollar)
        {
            startingPosition.dollarAmount -= spendDollar;
            return true;
        }
        else
            return false;
    }
}
