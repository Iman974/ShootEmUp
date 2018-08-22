using UnityEngine;

public abstract class MissileMover : MonoBehaviour {

    [SerializeField] protected float moveSpeed = 5f;

    protected Rigidbody2D rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Move();
    }

    protected abstract void Move();

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
