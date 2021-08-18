using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IEntity))]
public class MovementController : MonoBehaviour
{
	IEntity brainz;
	MovementInformation controls;

	Vector3 verticalVelocity;
	bool jump;

	private void Start()
	{
		brainz = GetComponent<IEntity>();
		controls = brainz.ControlScheme;
	}

	private void Update()
	{
		HandleMoving();
		HandleGravity();
		Debug.Log(brainz.CController.isGrounded);
	}

	private void HandleMoving()
	{
		Vector3 motion = (brainz.CController.transform.right * controls.MovementVector.x) + (brainz.CController.transform.forward * controls.MovementVector.y); //Allign player input with character rotation

		if (controls.MovementVector.y < 0 || controls.MovementVector.y == 0) //If player wants to move backwards, or sideways
			controls.IsSprinting = false; //Disable the option to sprint

		motion *= (controls.IsSprinting ? controls.SprintSpeed : controls.Speed) * Time.deltaTime; //Multiply input by sprint speed or regular speed and deltaTime
		brainz.CController.Move(motion); //Apply motion to the controller
	}

	private void HandleGravity()
	{
		if (brainz.CController.isGrounded && !jump) //If character is grounded & not jumping
		{
			verticalVelocity = Vector3.zero; //Reset vertical velocity
			return; //And exit the method
		}
		else if (jump) // If the is jumping
			verticalVelocity.y = Mathf.Sqrt(controls.JumpHeight * -2 * Physics.gravity.y); //Add upward vertical velocity

		verticalVelocity += Physics.gravity * Time.deltaTime;		//Simulate gravity
		brainz.CController.Move(verticalVelocity * Time.deltaTime); //Add the force to the character
		jump = false;
	}

	public void PerformJump()
	{
		if (brainz.CController.isGrounded) //If character is grounded
			jump = true; //Set jump to true
	}
}
