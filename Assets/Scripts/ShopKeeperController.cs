using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperController : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog dialog;

    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
}
