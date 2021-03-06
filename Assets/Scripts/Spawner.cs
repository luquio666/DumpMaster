﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PointA, PointB;
    public float SpawnTime = 1f;
    public int SortIndex = -1;

    [Space]

    public GameObject[] Shapes;

    Coroutine _spawnCo;
    bool _spawnEnabled;

    private void Start()
    {
        StartSpawn();
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
            // reduce the sorting
            SortIndex--;

            // Find rnd position
            var rndShape = Shapes[Random.Range(0, Shapes.Length)];
            Vector3 v = PointB.position - PointA.position;
            Vector3 rndPos = PointA.position + Random.value * v;
            
            var go = Instantiate(rndShape, rndPos, Quaternion.identity);
            var shapes = go.GetComponentInChildren<Shapes>();
            shapes.SetSorting(SortIndex);

            // Wait for next one
            yield return new WaitForSeconds(SpawnTime);
        }

    }

}
