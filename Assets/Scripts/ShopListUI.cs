using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListUI : MonoBehaviour
{
    private Transform container;
    private Transform outfitTemplate;
    private ShopCustomer shopCustomer;

    [SerializeField]
    private Text dollar;

    public VectorValue data;

    public event Action OnCloseShop;

    private void Awake()
    {
        container = transform.Find("Container");
        outfitTemplate = container.Find("Outfit Template");

        container.Find("Reset").GetComponent<Button>().onClick.AddListener(Reset);
        outfitTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateOutfitEntry(Outfit.OutfitType.Original, Outfit.GetSprite(Outfit.OutfitType.Original), "Outfit Original", Outfit.GetPrice(Outfit.OutfitType.Original), 0, 0);
        CreateOutfitEntry(Outfit.OutfitType.May, Outfit.GetSprite(Outfit.OutfitType.May), "Outfit May", Outfit.GetPrice(Outfit.OutfitType.May), 0, 1);
        CreateOutfitEntry(Outfit.OutfitType.Wally, Outfit.GetSprite(Outfit.OutfitType.Wally), "Outfit Wally", Outfit.GetPrice(Outfit.OutfitType.Wally), 1, 0);

        Hide();
    }

    private void CreateOutfitEntry(Outfit.OutfitType outfitType, Sprite outfitSprite, string outfitName, int outfitPrice, int xindex, int yindex)
    {
        Transform outfitTempTransform = Instantiate(outfitTemplate, container);
        outfitTempTransform.gameObject.SetActive(true);
        RectTransform outfitoutfitRectTransform = outfitTempTransform.GetComponent<RectTransform>();

        float outfitHeight = 102f;
        float outfitWidth = 302f;

        outfitoutfitRectTransform.anchoredPosition = new Vector2(outfitWidth * yindex, -outfitHeight * xindex);

        outfitTempTransform.Find("Outfit Name").GetComponent<Text>().text = outfitName;
        outfitTempTransform.Find("Outfit Price").GetComponent<Text>().text = "$" + outfitPrice.ToString();

        outfitTempTransform.Find("Outfit Icon").GetComponent<Image>().sprite = outfitSprite;

        outfitTempTransform.GetComponent<Button>().onClick.AddListener(() => TryPurchaseOutfit(outfitType));
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Hide();
            OnCloseShop?.Invoke();
        }
    }

    private void TryPurchaseOutfit(Outfit.OutfitType outfitType)
    {
        if(shopCustomer.HasDollar(Outfit.GetPrice(outfitType)))
        {
            dollar.text = "$" + data.dollarAmount.ToString();
            shopCustomer.PurchasedOutfit(outfitType);
        }  
    }

    private void Reset()
    {
        data.dollarAmount = 10000;
    }

    public void Show(ShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
