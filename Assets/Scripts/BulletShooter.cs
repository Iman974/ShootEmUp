using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Vector3 launchPoint = new Vector3(0.52f, 0f);
    [SerializeField] private Transform bulletContainer;

    [SerializeField] private Bullet[] bullets;

    private Bullet selectedBullet;
    private float nextFireTime;

    private void Start() {
        UnityEngine.Assertions.Assert.IsTrue(bullets.Length > 0, "Bullets array is empty!");
        selectedBullet = bullets[0];
    }

    private void Update() {
        if (Time.time >= nextFireTime) {
            Shoot();
            nextFireTime = Time.time + selectedBullet.FireRate;
        }
    }

    private void Shoot() {
        Rigidbody2D bulletRb = Instantiate(bulletPrefab, transform.position + launchPoint, Quaternion.identity, bulletContainer);
        bulletRb.AddForce(Vector2.right * selectedBullet.MoveSpeed, ForceMode2D.Impulse);
    }

    private void SwitchBullet(int bulletIndex) {
        selectedBullet = bullets[0];
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + launchPoint, 0.1f);
    }
}
