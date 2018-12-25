using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float distanceFromPlayer = 3f;
    [SerializeField] private BulletShooter shooter = null;
    [SerializeField] private float shootAfterAppearDelay = 0.15f;

    private float fixedDeltaTime;

    private void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void FixedUpdate() {
        if (transform.position.sqrMagnitude > distanceFromPlayer * distanceFromPlayer) {
            Move();
        }
    }

    private void Move() {
        transform.position += transform.up * moveSpeed * fixedDeltaTime;
    }

    private void OnBecameVisible() {
        StartCoroutine(StartShootingDelayed());
    }

    private System.Collections.IEnumerator StartShootingDelayed() {
        yield return new WaitForSeconds(shootAfterAppearDelay);
        shooter.enabled = true;
    }
}
