using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour {

    [SerializeField] private Vector2 moveSpeed = Vector2.one * 8f;
    [SerializeField] private ShipControls controls;

    private Rect movementArea;

    public Vector2 Velocity { get; set; }
    public Rigidbody2D Rb2D { get; private set; }

    private void Awake() {
        Rb2D = GetComponent<Rigidbody2D>();
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
        Rb2D.position += Velocity;
        Rb2D.position = VectorUtility.Clamp(Rb2D.position, movementArea);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(movementArea.center, movementArea.size);
    }
}
