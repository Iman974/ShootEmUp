using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Controls", menuName = "Game/Enemy Controls")]
public class EnemyControls : ShipControls {

    [SerializeField] private float fireRate = 1f;
    [SerializeField] private Vector2[] waypoints;
    [SerializeField] private float maxDistanceDelta = 0.1f;

    private float countdown;
    private int currentWayPoint;

    private void OnEnable() {
        countdown = fireRate;
    }

    public override void SetMovement() {
        if (((Vector2)controller.transform.position - waypoints[currentWayPoint]).sqrMagnitude <= maxDistanceDelta) {
            controller.Velocity = waypoints[currentWayPoint];
        }
    }

    public override bool DoShoot() {
        countdown -= Time.deltaTime;

        if (countdown <= 0f) {
            countdown = fireRate;
            return true;
        }

        return false;
    }
}
