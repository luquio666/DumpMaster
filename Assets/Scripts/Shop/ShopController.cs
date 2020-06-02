using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public Text
    public GameObject Dialog;
    public GameObject ShopItems;

    public void DialogOption_ShowShop()
    {
        print("SHOWING SHOP");
    }

    public void DialogOption_Leave()
    {
        print("CONTINUE WITHOUT SAVE");
    }

    public void DialogOption_SaveCheckpoint()
    {
        print("CHECKPOINT SAVED");
    }

    public void Shop_GetItem()
    {
        // Get items like powerup
    }

}
