using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> walkDownSprites;
    [SerializeField]
    private List<Sprite> walkUpSprites;
    [SerializeField]
    private List<Sprite> walkLeftSprites;
    [SerializeField]
    private List<Sprite> walkRightSprites;

    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }

    public VectorValue spriteData;

    private bool wasPreviouslyMoving;

    private SpriteAnimator walkDownAnim;
    private SpriteAnimator walkUpAnim;
    private SpriteAnimator walkLeftAnim;
    private SpriteAnimator walkRightAnim;

    private SpriteAnimator currentAnim;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (gameObject.CompareTag("Player"))
        {
            ChangePlayerOutfit();
        }
        else
        {
            walkDownAnim = new SpriteAnimator(walkDownSprites, spriteRenderer);
            walkUpAnim = new SpriteAnimator(walkUpSprites, spriteRenderer);
            walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);
            walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);
        }

        currentAnim = walkDownAnim;
    }

    private void Update()
    {
        var previousAnim = currentAnim;

        if (MoveX == 1)
            currentAnim = walkRightAnim;
        else if (MoveX == -1)
            currentAnim = walkLeftAnim;
        else if (MoveY == 1)
            currentAnim = walkUpAnim;
        else if (MoveY == -1)
            currentAnim = walkDownAnim;

        if (currentAnim != previousAnim || IsMoving != wasPreviouslyMoving)
            currentAnim.Start();

        if (IsMoving)
            currentAnim.HandleUpdate();
        else
            spriteRenderer.sprite = currentAnim.Frames[0];

        wasPreviouslyMoving = IsMoving;

    }

    public void ChangePlayerOutfit()
    {
        foreach (var sprite in spriteData.walkDownSprites)
            spriteRenderer.sprite = sprite;

        foreach (var sprite in spriteData.walkUpSprites)
            spriteRenderer.sprite = sprite;

        foreach (var sprite in spriteData.walkLeftSprites)
            spriteRenderer.sprite = sprite;

        foreach (var sprite in spriteData.walkRightSprites)
            spriteRenderer.sprite = sprite;

        walkDownAnim = new SpriteAnimator(spriteData.walkDownSprites, spriteRenderer);
        walkUpAnim = new SpriteAnimator(spriteData.walkUpSprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(spriteData.walkLeftSprites, spriteRenderer);
        walkRightAnim = new SpriteAnimator(spriteData.walkRightSprites, spriteRenderer);
    }
}
