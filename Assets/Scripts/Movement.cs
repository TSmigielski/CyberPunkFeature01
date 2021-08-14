using UnityEngine;

public class Movement
{
	public Vector2 MovementVector { get; set; }
	public Vector2 LookVector { get; set; }
	public float Acceleration { get; set; }
	public float SprintAcceleration { get; set; }
	public float MaxSpeed { get; set; }
	public float MaxSprintSpeed { get; set; }
	public float InAirMultiplier { get; set; }
	public float JumpForce { get; set; }
	public Vector2 HeadRotationClamps { get; set; }
	public bool IsSprinting { get; set; }
	public bool IsGrounded { get; set; }
}
