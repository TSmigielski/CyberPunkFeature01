using UnityEngine;

public interface IEntity
{
	public CharacterController CController { get; }
	public MovementInformation ControlScheme { get; }
}
