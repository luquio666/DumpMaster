using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PointA, PointB;
    public float SpawnTime = 1f;
    public float MaxTorque = 10f;
    public float MinTorque = 0;

    [Space]

    public GameObject[] Shapes;

    Coroutine _spawnCo;
    bool _spawnEnabled;

    public void ButtonStart()
    {
        StartSpawn();
    }
    public void ButtonEnd()
    {
        EndSpawn();
    }

    void StartSpawn()
    {
        if (_spawnEnabled == false)
        {
            _spawnEnabled = true;
            _spawnCo = StartCoroutine(SpawnCo());
        }
    }
    void EndSpawn()
    {
        if (_spawnEnabled == true)
        {
            _spawnEnabled = false;
            StopCoroutine(_spawnCo);
        }
    }

    IEnumerator SpawnCo()
    {
        yield return null;
        while (_spawnEnabled)
        {
            // Find rnd position
            var rndShape = Shapes[Random.Range(0, Shapes.Length)];
            Vector3 v = PointB.position - PointA.position;
            Vector3 rndPos = PointA.position + Random.value * v;

            // Add torque
            var targetTorque = Random.Range(MinTorque, MaxTorque);
            if (Random.Range(0, 2) == 0)
                targetTorque *= -1;

            var shape = Instantiate(rndShape, rndPos, Quaternion.identity);
            shape.GetComponent<Rigidbody2D>().AddTorque(targetTorque);

            // Wait for next one
            yield return new WaitForSeconds(SpawnTime);
        }

    }

}
