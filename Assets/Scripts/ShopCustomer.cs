using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShopCustomer
{
    void PurchasedOutfit(Outfit.OutfitType outfitType);
    bool HasDollar(int dollar);
}
