using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite[] Variations;

    [Space]

    public float MaxTorque = 50f;
    public float MinTorque = 20;

    [Space]

    public float MaxSize = 2.5f;
    public float MinSize = 1.5f;
    public float DistanceToFreeze = 10f;

    void OnEnable()
    {
        // Apply random scale
        var targetSize = Random.Range(MinSize, MaxSize);
        var curScale = this.transform.localScale;
        this.transform.localScale = new Vector3(curScale.x * targetSize, curScale.y * targetSize, curScale.z * targetSize);

        // Select random sprite variation
        if(Variations.Length >= 2)
            SR.sprite = Variations[Random.Range(0, Variations.Length)];

        // Add torque
        var targetTorque = Random.Range(MinTorque, MaxTorque);
        if (Random.Range(0, 2) == 0)
            targetTorque *= -1;

        this.GetComponent<Rigidbody2D>().AddTorque(targetTorque);
    }

    public void SetSorting(int index)
    {
        SR.sortingOrder = index;
    }

    void Update()
    {
        // Check distance below player to remove rigidbody physics
    }
}
