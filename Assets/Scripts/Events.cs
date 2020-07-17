using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static Action OnFinalPositionReached;
    public static void FinalPositionReached()
    {
        OnFinalPositionReached?.Invoke();
    }

    public static Action<Transform> OnCheckpointReached;
    public static void CheckpointReached(Transform target)
    {
        OnCheckpointReached?.Invoke(target);
    }

    public static Action OnCameraSetPosition;
    public static void CameraSetPosition()
    {
        OnCameraSetPosition?.Invoke();
    }

    public static Action OnOpenShop;
    public static void OpenShop()
    {
        OnOpenShop?.Invoke();
    }

    public static Action OnCloseShop;
    public static void CloseShop()
    {
        OnCloseShop?.Invoke();
    }

    public static Action OnOpenShopItems;
    public static void OpenShopItems()
    {
        OnOpenShopItems?.Invoke();
    }

    public static Action OnCloseShopItems;
    public static void CloseShopItems()
    {
        OnCloseShopItems?.Invoke();
    }

    public static Action OnRestart;
    public static void Restart()
    {
        OnRestart?.Invoke();
    }
}
