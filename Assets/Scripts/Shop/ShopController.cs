using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject ShopItemsUI;

    #region Events
    private void OnEnable()
    {
        Events.OnOpenShop += OpenShop;
        Events.OnCloseShop += CloseShop;
        Events.OnOpenShopItems += OpenShopItems;
        Events.OnCloseShopItems += CloseShopItems;
    }

    private void OnDisable()
    {
        Events.OnOpenShop -= OpenShop;
        Events.OnCloseShop -= CloseShop;
        Events.OnOpenShopItems -= OpenShopItems;
        Events.OnCloseShopItems -= CloseShopItems;
    }

    void OpenShop()
    {
        ShopUI.SetActive(true);
    }

    void CloseShop()
    {
        ShopUI.SetActive(false);
    }

    void OpenShopItems()
    {
        ShopItemsUI.SetActive(true);
    }

    void CloseShopItems()
    {
        ShopItemsUI.SetActive(false);
    }
    #endregion

    public void Option_ShowItems()
    {
        Events.OpenShopItems();
    }

    public void Option_ContinueWithoutSave()
    {
        Events.CloseShop();
        Events.Restart();
    }

    public void Option_SaveAndContinue()
    {
        Events.CloseShop();
        Events.Restart();
    }

}
