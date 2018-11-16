using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Vector3 launchPoint = new Vector3(0.52f, 0f);
    [SerializeField] private Transform bulletContainer;

    [SerializeField] private Weapon[] bullets;

    private Weapon selectedWeapon;
    private float nextFireTime;

    private void Start() {
        UnityEngine.Assertions.Assert.IsTrue(bullets.Length > 0, "Bullets array is empty!");
        selectedWeapon = bullets[0];
    }

    private void Update() {
        if (Time.time < nextFireTime) {
            return;
        }

        Shoot();
        nextFireTime = Time.time + selectedWeapon.FireRate;
    }

    private void Shoot() {
        Rigidbody2D bulletRb = Instantiate(bulletPrefab, transform.position + launchPoint, Quaternion.identity, bulletContainer);
        selectedWeapon.SetPropertiesOfBullet(bulletRb);
    }

    private void SwitchBullet(int bulletIndex) {
        selectedWeapon = bullets[0];
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + launchPoint, 0.1f);
    }
}
