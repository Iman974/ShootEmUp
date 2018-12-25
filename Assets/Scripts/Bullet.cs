using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    new private Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            //Implement player collision here (lower health)
        } else if (other.CompareTag("Enemy")) {
            //Handle enemy health (multiple shots to kill it) later
            EnemySpawner.OnEnemyDestroyedEvent?.Invoke(other.transform);
            Destroy(other.gameObject);
        }
    }
}
