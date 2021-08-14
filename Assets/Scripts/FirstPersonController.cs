using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
	public Rigidbody RB { get; private set; }
	public Collider CL { get; private set; }

	PlayerControls controls;

	//Movement variables
	Vector2 movementVector;

	//Look Around variables
	float headRotation, mouseX, mouseY;
	Vector2 mouseDelta;

	[Header("Objects/Components")]
	[SerializeField] Transform head;

	[Header("Values")]
	[SerializeField] float playerAcceleration;
	[SerializeField] float playerSprintAcceleration;
	[SerializeField] float maxSpeed;
	[SerializeField] float maxSprintSpeed;
	[SerializeField] float inAirMultiplier;
	[SerializeField] float jumpForce;
	[SerializeField] Vector2 headRotationClamps;
	[SerializeField] bool isSprinting;
	[SerializeField] bool isGrounded;

	private void Awake()
	{
		RB = GetComponent<Rigidbody>();  //Reference Rigidbody to the property
		CL = GetComponent<Collider>();   //Reference Collider to the property
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

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.layer.Equals(StaticData.Instance.GroundLayer)) //If player collides with a object on the ground layer
			isGrounded = true;													 //Set the grounded value to true
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void FixedUpdate()
	{
		HandleMovement();
		HandleLooking();
	}

	private void Update()
	{
		HandlePlayerInput();
	}

	private void HandlePlayerInput()
	{
		movementVector = controls.Player.Movement.ReadValue<Vector2>();

		mouseDelta = controls.Player.LookAround.ReadValue<Vector2>();
		mouseX = mouseDelta.x * PlayerSettings.Instance.MouseSensitivity;
		mouseY = mouseDelta.y * PlayerSettings.Instance.MouseSensitivity;
	}

	private void HandleLooking()
	{
		headRotation -= mouseY;
		headRotation = Mathf.Clamp(headRotation, headRotationClamps.y, headRotationClamps.x);

		transform.Rotate(Vector3.up * mouseX);
		head.localRotation = Quaternion.Euler(headRotation, 0f, 0f);
	}

	private void HandleMovement()
	{
		if (movementVector == Vector2.zero) //If there is no Input from the player
			return;						    //Exit the method

		var mag = RB.velocity.magnitude; //Save the magnitude value for easier use later
		Vector2 velocity;

		if (movementVector.y < 0 || movementVector.y == 0) //If player wants to move backwards, or sideways
			isSprinting = false;                     //Disable the option to sprint

		if (!isSprinting)                                      //If player is not sprinting
			velocity = movementVector * playerAcceleration;       //Multiply direction with normal acceleration
		else                                                   //If he is sprinting
			velocity = movementVector * playerSprintAcceleration; //Multiply direction with sprinting acceleration

		if (!isGrounded) //If player is not on the ground
		{
			RB.AddRelativeForce(new Vector3(velocity.x * inAirMultiplier, 0, velocity.y * inAirMultiplier)); //Apply the directed acceleration multiplied by the inAirMultiplier
			return; //And exit the method
		}

		RB.AddRelativeForce(new Vector3(velocity.x, 0, velocity.y)); //Apply the directed acceleration

		if (!isSprinting && mag > maxSpeed)						   //If player is not sprinting and his theoritical current speed is greater than his maximum speed
			RB.velocity = RB.velocity.normalized * maxSpeed;	   //Cap his speed to his max speed
		else if (isSprinting && mag > maxSprintSpeed)              //If player is sprinting and his theoritical current speed is greater than his maximum sprinting speed
			RB.velocity = RB.velocity.normalized * maxSprintSpeed; //Cap his speed to his max sprinting speed
	}

	private void HandleJump()
	{
		if (!isGrounded) //If player is not on the ground
			return;      //Exit the method

		isGrounded = false; //Set the grouded value to false
		RB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange); //Add upward force to the player
	}
}
