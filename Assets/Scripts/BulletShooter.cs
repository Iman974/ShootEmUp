using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Transform launchPoint = null;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private float speed = 2f;
    [SerializeField] public bool isEnemy = true;

    private float nextFireTime;
    private Rigidbody2D selfRb2D;

    private void Start() {
        selfRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!isEnemy && !Input.GetKeyDown(KeyCode.E)) {
            return;
        }
        if (Time.time < nextFireTime) {
            return;
        }

        Shoot();
        nextFireTime = Time.time + fireRate;
    }

    private void Shoot() {
        Rigidbody2D bulletRb = isEnemy ? BulletPool.GetEnemyBullet() : BulletPool.GetPlayerBullet();
        bulletRb.position = launchPoint.position;
        bulletRb.transform.right = transform.up;
        bulletRb.velocity = transform.up * speed;
    }

    private void OnDrawGizmos() {
        if (launchPoint == null) {
            return;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(launchPoint.position, 0.07f * transform.localScale.x);
    }
}
