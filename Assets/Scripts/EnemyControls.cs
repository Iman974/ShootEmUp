using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Controls", menuName = "Game/Enemy Controls")]
public class EnemyControls : ShipControls {

    [SerializeField] private float fireRate = 1f;
    [Tooltip("Enemy Properties")]
    [SerializeField] private float distanceToShoot = 7f;
    [SerializeField] private float rotationSpeed = 50f;
    //[SerializeField] [Range(0f, 359.99f)] private float shootAngle = 359.99f; // actually, it is the x absolute distance from the target
    //[SerializeField] private float slowDownSpeed = 0.2f;

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
        rb2D = controller.Rb2D;
    }

    public override void SetMovement() {
        Vector2 toPlayer = playerTransform.position - transform.position;

        if (toPlayer.sqrMagnitude > sqrDistanceToShoot) {
            controller.Velocity = toPlayer.normalized;
        } else {
            //Debug.Log(controller.Velocity);
            //controller.Velocity = Vector2.MoveTowards(controller.Velocity, Vector2.zero, slowDownSpeed);
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
