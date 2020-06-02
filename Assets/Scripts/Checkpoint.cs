using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: reaching checkpoint will trigger shop arrival animation

public class Checkpoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ETags.Player.ToString())
        {
            print("player arrived, show shop sequence");
        }
            
    }

}

