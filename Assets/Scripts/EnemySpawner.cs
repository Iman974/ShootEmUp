using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] [Min(0f)] private float minSpawnDistance = 5f;
    [SerializeField] [Min(0f)] private float maxSpawnDistance = 10f;
    [SerializeField] [Min(0f)] private int testFrequency = 10;
    [SerializeField] [Range(0f, 1f)] private float triggerProbability = 0.1f;
    [SerializeField] private int maxEnemiesOnScreen = 4;
    [SerializeField] [Range(0f, 1f)] private float clearSightLineTolerance = 0.95f;

    private float testPeriod;
    private List<Transform> spawnDirections = new List<Transform>(); // Using raycasting for this might be possible

    public static System.Action<Transform> OnEnemyDestroyedEvent;

    private void Start() {
        testPeriod = 1f / testFrequency;
        StartCoroutine(TrySpawnEnemy());
        OnEnemyDestroyedEvent += OnEnemyDestroyed;
    }

    private IEnumerator TrySpawnEnemy() {
        while (true) {
            if (Random.value <= triggerProbability && spawnDirections.Count < maxEnemiesOnScreen) {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(testPeriod);
        }
    }

    private void SpawnEnemy() {
        Vector2 unitVector;
        int i = 0;
        do {
            unitVector = Random.insideUnitCircle.normalized;
            if (++i > 15) {
                Debug.LogError("Empty spot for spawning could not be found!");
                return;
            } /*else if (i > 1) Debug.LogWarning("Regenerated spawn direction.");*/
        } while (spawnDirections.Exists(t => Vector2.Dot(t.position.normalized, unitVector) >= clearSightLineTolerance));
        Vector2 spawnPosition = unitVector * Random.Range(minSpawnDistance, maxSpawnDistance);
        //Debug.DrawRay(Vector3.zero, unitVector, Color.red, 1.5f);

        Transform newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform).transform;
        spawnDirections.Add(newEnemy);
        newEnemy.up = -spawnPosition;
    }

    private void OnEnemyDestroyed(Transform enemyTransform) {
        spawnDirections.Remove(enemyTransform);
    }

    private void OnDestroy() {
        OnEnemyDestroyedEvent -= OnEnemyDestroyed;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(0.75f, 0.25f, 0f);
        Gizmos.DrawWireSphere(Vector3.zero, minSpawnDistance);
        Gizmos.DrawWireSphere(Vector3.zero, maxSpawnDistance);
    }
}
