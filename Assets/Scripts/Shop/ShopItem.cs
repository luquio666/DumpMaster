using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    ShopController _shopController;

    int _itemId;

    public void ConfigShopItem(ShopController shopController, int itemId)
    {
        _shopController = shopController;
        _itemId = itemId;
    }

    public void BuyItem()
    {

    }

}
