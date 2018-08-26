using UnityEngine;

public class ShipController : MonoBehaviour {

    [SerializeField] private Vector2 moveSpeed = Vector2.one * 8f;
    [SerializeField] private Rect movementArea = new Rect(-6.2f, -4.6f, 12.4f, 4.5f);
    [SerializeField] private ShipControls controls;

    private Rigidbody2D rb2D;
    private Vector2 movement;

    public Vector2 Movement { set { movement = value; } }
    //public Vector2 MoveSpeed { get { return moveSpeed; } }

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        controls.Initialize(this);
    }

    private void Start() {
        moveSpeed *= Time.fixedDeltaTime;
    }

    private void Update() {
        controls.SetMovement();
        movement *= moveSpeed;
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        rb2D.position += movement;
        rb2D.position = VectorUtility.Clamp(rb2D.position, movementArea);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(movementArea.center, movementArea.size);
    }
}
