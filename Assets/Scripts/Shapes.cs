using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite[] Variations;

    public GameObject PFX;

    [Space]

    public float MaxTorque = 50f;
    public float MinTorque = 20;

    [Space]

    public float MaxSize = 2.5f;
    public float MinSize = 1.5f;

    bool _pfxAlreadyPlayed = false;

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

    private void OnCollisionEnter2D(Collision2D col)
    {
        PlayParticles();
    }

    void PlayParticles()
    {
        if (!_pfxAlreadyPlayed)
        {
            _pfxAlreadyPlayed = true;
            PFX.SetActive(true);
        }
    }

    public void SetSorting(int index)
    {
        SR.sortingOrder = index;
    }
}
