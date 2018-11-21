using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    new private Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnBecameInvisible() {
        BulletPool.ReleaseBullet(rigidbody2D);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // Check for ennemy vessel
    }
}
