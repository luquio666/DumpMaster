using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform TargetToFollow;

    public float Speed = 5f;
    public float Offset = 2f;

    public bool EnableFollow = true;

    public bool SmoothFollow = true;
    

    void Update()
    {
        if (EnableFollow)
        {
            if (SmoothFollow)
                ApplySmoothFollow();
            else
                ApplyFollow();
        }
    }

    void ApplySmoothFollow()
    {
        var target = new Vector3(TargetToFollow.position.x, TargetToFollow.position.y + Offset, 0);
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }

    void ApplyFollow()
    {
        transform.position = TargetToFollow.position;
    }

}
