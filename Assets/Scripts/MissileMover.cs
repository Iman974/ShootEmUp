using UnityEngine;

public abstract class MissileMover : MonoBehaviour {

    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected Vector2 moveDirection = new Vector2(0f, 1f);

    protected Rigidbody2D rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start() {
        moveDirection.Normalize();
    }

    private void FixedUpdate() {
        Move();
    }

    protected virtual void Move() {
        rb2D.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
