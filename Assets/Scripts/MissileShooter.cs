using UnityEngine;

public class MissileShooter : MonoBehaviour {

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private KeyCode shootKey = KeyCode.E;
    [SerializeField] private Transform launchTransform;

    private void Update() {
        if (Input.GetKeyDown(shootKey)) {
            Instantiate(missilePrefab, launchTransform.position, Quaternion.identity);
        }
    }
}
