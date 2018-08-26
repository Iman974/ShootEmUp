using UnityEngine;

[CreateAssetMenu(fileName = "New Player Controls", menuName = "Game/Player Controls")]
public class PlayerControls : ShipControls {

    [SerializeField] private KeyCode shootKey = KeyCode.E;

    private Vector2 axesInput;

    public override void SetMovement() {
        axesInput.x = Input.GetAxisRaw("Horizontal");
        axesInput.y = Input.GetAxisRaw("Vertical");
        controller.Velocity = axesInput;
    }

    public override bool DoShoot() {
        return Input.GetKeyDown(shootKey);
    }
}
