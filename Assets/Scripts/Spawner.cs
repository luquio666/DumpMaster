using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PointA, PointB;
    public float SpawnTime = 1f;

    public GameObject[] Shapes;

    Coroutine _spawn;
    bool _enableSpawn;

    public void ButtonStart()
    {
        _enableSpawn = true;
        _spawn = StartCoroutine(Spawn());
    }
    public void ButtonEnd()
    {
        _enableSpawn = false;
        StopCoroutine(_spawn);
    }

    IEnumerator Spawn()
    {
        yield return null;
        while (_enableSpawn)
        {
            var rndShape = Shapes[Random.Range(0, Shapes.Length)];
            Vector3 v = PointB.position - PointA.position;
            Vector3 rndPos = PointA.position + Random.value * v;
            Debug.Log(rndPos);
            Instantiate(rndShape, rndPos, Quaternion.identity);

            yield return new WaitForSeconds(SpawnTime);
        }

    }

}
