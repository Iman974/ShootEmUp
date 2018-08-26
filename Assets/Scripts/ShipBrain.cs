using UnityEngine;

public abstract class ShipControls : ScriptableObject {

	public virtual void Initialize(ShipController shipController) { }
    public abstract void SetMovement();
    public abstract bool DoShoot();
}
