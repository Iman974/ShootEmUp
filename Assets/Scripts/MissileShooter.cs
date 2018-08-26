using UnityEngine;

public class MissileShooter : MonoBehaviour {

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchTransform;
    [SerializeField] private ShipControls controls;

    public Quaternion ShootDirection { get; set; }

    private void Start() {
        ShootDirection = Quaternion.identity;
    }

    private void Update() {
        if (controls.DoShoot()) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(missilePrefab, launchTransform.position, ShootDirection);
    }
}
