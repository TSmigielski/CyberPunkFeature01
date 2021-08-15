using UnityEngine;

[RequireComponent(typeof(IEntity))]
public class FPPController : MonoBehaviour
{
	IEntity brainz;
	Movement controls;

	//Look Around variables
	float headRotation, mouseX, mouseY;

	private void Start()
	{
		brainz = GetComponent<IEntity>();
		controls = brainz.ControlScheme;
	}

	private void FixedUpdate()
	{
		HandleMovement();
		HandleLooking();
	}

	private void HandleLooking()
	{
		mouseX = controls.LookVector.x /** Time.deltaTime*/; //Pass player look input to a private value
		mouseY = controls.LookVector.y /** Time.deltaTime*/; //Pass player look input to a private value

		headRotation -= mouseY;
		headRotation = Mathf.Clamp(headRotation, controls.HeadRotationClamps.y, controls.HeadRotationClamps.x);

		transform.Rotate(Vector3.up * mouseX);
		brainz.Head.localRotation = Quaternion.Euler(headRotation, 0f, 0f);
	}

	private void HandleMovement()
	{
		if (controls.MovementVector == Vector2.zero) //If there is no Input from the player
			return;									 //Exit the method

		var mag = brainz.RB.velocity.magnitude; //Save the magnitude value for easier use later
		Vector2 velocity;

		if (controls.MovementVector.y < 0 || controls.MovementVector.y == 0) //If player wants to move backwards, or sideways
			controls.IsSprinting = false;									 //Disable the option to sprint

		if (!controls.IsSprinting)                                      //If player is not sprinting
			velocity = controls.MovementVector * controls.Acceleration; //Multiply direction with normal acceleration
		else																  //If he is sprinting
			velocity = controls.MovementVector * controls.SprintAcceleration; //Multiply direction with sprinting acceleration

		if (!controls.IsGrounded) //If player is not on the ground
		{
			brainz.RB.AddRelativeForce(new Vector3(velocity.x * controls.InAirMultiplier, 0, velocity.y * controls.InAirMultiplier)); //Apply the directed acceleration multiplied by the inAirMultiplier
			return; //And exit the method
		}

		brainz.RB.AddRelativeForce(new Vector3(velocity.x, 0, velocity.y)); //Apply the directed acceleration

		if (!controls.IsSprinting && mag > controls.MaxSpeed)						      //If player is not sprinting and his theoritical current speed is greater than his maximum speed
			brainz.RB.velocity = brainz.RB.velocity.normalized * controls.MaxSpeed;	      //Cap his speed to his max speed
		else if (controls.IsSprinting && mag > controls.MaxSprintSpeed)                   //If player is sprinting and his theoritical current speed is greater than his maximum sprinting speed
			brainz.RB.velocity = brainz.RB.velocity.normalized * controls.MaxSprintSpeed; //Cap his speed to his max sprinting speed
	}

	public void PerformJump()
	{
		if (!controls.IsGrounded) //If player is not on the ground
			return;				  //Exit the method

		controls.IsGrounded = false; //Set the grouded value to false
		brainz.RB.AddForce(new Vector3(0, controls.JumpForce, 0), ForceMode.VelocityChange); //Add upward force to the player
	}
}
