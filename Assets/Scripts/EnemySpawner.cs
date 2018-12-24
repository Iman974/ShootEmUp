using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] [Min(0f)] private float minSpawnDistance = 5f;
    [SerializeField] [Min(0f)] private float maxSpawnDistance = 10f;
    [SerializeField] [Min(0f)] private int testFrequency = 10;
    [SerializeField] [Range(0f, 1f)] private float triggerProbability = 0.1f;

    private float testPeriod;

    private void Start() {
        testPeriod = 1f / testFrequency;
        StartCoroutine(TrySpawnEnemy());
    }

    private IEnumerator TrySpawnEnemy() {
        while (true) {
            if (Random.value <= triggerProbability) {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(testPeriod);
        }
    }

    private void SpawnEnemy() {
        Vector2 spawnPosition = (Vector2)Random.onUnitSphere * Random.Range(minSpawnDistance, maxSpawnDistance);
        Transform newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform).transform;
        newEnemy.up = -spawnPosition;
    }
}
