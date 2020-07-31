using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnRestart += ReloadScene;
    }
    private void OnDisable()
    {
        GameEvents.OnRestart -= ReloadScene;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
