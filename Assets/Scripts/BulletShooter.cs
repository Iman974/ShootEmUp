using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Vector3 launchPoint = new Vector3(0.52f, 0f);
    [SerializeField] private Transform bulletContainer;

    [SerializeField] private Weapon[] weapons;

    private Weapon selectedWeapon;
    private float nextFireTime;

    private void Start() {
        if (weapons.Length == 0) {
            Debug.LogError("Bullets array is empty!");
            enabled = false;
        }
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
        Rigidbody2D[] rb2Ds = new Rigidbody2D[selectedWeapon.BulletPerShot];
        for (int i = 0; i < selectedWeapon.BulletPerShot; i++) {
            rb2Ds[i] = Instantiate(bulletPrefab, transform.position + launchPoint, Quaternion.identity, bulletContainer);
        }
        selectedWeapon.SetPropertiesOfBullets(rb2Ds);
    }

    private void SwitchBullet(int bulletIndex) {
        selectedWeapon = weapons[0];
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + launchPoint, 0.1f);
    }
}
