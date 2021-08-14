using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour, IEntity
{
	public Rigidbody RB { get; private set; }
	public Collider CL { get; private set; }
	public Transform Head
	{
		get { return _head; }
	}
	public Movement ControlScheme { get; private set; }

	PlayerControls controls;

	[Header("Objects/Components")]
	[SerializeField] FPPController fppController;
	[SerializeField] private Transform _head;

	[Header("Player Values")]
	[SerializeField] float _acceleration;
	[SerializeField] float _sprintAcceleration;
	[SerializeField] float _maxSpeed;
	[SerializeField] float _maxSprintSpeed;
	[SerializeField] float _inAirMultiplier;
	[SerializeField] float _jumpForce;
	[SerializeField] Vector2 _headRotationClamps;

	private void Awake()
	{
		RB = GetComponent<Rigidbody>();  //Reference Rigidbody to the property
		CL = GetComponent<Collider>();   //Reference Collider to the property
		ControlScheme = new Movement();  //Instantiate the Movement class
		controls = new PlayerControls(); //Instantiate the controls
		InitializeControlScheme();		 //Assign default values to the control scheme
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and make it invisible
	}

	private void OnEnable()
	{
		controls.Enable();																//Enable the controls
		controls.Player.Sprint.started += _ => { ControlScheme.IsSprinting = true; };   //Subscribe to the sprint start event, and set the value
		controls.Player.Sprint.canceled += _ => { ControlScheme.IsSprinting = false; }; //Subscribe to the sprint stop event, and set the value
		controls.Player.Jump.performed += _ => fppController.PerformJump();				//Subscribe to the jump event, and handle it
	}

	private void OnDisable()
	{
		controls.Player.Sprint.started -= _ => { ControlScheme.IsSprinting = true; };   //Unsubscribe the sprint start event
		controls.Player.Sprint.canceled -= _ => { ControlScheme.IsSprinting = false; }; //Unsubscribe the sprint stop event
		controls.Player.Jump.performed -= _ => fppController.PerformJump();				//Unubscribe the jump event
		controls.Disable();																//Disable the controls
	}

	private void Update()
	{
		HandlePlayerInput();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.layer.Equals(StaticData.Instance.GroundLayer)) //If player collides with a object on the ground layer
			ControlScheme.IsGrounded = true;                                     //Set the grounded value to true
	}

	private void HandlePlayerInput()
	{
		ControlScheme.MovementVector = controls.Player.Movement.ReadValue<Vector2>(); //Pass player move input to the control scheme
		ControlScheme.LookVector = controls.Player.LookAround.ReadValue<Vector2>() * PlayerSettings.Instance.MouseSensitivity; //Pass player look input multiplied by sensitivity to the control scheme
	}

	private void InitializeControlScheme() //Assign default values to the control scheme
	{
		ControlScheme.Acceleration = _acceleration;
		ControlScheme.SprintAcceleration = _sprintAcceleration;
		ControlScheme.MaxSpeed = _maxSpeed;
		ControlScheme.MaxSprintSpeed = _maxSprintSpeed;
		ControlScheme.InAirMultiplier = _inAirMultiplier;
		ControlScheme.JumpForce = _jumpForce;
		ControlScheme.HeadRotationClamps = _headRotationClamps;
	}
}
