using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Controls", menuName = "Game/Enemy Controls")]
public class EnemyControls : ShipControls {

    [SerializeField] private float fireRate = 1f;
    [Tooltip("Enemy Properties")]
    [SerializeField] private float distanceToShoot = 7f;
    [SerializeField] private float rotationSpeed = 50f;

    private float countdown;
    private float sqrDistanceToShoot;
    private Transform transform;
    private Transform playerTransform;
    private Rigidbody2D rb2D;

    public override void Initialize(ShipController shipController) {
        base.Initialize(shipController);
        sqrDistanceToShoot = distanceToShoot * distanceToShoot;
        countdown = fireRate;
        transform = controller.transform;
        playerTransform = PlayerInfo.Transform;
        rb2D = controller.GetComponent<Rigidbody2D>();
    }

    public override void SetMovement() {
        Vector2 toPlayer = playerTransform.position - transform.position;

        if (toPlayer.sqrMagnitude > sqrDistanceToShoot) {
            controller.Velocity = toPlayer.normalized;
        }
        rb2D.angularVelocity = Vector3.Cross(transform.up, toPlayer).z * rotationSpeed;
    }

    public override bool DoShoot() {
        countdown -= Time.deltaTime;

        if (countdown <= 0f) {
            countdown = fireRate;
            return true;
        }

        return false;
    }
}
