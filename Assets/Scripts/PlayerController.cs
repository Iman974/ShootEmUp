using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField] private Vector2 moveSpeed = Vector2.one * 8f;
    [SerializeField] private Rect limit = new Rect(-6.2f, -4.6f, 12.4f, 4.5f);

    private Rigidbody2D rb2D;
    private bool doMove;
    private Vector2 axesInput;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        moveSpeed *= Time.fixedDeltaTime;
    }

    private void Update() {
        axesInput.x = Input.GetAxisRaw("Horizontal");
        axesInput.y = Input.GetAxisRaw("Vertical");

        if (axesInput != Vector2.zero) {
            axesInput.x *= moveSpeed.x;
            axesInput.y *= moveSpeed.y;
            doMove = true;
        } else {
            doMove = false;
        }
    }

    private void FixedUpdate() {
        if (!doMove) {
            return;
        }

        rb2D.position += axesInput;
        rb2D.position = VectorUtility.Clamp(rb2D.position, limit);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(limit.center, limit.size);
        // test
    }
}
