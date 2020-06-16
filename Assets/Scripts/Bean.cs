using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    public SkeletonAnimation Skel;

    private void OnEnable()
    {
        //StartCoroutine(PlayAnimationCo());
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
