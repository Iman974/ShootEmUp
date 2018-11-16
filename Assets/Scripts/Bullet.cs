using UnityEngine;

[CreateAssetMenu(fileName = "New bullet", menuName = "Game/Bullet")]
public class Bullet : ScriptableObject {

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float gravityScale = 0f;

    public float GravityScale { get { return gravityScale; } }
    public float BulletSpeed { get { return bulletSpeed; } }
}
