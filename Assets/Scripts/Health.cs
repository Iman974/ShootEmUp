using UnityEngine;

public class Health : MonoBehaviour {

    private int health = 50;

    public void TakeDamage(int amount) {
        health -= amount;

        if (health <= 0) {
            if (transform.CompareTag("Enemy")) {
                EnemySpawner.OnEnemyDestroyedEvent?.Invoke(transform);
            }
            Destroy(gameObject);
        }
    }
}
