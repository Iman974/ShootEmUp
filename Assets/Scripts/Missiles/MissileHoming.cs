using UnityEngine;

public class MissileHoming : MissileMover {

    [SerializeField] private float homingStartDistance = 5f;
    [SerializeField] private float rotationSpeed = 1f;

    private Transform target;
    private bool doTargetDetection = true;
    private LayerMask enemyLayer;
    private Vector2 toTarget;
    private float homingStartTime;

    protected override void Start() {
        base.Start();
        enemyLayer = GameManager.GameData.enemyLayer;
        rb2D.velocity = moveDirection * moveSpeed;
    }

    protected override void Move() {
        if (doTargetDetection) {
            Collider2D enemyCollider = Physics2D.OverlapCircle(transform.position, homingStartDistance, enemyLayer);

            if (enemyCollider) {
                target = enemyCollider.transform;
                doTargetDetection = false;
            }
        } else {
            toTarget = ((Vector2)target.position - rb2D.position).normalized; // Is .Normalize() faster ?
            rb2D.angularVelocity = Vector3.Cross(transform.up, toTarget).z * rotationSpeed;
            rb2D.velocity = transform.up;
        }

        base.Move();
    }
}