using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
	public Rigidbody RB { get; private set; }

	PlayerControls controls;

	[SerializeField] float playerAcceleration, playerSprintAcceleration, maxSpeed, maxSprintSpeed, jumpForce;
	[SerializeField] bool isSprinting;

	private void Awake()
	{
		RB = GetComponent<Rigidbody>();  //Reference Rigidbody to the property
		controls = new PlayerControls(); //Instantiate the controls
	}

	private void OnEnable()
	{
		controls.Enable();												  //Enable the controls
		controls.Player.Sprint.started += _ => { isSprinting = true; };	  //Subscribe to the sprint start event, and set the value
		controls.Player.Sprint.canceled += _ => { isSprinting = false; }; //Subscribe to the sprint stop event, and set the value
		controls.Player.Jump.performed += _ => HandleJump();			  //Subscribe to the jump event, and handle it
	}

	private void OnDisable()
	{
		controls.Player.Sprint.started -= _ => { isSprinting = true; };	  //Unsubscribe the sprint start event
		controls.Player.Sprint.canceled -= _ => { isSprinting = false; }; //Unsubscribe the sprint stop event
		controls.Player.Jump.performed -= _ => HandleJump();              //Unubscribe the jump event
		controls.Disable();                                               //Disable the controls
	}

	private void FixedUpdate()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		var playerInput = controls.Player.Movement.ReadValue<Vector2>(); //Save the player input value for easier use later
		if (playerInput == Vector2.zero) //If there is no Input from the player
			return;						 //Exit the method

		var mag = RB.velocity.magnitude; //Save the magnitude value for easier use later
		Vector2 velocity;

		if (playerInput.y < 0 || playerInput.y == 0) //If player wants to move backwards, or sideways
			isSprinting = false;                     //Disable the option to sprint

		if (!isSprinting)									   //If player is not sprinting
			velocity = playerInput * playerAcceleration;	   //Multiply direction with normal acceleration
		else                                                   //If he is sprinting
			velocity = playerInput * playerSprintAcceleration; //Multiply direction with sprinting acceleration

		RB.AddForce(new Vector3(velocity.x, 0, velocity.y)); //Apply the directed acceleration

		if (!isSprinting && mag > maxSpeed)						   //If player is not sprinting and his theoritical current speed is greater than his maximum speed
			RB.velocity = RB.velocity.normalized * maxSpeed;	   //Cap his speed to his max speed
		else if (isSprinting && mag > maxSprintSpeed)              //If player is sprinting and his theoritical current speed is greater than his maximum sprinting speed
			RB.velocity = RB.velocity.normalized * maxSprintSpeed; //Cap his speed to his max sprinting speed
	}

	private void HandleJump()
	{
		RB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //Add upward force to the player
	}
}
