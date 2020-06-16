using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Events.OpenShop();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Events.CloseShop();
        }
    }
}
