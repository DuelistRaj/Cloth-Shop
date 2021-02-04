using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssets : MonoBehaviour
{
    [SerializeField]
    private Sprite original;
    [SerializeField]
    private Sprite mayOutfit;
    [SerializeField]
    private Sprite wallyOutfit;

    [SerializeField]
    private List<Sprite> walkDownSpritesOriginal;
    [SerializeField]
    private List<Sprite> walkUpSpritesOriginal;
    [SerializeField]
    private List<Sprite> walkLeftSpritesOriginal;
    [SerializeField]
    private List<Sprite> walkRightSpritesOriginal;

    [SerializeField]
    private List<Sprite> walkDownSpritesMay;
    [SerializeField]
    private List<Sprite> walkUpSpritesMay;
    [SerializeField]
    private List<Sprite> walkLeftSpritesMay;
    [SerializeField]
    private List<Sprite> walkRightSpritesMay;

    [SerializeField]
    private List<Sprite> walkDownSpritesWally;
    [SerializeField]
    private List<Sprite> walkUpSpritesWally;
    [SerializeField]
    private List<Sprite> walkLeftSpritesWally;
    [SerializeField]
    private List<Sprite> walkRightSpritesWally;

    public static SpriteAssets i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public Sprite Original
    {
        get => original;
    }

    public Sprite MayOutfit
    {
        get => mayOutfit;
    }

    public Sprite WallyOutfit
    {
        get => wallyOutfit;
    }

    public List<Sprite> WalkDownSpritesOriginal
    {
        get => walkDownSpritesOriginal;
    }

    public List<Sprite> WalkUpSpritesOriginal
    {
        get => walkUpSpritesOriginal;
    }

    public List<Sprite> WalkLeftSpritesOriginal
    {
        get => walkLeftSpritesOriginal;
    }

    public List<Sprite> WalkRightSpritesOriginal
    {
        get => walkRightSpritesOriginal;
    }

    public List<Sprite> WalkDownSpritesMay
    {
        get => walkDownSpritesMay;
    }

    public List<Sprite> WalkUpSpritesMay
    {
        get => walkUpSpritesMay;
    }

    public List<Sprite> WalkLeftSpritesMay
    {
        get => walkLeftSpritesMay;
    }

    public List<Sprite> WalkRightSpritesMay
    {
        get => walkRightSpritesMay;
    }

    public List<Sprite> WalkDownSpritesWally
    {
        get => walkDownSpritesWally;
    }

    public List<Sprite> WalkUpSpritesWally
    {
        get => walkUpSpritesWally;
    }

    public List<Sprite> WalkLeftSpritesWally
    {
        get => walkLeftSpritesWally;
    }

    public List<Sprite> WalkRightSpritesWally
    {
        get => walkRightSpritesWally;
    }
}
