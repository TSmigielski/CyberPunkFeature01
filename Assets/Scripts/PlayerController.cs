using UnityEngine;
using UnityEngine.Rendering.Universal;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour, IEntity
{
	//Interface
	public Rigidbody RB { get; private set; }
	public Collider CL { get; private set; }
	public Transform Head { get; private set; }
	public Movement ControlScheme { get; private set; }

	//Player Controls
	PlayerControls controls;

	//Other Variables
	public bool HackModeEnabled { get; private set; } = false;

	[Header("Objects/Components")]
	[SerializeField] FPPController fppController;
	[SerializeField] Camera myCamera;
	UniversalAdditionalCameraData myCamData;
	[SerializeField] GameObject hackModePostProcessing;

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
		Head = myCamera.transform;		 //Reference Camera transform to the property
		ControlScheme = new Movement();  //Instantiate the Movement class
		controls = new PlayerControls(); //Instantiate the controls
		myCamData = myCamera.GetComponent<UniversalAdditionalCameraData>(); //Reference extra cam data to the field
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
		controls.Player.Jump.performed += _ => fppController.PerformJump();             //Subscribe to the jump event and handle it
		controls.Player.HackMode.performed += _ => HandleHackMode();					//Subscribe to the Hack Mode event and handle it
	}

	private void OnDisable()
	{
		controls.Player.Sprint.started -= _ => { ControlScheme.IsSprinting = true; };   //Unsubscribe from the sprint start event
		controls.Player.Sprint.canceled -= _ => { ControlScheme.IsSprinting = false; }; //Unsubscribe from the sprint stop event
		controls.Player.Jump.performed -= _ => fppController.PerformJump();             //Unubscribe from the jump event
		controls.Player.HackMode.performed -= _ => HandleHackMode();                    //Unubscribe from the Hack Mode event and handle it
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

	private void HandlePlayerInput()
	{
		ControlScheme.MovementVector = controls.Player.Movement.ReadValue<Vector2>(); //Pass player move input to the control scheme
		ControlScheme.LookVector = controls.Player.LookAround.ReadValue<Vector2>() * PlayerSettings.Instance.MouseSensitivity; //Pass player look input multiplied by sensitivity to the control scheme
	}

	private void HandleHackMode()
	{
		if (!HackModeEnabled)
		{
			HackModeEnabled = true;
			UI_Handler.Instance.HackModeOn();
			myCamData.SetRenderer(1);
			hackModePostProcessing.SetActive(true);
		}
		else
		{
			HackModeEnabled = false;
			UI_Handler.Instance.HackModeOff();
			myCamData.SetRenderer(0);
			hackModePostProcessing.SetActive(false);
		}
	}
}
