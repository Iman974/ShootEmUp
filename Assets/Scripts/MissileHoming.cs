using UnityEngine;

public class MissileHoming : MissileMover {

    [SerializeField] private float homingStartDistance = 5f;
    [SerializeField] private float homingForce = 1f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 moveDirection;

    public Transform Target { get { return target; } }

    private void Start() {
        homingStartDistance *= homingStartDistance;
        target.hasChanged = false;
    }

    protected override void Move() {
        //if (target.hasChanged) {
        //    UpdateTargetPosition();
        //}

        if ((rb2D.position - (Vector2)target.position).sqrMagnitude <= homingStartDistance) {
            moveDirection = Vector2.MoveTowards((rb2D.position + moveDirection).normalized,
                ((Vector2)target.position - rb2D.position).normalized, homingForce);
        }

        rb2D.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    private void UpdateTargetPosition() {
        //targetPosition = (rb2D.position - (Vector2)target.position).normalized;
    }
}