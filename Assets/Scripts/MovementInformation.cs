using UnityEngine;

public class MovementInformation
{
	public Vector2 MovementVector { get; set; }
	public float Speed { get; set; }
	public float SprintSpeed { get; set; }
	public float JumpHeight { get; set; }
	public Vector2 HeadRotationClamps { get; set; }
	public bool IsSprinting { get; set; }
}
