using UnityEngine;

public interface IEntity
{
	public Rigidbody RB { get; }
	public Collider CL { get; }
	public Transform Head { get; }
	public Movement ControlScheme { get; }
}
