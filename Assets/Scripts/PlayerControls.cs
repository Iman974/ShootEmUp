using UnityEngine;

[CreateAssetMenu(fileName = "New Player Controls", menuName = "Game/Player Controls")]
public class PlayerControls : ShipControls {

    [SerializeField] private KeyCode shootKey = KeyCode.E;
    [SerializeField] private KeyCode rotateClockwiseKey = KeyCode.E;
    [SerializeField] private KeyCode rotateCounterclockwiseKey = KeyCode.A;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] [Range(0f, 1f)] private float acceleration = 0.2f;

    private Vector2 axesInput;
    private Rigidbody2D rb2D;
    private float moveSpeed;

    public override void Initialize(ShipController shipController) {
        base.Initialize(shipController);
        rb2D = controller.GetComponent<Rigidbody2D>();
    }

    public override void SetMovement() {
        axesInput.x = Input.GetAxisRaw("Horizontal");
        axesInput.y = Input.GetAxisRaw("Vertical");
        if (axesInput != Vector2.zero) {
            moveSpeed = Mathf.MoveTowards(moveSpeed, 1f, acceleration);
            controller.Velocity = axesInput * moveSpeed;
        } else {
            moveSpeed = 0f;
        }

        if (Input.GetKey(rotateClockwiseKey)) {
            rb2D.rotation += rotationSpeed;
        } else if (Input.GetKey(rotateCounterclockwiseKey)) {
            rb2D.rotation -= rotationSpeed;
        }
    }

    public override bool DoShoot() {
        return Input.GetKeyDown(shootKey);
    }
}
