using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyValueController : MonoBehaviour
{

    public Platformer Player;

    public PropertyValue P_Speed;
    public PropertyValue P_JumpForce;
    public PropertyValue P_AditionalJumps;

    [Space]

    public Camera Cam;

    public PropertyValue C_Size;

    [Space]

    public Spawner Spawner;

    public PropertyValue S_TimeBetween;

    private void Update()
    {
        ShowValues();
    }

    void ShowValues()
    {
        P_Speed.LabelTitle.text = "Player Speed";
        P_Speed.LabelValue.text = Player.Speed.ToString();

        P_JumpForce.LabelTitle.text = "Player JumpForce";
        P_JumpForce.LabelValue.text = Player.JumpForce.ToString();

        P_AditionalJumps.LabelTitle.text = "Player AditionalJumps";
        P_AditionalJumps.LabelValue.text = Player.DefaultAdditionalJumps.ToString();

        C_Size.LabelTitle.text = "CameraSize";
        C_Size.LabelValue.text = Cam.orthographicSize.ToString();

        S_TimeBetween.LabelTitle.text = "TimeBetween Spawns";
        S_TimeBetween.LabelValue.text = Spawner.SpawnTime.ToString();
    }

    public void BTN_P_Speed_Add()
    {
        Player.Speed += 1f;
    }
    public void BTN_P_Speed_Sub()
    {
        Player.Speed -= 1f;
    }
    public void BTN_P_JumpForce_Add()
    {
        Player.JumpForce += 1f;
    }
    public void BTN_P_JumpForce_Sub()
    {
        Player.JumpForce -= 1f;
    }
    public void BTN_P_AditionalJumps_Add()
    {
        Player.DefaultAdditionalJumps += 1;
    }
    public void BTN_P_AditionalJumps_Sub()
    {
        Player.DefaultAdditionalJumps -= 1;
    }
    public void BTN_C_Size_Add()
    {
        Cam.orthographicSize += 0.2f;
    }
    public void BTN_C_Size_Sub()
    {
        Cam.orthographicSize -= 0.2f;
    }

    public void BTN_S_TimeBetween_Add()
    {
        Spawner.SpawnTime += 0.1f;
    }
    public void BTN_S_TimeBetween_Sub()
    {
        Spawner.SpawnTime -= 0.1f;
    }

}
