using UnityEngine;

public class MissileShooter : MonoBehaviour {

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchTransform;
    [SerializeField] private ShipControls controls;

    private void Update() {
        if (controls.DoShoot()) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(missilePrefab, launchTransform.position, transform.rotation);
    }
}
