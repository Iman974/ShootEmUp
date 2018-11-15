using UnityEngine;

[CreateAssetMenu(fileName = "New bullet", menuName = "Game/Bullet")]
public class Bullet : ScriptableObject {

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float fireRate = 5f;

    public float MoveSpeed { get { return moveSpeed; } }
    public float FireRate { get { return fireRate; } }
}
