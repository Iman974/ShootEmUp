using UnityEngine;

[CreateAssetMenu(fileName = "New Player Controls", menuName = "Game/Player Controls")]
public class PlayerControls : ShipControls {

    [SerializeField] private KeyCode shootKey = KeyCode.E;

    private ShipController controller;
    private Vector2 axesInput;

    //private Vector2 moveSpeed;

    public override void Initialize(ShipController shipController) {
        base.Initialize(shipController);

        controller = shipController;
        //moveSpeed = controller.MoveSpeed;
    }

    public override void SetMovement() {
        axesInput.x = Input.GetAxisRaw("Horizontal");
        axesInput.y = Input.GetAxisRaw("Vertical");
        //axesInput *= moveSpeed;

        controller.Movement = axesInput;
    }

    public override bool DoShoot() {
        return Input.GetKeyDown(shootKey);
    }
}
