using UnityEngine;

public abstract class ShipControls : ScriptableObject {

    protected ShipController controller;

    public virtual void Initialize(ShipController shipController) {
        controller = shipController;
    }
    public abstract void SetMovement();
    public abstract bool DoShoot();
}
