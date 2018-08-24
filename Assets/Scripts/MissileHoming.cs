using UnityEngine;

public class MissileHoming : MissileMover {

    [SerializeField] private float homingStartDistance = 5f;
    [SerializeField] private float homingIntensity = 0.2f;

    private Transform target;
    private bool doTargetDetection = true;
    private LayerMask enemyLayer;
    private Vector2 directionToTarget;

    protected override void Start() {
        base.Start();
        enemyLayer = GameManager.GameData.enemyLayer;

        //Vector2 current = Vector2.up;
        //Vector2 targetB = Vector2.right;

        //for (int i = 0; i < 8; i++) {
        //    current = Vector2.MoveTowards(current, targetB, 0.25f).normalized;
        //    Debug.Log(current + ", magnitude: " + current.magnitude);
        //}
    }

    protected override void Move() {
        if (doTargetDetection) {
            Collider2D enemyCollider = Physics2D.OverlapCircle(transform.position, homingStartDistance, enemyLayer);

            if (enemyCollider != null) {
                 target = enemyCollider.transform;
                doTargetDetection = false;
                directionToTarget = ((Vector2)target.position - rb2D.position).normalized;
            }
        } else {
            moveDirection = Vector2.MoveTowards(moveDirection, directionToTarget, homingIntensity).normalized;
        }

        base.Move();
    }
}