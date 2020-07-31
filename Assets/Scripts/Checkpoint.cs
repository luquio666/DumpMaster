using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: reaching checkpoint will trigger shop arrival animation

public class Checkpoint : MonoBehaviour
{
    public Transform FinalPosition;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ETags.Player.ToString())
        {
            print("player reached checkpoint");
            GameEvents.CheckpointReached(FinalPosition);
        }
    }

}

