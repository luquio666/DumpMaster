using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grub : MonoBehaviour
{
    public SkeletonAnimation Skel;
    public bool FlipAuto = true;

    private void Start()
    {
        FlipAutoByPosition();
        StartCoroutine(PlayAnimationCo());
    }

    void FlipAutoByPosition()
    {
        if (FlipAuto)
        {
            if (this.transform.position.x > 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (this.transform.position.x < 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void Destroy()
    {
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

    IEnumerator PlayAnimationCo()
    {
        while (this.gameObject.activeInHierarchy)
        {
            if (Random.Range(0, 2) == 0)
            {
                Skel.AnimationState.SetAnimation(0, "idle", false).TrackEnd = float.PositiveInfinity;
                yield return new WaitForSeconds(1.667f);
            }
            else
            {
                Skel.AnimationState.SetAnimation(0, "idle2", false).TrackEnd = float.PositiveInfinity;
                yield return new WaitForSeconds(1.667f);
            }
            
        }
        yield return null;
    }

}
