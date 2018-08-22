using UnityEngine;

public class MissileDirected : MissileMover {

    [SerializeField] private Vector2 moveDirection = new Vector2(0f, 1f);

    private void Start() {
        moveDirection.Normalize();
    }

    protected override void Move() {
        rb2D.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
    }
}