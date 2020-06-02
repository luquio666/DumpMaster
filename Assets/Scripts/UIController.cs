using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject PanelShop;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowShop();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            HideAllPanels();
        }
    }

    void ShowShop()
    {
        PanelShop.SetActive(true);
    }
    void HideAllPanels()
    {
        PanelShop.SetActive(false);
    }
}
