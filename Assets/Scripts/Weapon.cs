using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Game/Weapon")]
public class Weapon : ScriptableObject {

    [SerializeField] private Bullet[] bullets;
    [SerializeField] private float fireRate = 0.15f;

    public float FireRate { get { return fireRate; } }
    public int BulletPerShot { get { return bullets.Length; } }

    public void SetPropertiesOfBullets(Rigidbody2D[] bulletRigidbodies) {
        for (int i = 0; i < bulletRigidbodies.Length; i++) {
            bulletRigidbodies[i].AddForce(Vector2.right * bullets[i].BulletSpeed, ForceMode2D.Impulse);
            bulletRigidbodies[i].gravityScale = bullets[i].GravityScale;
        }
    }
}
