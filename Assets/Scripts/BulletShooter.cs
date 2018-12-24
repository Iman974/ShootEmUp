using UnityEngine;

public class BulletShooter : MonoBehaviour {

    [SerializeField] private Transform launchPoint;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private float speed = 2f;
    //[SerializeField] private Weapon[] weapons;

    //private Weapon selectedWeapon;
    private float nextFireTime;
    private Rigidbody2D selfRb2D;

    private void Start() {
        //UnityEngine.Assertions.Assert.IsTrue(weapons.Length > 0, "Bullets array is empty!");
        //selectedWeapon = weapons[0];
        selfRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Time.time < nextFireTime) {
            return;
        }

        Shoot();
        nextFireTime = Time.time + fireRate;
    }

    private void Shoot() {
        Rigidbody2D bulletRb = BulletPool.GetAvailableBullet();

        float rotation = ShipController.Rotation;
        bulletRb.position = launchPoint.position;
        bulletRb.rotation = rotation;
        bulletRb.velocity = selfRb2D.position * speed;
    }

    private void OnDrawGizmos() {
        if (launchPoint == null) {
            return;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(launchPoint.position, 0.07f * transform.localScale.x);
    }
}
