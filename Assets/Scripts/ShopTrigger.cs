using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField]
    private ShopListUI shopUI;

    private ShopCustomer shopCustomer;

    private void Start()
    {
        DialogManager.Instance.OnCloseDialog += () =>
        {
            Show();
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        shopCustomer = other.GetComponent<ShopCustomer>();
    }

    private void Show()
    {
        if(shopCustomer != null)
            shopUI.Show(shopCustomer);
    }
}
