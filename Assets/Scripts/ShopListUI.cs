using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListUI : MonoBehaviour
{
    private Transform container;
    private Transform outfitTemplate;

    private void Awake()
    {
        container = transform.Find("Container");
        outfitTemplate = container.Find("Outfit Template");
        outfitTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemEntry(Outfit.GetSprite(Outfit.OutfitType.Original), "Outfit Original", Outfit.GetPrice(Outfit.OutfitType.Original), 0, 0);
        CreateItemEntry(Outfit.GetSprite(Outfit.OutfitType.May), "Outfit May", Outfit.GetPrice(Outfit.OutfitType.May), 0, 1);
        CreateItemEntry(Outfit.GetSprite(Outfit.OutfitType.Wally), "Outfit Wally", Outfit.GetPrice(Outfit.OutfitType.Wally), 1, 0);
    }

    private void CreateItemEntry(Sprite itemSprite, string itemName, int itemPrice, int xindex, int yindex)
    {
        Transform outfitTempTransform = Instantiate(outfitTemplate, container);
        outfitTempTransform.gameObject.SetActive(true);
        RectTransform outfitItemRectTransform = outfitTempTransform.GetComponent<RectTransform>();

        float itemHeight = 102f;
        float itemWidth = 302f;

        outfitItemRectTransform.anchoredPosition = new Vector2(itemWidth * yindex, -itemHeight * xindex);

        outfitTempTransform.Find("Item Name").GetComponent<Text>().text = itemName;
        outfitTempTransform.Find("Item Price").GetComponent<Text>().text = itemPrice.ToString();

        outfitTempTransform.Find("Item Icon").GetComponent<Image>().sprite = itemSprite;
    }

    public void Test()
    {
        Debug.Log("Clicked");
    }
}
