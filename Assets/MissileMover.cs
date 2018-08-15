using UnityEngine;

public class MissileMover : MonoBehaviour {

    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        rb2D.velocity = Vector2.up * moveSpeed;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
