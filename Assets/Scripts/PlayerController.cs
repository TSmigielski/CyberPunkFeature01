using UnityEngine;
using UnityEngine.Rendering.Universal;

[SelectionBase]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IEntity
{
	//Interface
	public CharacterController CController { get; private set; }
	public Transform Head { get; private set; }
	public MovementInformation ControlScheme { get; private set; }

	//Player Controls
	PlayerControls controls;

	//Look Around variables
	Vector2 lookVector;
	float headRotation, mouseX, mouseY;

	//Other Variables/Properties
	public bool HackModeEnabled { get; private set; } = false;

	[Header("Objects/Components")]
	[SerializeField] Camera myCamera;
	UniversalAdditionalCameraData myCamData;
	[SerializeField] MovementController movementController;
	[SerializeField] GameObject hackModePostProcessing;

	[Header("Player Values")]
	[SerializeField] public float _speed;
	[SerializeField] float _sprintSpeed;
	[SerializeField] float _jumpHeight;
	[SerializeField] Vector2 _headRotationLimit;

	private void Awake()
	{
		CController = GetComponent<CharacterController>(); //Reference Character Controller to the field
		Head = myCamera.transform;						   //Reference Camera transform to the property
		ControlScheme = new MovementInformation();		   //Instantiate the Movement class
		controls = new PlayerControls();				   //Instantiate the controls
		myCamData = myCamera.GetComponent<UniversalAdditionalCameraData>(); //Reference extra cam data to the field
		InitializeControlScheme();						   //Assign default values to the control scheme
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and make it invisible
	}

	private void OnEnable()
	{
		controls.Enable();                                                              //Enable the controls
		controls.Player.Sprint.started += _ => { ControlScheme.IsSprinting = true; };   //Subscribe to the sprint start event, and set the value
		controls.Player.Sprint.canceled += _ => { ControlScheme.IsSprinting = false; }; //Subscribe to the sprint stop event, and set the value
		controls.Player.Jump.performed += _ => movementController.PerformJump();        //Subscribe to the jump event and handle it
		controls.Player.HackMode.performed += _ => HandleHackMode();                    //Subscribe to the Hack Mode event and handle it
	}

	private void OnDisable()
	{
		controls.Player.Sprint.started -= _ => { ControlScheme.IsSprinting = true; };   //Unsubscribe from the sprint start event
		controls.Player.Sprint.canceled -= _ => { ControlScheme.IsSprinting = false; }; //Unsubscribe from the sprint stop event
		controls.Player.Jump.performed -= _ => movementController.PerformJump();        //Unubscribe from the jump event
		controls.Player.HackMode.performed -= _ => HandleHackMode();                    //Unubscribe from the Hack Mode event and handle it
		controls.Disable();                                                             //Disable the controls
	}

	private void Update()
	{
		HandlePlayerInput();
		UpdateCharacterLooking();
	}

	private void InitializeControlScheme() //Assign default values to the control scheme
	{
		ControlScheme.Speed = _speed;
		ControlScheme.SprintSpeed = _sprintSpeed;
		ControlScheme.JumpHeight = _jumpHeight;
		ControlScheme.HeadRotationClamps = _headRotationLimit;
	}

	private void HandlePlayerInput()
	{
		ControlScheme.MovementVector = controls.Player.Movement.ReadValue<Vector2>(); //Pass player move input to the control scheme
		lookVector = controls.Player.LookAround.ReadValue<Vector2>(); //Register player rotation/look input
	}

	private void UpdateCharacterLooking()
	{
		mouseX = lookVector.x * PlayerSettings.Instance.MouseSensitivity; //Multiply player input by sensitivity
		mouseY = lookVector.y * PlayerSettings.Instance.MouseSensitivity; //Multiply player input by sensitivity

		headRotation -= mouseY; //Invert the vertical rotation
		headRotation = Mathf.Clamp(headRotation, ControlScheme.HeadRotationClamps.y, ControlScheme.HeadRotationClamps.x); //Clamp the vertical rotation

		transform.Rotate(Vector3.up * mouseX); //Rotate the character horizontally
		Head.localRotation = Quaternion.Euler(headRotation, 0f, 0f); //Rotate character's head vertically
	}

	private void HandleHackMode()
	{
		if (!HackModeEnabled) //If hack mode is disabled
		{
			HackModeEnabled = true; //Make the field true
			UI_Handler.Instance.HackModeOn(); //Change UI
			myCamData.SetRenderer(1); //Enable the wallhack
			hackModePostProcessing.SetActive(true); //Enable the on screen filter
		}
		else
		{
			HackModeEnabled = false; //Make the field false
			UI_Handler.Instance.HackModeOff(); // Change UI
			myCamData.SetRenderer(0); //Disable the wallhack
			hackModePostProcessing.SetActive(false); //Disable the on screen filter
		}
	}
}
