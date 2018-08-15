using UnityEngine;

public class PlayerController : MonoBehaviour {

    [System.Serializable]
    private struct Limits {

        [SerializeField] private float minX;
        public float MinX { get { return minX; } }

        [SerializeField] private float maxX;
        public float MaxX { get { return maxX; } }

        [SerializeField] private float minY;
        public float MinY { get { return minY; } }

        [SerializeField] private float maxY;
        public float MaxY { get { return maxY; } }

        public Limits(float minX, float maxX, float minY, float maxY) {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }
    }

    [SerializeField] private Vector2 moveSpeed = Vector2.one * 8f;
    [SerializeField] private Limits limits = new Limits(-5f, 5f, -6f, 1f);

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
        rb2D.position = VectorUtility.Clamp(rb2D.position, limits.MinX, limits.MaxX, limits.MinY, limits.MaxY);
    }
}
