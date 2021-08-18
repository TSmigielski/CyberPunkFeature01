using UnityEngine;

public interface IEntity
{
	public CharacterController CController { get; }
	public Transform Head { get; }
	public MovementInformation ControlScheme { get; }
}
