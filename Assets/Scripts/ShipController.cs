using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour {

    [SerializeField] private float moveSpeed = 4f;

    private float angularVelocity;
    private Rigidbody2D rb2D;
    private float startRotation;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        startRotation = rb2D.rotation;
    }

    private void Update() {
        angularVelocity = Input.GetAxisRaw("Horizontal");
        angularVelocity *= moveSpeed * Time.deltaTime * Mathf.Deg2Rad;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        Vector2 newPosition = Matrix2x2.CreateRotation(-angularVelocity) * rb2D.position;
        rb2D.MovePosition(newPosition);
        transform.up = newPosition;
    }
}
