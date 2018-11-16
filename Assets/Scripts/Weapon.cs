using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Game/Weapon")]
public class Weapon : ScriptableObject {

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private int bulletPerShot = 1;
    [SerializeField] private float gravityScale = 0f;

    public float FireRate { get { return fireRate; } }
    public int BulletPerShot { get { return bulletPerShot; } }

    public void SetPropertiesOfBullet(Rigidbody2D rigidbody2D) {
        rigidbody2D.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        rigidbody2D.gravityScale = gravityScale;
    }
}
