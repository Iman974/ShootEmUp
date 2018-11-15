using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour {

    [SerializeField] private Vector2 moveSpeed = Vector2.one * 6f;

    private Vector2 velocity;

    private void Update() {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity *= moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        transform.position += (Vector3)velocity;
    }
}
