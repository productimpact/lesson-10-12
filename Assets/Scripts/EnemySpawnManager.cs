using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnFrequency;
    public bool playerIsAlive = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (playerIsAlive)
        {
            float xPosition = Random.Range(-2, 2);
            float yPosition = 7;
            Vector2 spawnPosition = new Vector2(xPosition, yPosition);

            yield return new WaitForSeconds(spawnFrequency);

            Instantiate(enemy, spawnPosition, Quaternion.identity);

        }
    }
}
