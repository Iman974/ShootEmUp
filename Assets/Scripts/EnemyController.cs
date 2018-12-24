using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private float moveSpeed = 1f;

    private float fixedDeltaTime;

    private void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void FixedUpdate() {
        Vector3 pos = transform.position;
        transform.position += new Vector3(-moveSpeed * fixedDeltaTime, 0f);
    }
}
