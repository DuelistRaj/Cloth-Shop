using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Purchase }

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private ShopListUI shopUI;

    GameState state;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (playerController.IsShop)
            {
                state = GameState.Purchase;
            }

            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };

        if(shopUI != null)
        {
            shopUI.OnCloseShop += () =>
            {
                state = GameState.FreeRoam;
            };
        }
    }

    private void Update()
    {
        if(state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Purchase)
        {
            shopUI.HandleUpdate();
        }
    }
}
