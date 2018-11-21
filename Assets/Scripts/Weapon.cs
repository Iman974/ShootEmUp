using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Game/Weapon")]
public class Weapon : ScriptableObject {

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private float gravityScale = 0f;

    public float FireRate { get { return fireRate; } }

    public void SetPropertiesOfBullet(Rigidbody2D bulletRb) {
        bulletRb.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        bulletRb.gravityScale = gravityScale;
    }
}
