using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
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
    
    public static Action OnRestart;
    public static void Restart()
    {
        OnRestart?.Invoke();
    }
}
