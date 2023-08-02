using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ghrostPrefab;


    [SerializeField]
    private float ghrostInterval = 3.5f;
  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(ghrostInterval, ghrostPrefab));
       
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-5f, 5), UnityEngine.Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}