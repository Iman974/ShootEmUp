using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour {

    [SerializeField] private Vector2 moveSpeed = Vector2.one * 8f;
    [SerializeField] private ShipControls controls;

    private Rect movementArea;
    private Rigidbody2D rb2D;

    public Vector2 Velocity { get; set; }

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        controls.Initialize(this);
    }

    private void Start() {
        moveSpeed *= Time.fixedDeltaTime;
        movementArea = GameManager.MovementArea;
    }

    private void Update() {
        controls.SetMovement();
        Velocity *= moveSpeed;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        rb2D.position += Velocity;
        rb2D.position = VectorUtility.Clamp(rb2D.position, movementArea);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(movementArea.center, movementArea.size);
    }
}
