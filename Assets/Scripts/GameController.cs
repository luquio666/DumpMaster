using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text Distance;

    public GameObject Player;

    float _startPosition;
    float _currentPosition;

    private void OnEnable()
    {
        Events.OnRestart += ReloadScene;
    }
    private void OnDisable()
    {
        Events.OnRestart -= ReloadScene;
    }

    private void Start()
    {
        _startPosition = Player.transform.position.y;
        _currentPosition = _startPosition;
    }

    private void Update()
    {
        SetGamespeed();
        MeasureDistance();
    }

    void SetGamespeed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Time.timeScale = .1f;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Time.timeScale = .2f;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Time.timeScale = .3f;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale = .4f;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale = .5f;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            Time.timeScale = .6f;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            Time.timeScale = .7f;
        if (Input.GetKeyDown(KeyCode.Alpha8))
            Time.timeScale = .8f;
        if (Input.GetKeyDown(KeyCode.Alpha9))
            Time.timeScale = .9f;
        if (Input.GetKeyDown(KeyCode.Alpha0))
            Time.timeScale = 1f;
    }

    void MeasureDistance()
    {
        if (Player.transform.position.y > _currentPosition)
            _currentPosition = Player.transform.position.y;

        var distance = _currentPosition - _startPosition;
        Distance.text = (int)distance + " inches";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
