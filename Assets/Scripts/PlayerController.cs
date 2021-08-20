using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

[SelectionBase]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, IEntity
{
	//Interface
	public CharacterController CController { get; private set; }
	public MovementInformation ControlScheme { get; private set; }

	//Player Controls
	PlayerControls controls;

	//Player Input
	Vector2 lookVector;
	float headRotation;

	//Hack Mode
	public bool HackModeEnabled { get; private set; } = false;

	//Equipment
	Equipment[] myEquipment;
	(int index, Equipment item) currentlyEquiped;
	float scroll;

	[Header("Objects/Components")]
	[SerializeField] Transform head;
	[SerializeField] Camera mainCamera;
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
		ControlScheme = new MovementInformation();		   //Instantiate the Movement class
		controls = new PlayerControls();				   //Instantiate the controls
		myCamData = mainCamera.GetComponent<UniversalAdditionalCameraData>(); //Reference extra cam data to the field
		InitializeControlScheme();                         //Assign default values to the control scheme
		FindEquipment();                                   //Find all pieces of equipment on the player
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and make it invisible
		EquipItem(0);
	}

	private void OnEnable() //Subscribe to all input events and handlet them
	{
		controls.Enable();
		controls.Player.Sprint.started += _ => { ControlScheme.IsSprinting = true; };
		controls.Player.Sprint.canceled += _ => { ControlScheme.IsSprinting = false; };
		controls.Player.Jump.performed += _ => movementController.PerformJump();
		controls.Player.HackMode.started += _ => HackModeOn();
		controls.Player.HackMode.canceled += _ => HackModeOff();
		controls.Player.Shoot.performed += _ => UseEquipedItem();
		controls.Player.Reload.performed += _ => ReloadWeapon();
		controls.Player.SelectItem1.performed += _ => EquipItem(1);
		controls.Player.SelectItem2.performed += _ => EquipItem(2);
		controls.Player.SelectItem3.performed += _ => EquipItem(3);
	}

	private void OnDisable() //Unsubscribe from all input events
	{
		controls.Player.Sprint.started -= _ => { ControlScheme.IsSprinting = true; };
		controls.Player.Sprint.canceled -= _ => { ControlScheme.IsSprinting = false; };
		controls.Player.Jump.performed -= _ => movementController.PerformJump();
		controls.Player.HackMode.performed -= _ => HackModeOn();
		controls.Player.HackMode.performed -= _ => HackModeOff();
		controls.Player.Shoot.performed -= _ => UseEquipedItem();
		controls.Player.Reload.performed -= _ => ReloadWeapon();
		controls.Player.SelectItem1.performed -= _ => EquipItem(1);
		controls.Player.SelectItem2.performed -= _ => EquipItem(2);
		controls.Player.SelectItem3.performed -= _ => EquipItem(3);
		controls.Disable();
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

	private void FindEquipment()
	{
		myEquipment = GetComponentsInChildren<Equipment>();
		UI_Handler.Instance.InitializeEquipment(myEquipment);
		foreach (var eq in myEquipment)
			eq.gameObject.SetActive(false);
	}

	private void HandlePlayerInput()
	{
		ControlScheme.MovementVector = controls.Player.Movement.ReadValue<Vector2>(); //Pass player move input to the control scheme

		var mouse = controls.Player.LookWithMouse.ReadValue<Vector2>(); //Register player mouse look input
		var pad = controls.Player.LookWithGamepad.ReadValue<Vector2>(); //Register player gamepad look input

		if (mouse != Vector2.zero) //If player uses mouse
			lookVector = mouse * PlayerSettings.Instance.MouseSensitivity; //Pass the input to the lookVector field multiplied by mouse sensitivity
		else if (pad != Vector2.zero) //If player uses gamepad
			lookVector = pad * PlayerSettings.Instance.GamepadSensitivity * Time.deltaTime; //Pass the input to the lookVector field multiplied by gamepad sensitivity and deltaTime
		else																				//This is because the mouse input is a delta, and gamepad's not
			lookVector = Vector2.zero; //Pass 0 to stop any rotation if no input is present

		//Equipment
		var newScroll = controls.Player.SelectItem.ReadValue<float>();
		if (newScroll != 0 && scroll != 0)
			return;

		scroll = newScroll;

		if (scroll > 0)
		{
			if (currentlyEquiped.index == myEquipment.Length)
				EquipItem(0);
			//else if (currentlyEquiped.index == 0)
			//	EquipItem(1);
			else
				EquipItem(currentlyEquiped.index + 1);
		}
		else if (scroll < 0)
		{
			if (currentlyEquiped.index == 0)
				EquipItem(myEquipment.Length);
			else
				EquipItem(currentlyEquiped.index - 1);
		}
	}
	
	private void UpdateCharacterLooking()
	{
		headRotation -= lookVector.y; //Invert the vertical rotation
		headRotation = Mathf.Clamp(headRotation, ControlScheme.HeadRotationClamps.y, ControlScheme.HeadRotationClamps.x); //Clamp the vertical rotation

		transform.Rotate(Vector3.up * lookVector.x); //Rotate the character horizontally
		head.localRotation = Quaternion.Euler(headRotation, 0f, 0f); //Rotate character's head vertically
	}

	private void HackModeOn()
	{
		HackModeEnabled = true; //Make the field true
		UI_Handler.Instance.HackModeOn(); //Change UI
		myCamData.SetRenderer(1); //Enable the wallhack
		hackModePostProcessing.SetActive(true); //Enable the on screen filter
	}

	private void HackModeOff()
	{
		HackModeEnabled = false; //Make the field false
		UI_Handler.Instance.HackModeOff(); // Change UI
		myCamData.SetRenderer(0); //Disable the wallhack
		hackModePostProcessing.SetActive(false); //Disable the on screen filter
	}

	private void EquipItem(int index)
	{
		if (currentlyEquiped.index == index)
			index = 0;

		foreach (var eq in myEquipment)
			eq.gameObject.SetActive(false);

		if (index == 0)
			currentlyEquiped = (0, null);
		else
		{
			currentlyEquiped = (index, myEquipment[index - 1]);
			currentlyEquiped.item.gameObject.SetActive(true);
		}

		UI_Handler.Instance.SelectEquipment(index);
	}

	private void UseEquipedItem()
	{
		if (currentlyEquiped.index == 0)
			return;

		currentlyEquiped.item.Use();
	}

	private void ReloadWeapon()
	{
		if (currentlyEquiped.item is Gun)
		{
			var currentGun= currentlyEquiped.item as Gun;
			currentGun.Reload();
		}
	}
}
