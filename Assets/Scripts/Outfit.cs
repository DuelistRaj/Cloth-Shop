using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfit
{

    public enum OutfitType
    {
        Original,
        May,
        Wally
    }

    public static int GetPrice(OutfitType outfitType)
    {
        switch(outfitType)
        {
            default:
            case OutfitType.Original: return 0;
            case OutfitType.May: return 100;
            case OutfitType.Wally: return 200;
        }
    }

    public static Sprite GetSprite(OutfitType outfitType)
    {
        switch(outfitType)
        {
            default:
            case OutfitType.Original: return SpriteAssets.i.Original;
            case OutfitType.May: return SpriteAssets.i.MayOutfit;
            case OutfitType.Wally: return SpriteAssets.i.WallyOutfit;
        }
    }

    public static List<Sprite> ChangeSpritesDown(OutfitType outfitType)
    {
        switch (outfitType)
        {
            default:
            case Outfit.OutfitType.Original: return SpriteAssets.i.WalkDownSpritesOriginal;
            case Outfit.OutfitType.May: return SpriteAssets.i.WalkDownSpritesMay;
            case Outfit.OutfitType.Wally: return SpriteAssets.i.WalkDownSpritesWally;
        }
    }

    public static List<Sprite> ChangeSpritesUp(OutfitType outfitType)
    {
        switch (outfitType)
        {
            default:
            case Outfit.OutfitType.Original: return SpriteAssets.i.WalkUpSpritesOriginal;
            case Outfit.OutfitType.May: return SpriteAssets.i.WalkUpSpritesMay;
            case Outfit.OutfitType.Wally: return SpriteAssets.i.WalkUpSpritesWally;
        }
    }

    public static List<Sprite> ChangeSpritesLeft(OutfitType outfitType)
    {
        switch (outfitType)
        {
            default:
            case Outfit.OutfitType.Original: return SpriteAssets.i.WalkLeftSpritesOriginal;
            case Outfit.OutfitType.May: return SpriteAssets.i.WalkLeftSpritesMay;
            case Outfit.OutfitType.Wally: return SpriteAssets.i.WalkLeftSpritesWally;
        }
    }

    public static List<Sprite> ChangeSpritesRight(OutfitType outfitType)
    {
        switch (outfitType)
        {
            default:
            case Outfit.OutfitType.Original: return SpriteAssets.i.WalkRightSpritesOriginal;
            case Outfit.OutfitType.May: return SpriteAssets.i.WalkRightSpritesMay;
            case Outfit.OutfitType.Wally: return SpriteAssets.i.WalkRightSpritesWally;
        }
    }
}
