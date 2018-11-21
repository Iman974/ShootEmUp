using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Vector3 launchPoint = new Vector3(0.52f, 0f);
    [SerializeField] private Weapon[] weapons;

    private Weapon selectedWeapon;
    private float nextFireTime;

    private void Start() {
        UnityEngine.Assertions.Assert.IsTrue(weapons.Length > 0, "Bullets array is empty!");
        selectedWeapon = weapons[0];
    }

    private void Update() {
        if (Time.time < nextFireTime) {
            return;
        }

        Shoot();
        nextFireTime = Time.time + selectedWeapon.FireRate;
    }

    private void Shoot() {
        Rigidbody2D bulletRb = BulletPool.GetAvailableBullet();
        bulletRb.transform.position = transform.position + launchPoint;
        selectedWeapon.SetPropertiesOfBullet(bulletRb);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + launchPoint, 0.1f);
    }
}
