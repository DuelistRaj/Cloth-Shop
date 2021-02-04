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
}
