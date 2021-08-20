// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3adb9f2f-9eeb-49af-81b2-86c7ae25e11e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e52c252e-b0c8-4234-8a44-7707aacb9b3f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""d8da6f69-ae84-4f7d-94be-7e567fbce681"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""78abe769-5768-4504-a056-499b92e4bd18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookWithMouse"",
                    ""type"": ""Value"",
                    ""id"": ""a40d2d93-117a-4e80-9917-5e1b965f7ab9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookWithGamepad"",
                    ""type"": ""Value"",
                    ""id"": ""f3b1def4-20f3-429b-9b17-ef5b6baea67b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hack Mode"",
                    ""type"": ""Button"",
                    ""id"": ""c3101b89-57d2-4a8a-8900-6cdbbafc9b72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""92ebc3ca-4a66-4335-9740-6aa3acc648f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""36356c14-cfb0-4ce0-a876-bf6e5611b0d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""8ea3cf98-d4b9-4f41-a18c-e40aadd0ec80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e8d99f83-3b81-400a-999b-8e5a34990e6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Item"",
                    ""type"": ""Value"",
                    ""id"": ""dc5d201f-e232-42f7-aba0-7acea45c4b89"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Item 1"",
                    ""type"": ""Button"",
                    ""id"": ""1cee139f-c4d4-481c-9c48-840e419fb8c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Item 2"",
                    ""type"": ""Button"",
                    ""id"": ""79262333-53d6-4bc9-8d0e-f4701842a2ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Item 3"",
                    ""type"": ""Button"",
                    ""id"": ""db82c65c-1669-4db4-850e-dc3eefd5489d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""da2d0284-2939-4ddc-874c-f317a255d9da"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6c916392-e4ca-43d5-9a82-401718da07db"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""90135ea4-66ed-4dcf-8b57-56860ff378a2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c8106333-0b56-4139-88a7-c80b9aa9ed24"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4c3a316c-2306-4c9b-bf02-93e0348f3820"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7bf6a614-3dbd-4268-96a2-6485c48f94e4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58f9209e-bb19-4eb1-aafa-b7f1a1ba33a8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9f2eeac-4ae8-40e3-a680-c447952a2f07"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1e026a5-8ed6-4541-87fa-c391aaedf502"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c75bcd9f-51cc-4e66-adb4-6f0c60f76f3d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f62ce68-d26b-4856-852b-226fb1a35394"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""LookWithMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e7b7d12-b0e5-4f41-96c1-4112b0d212d6"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Hack Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86aea8f2-5267-4e3e-b28e-4f0b7d131bb3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Hack Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6717bd34-06e5-454c-97f5-e567475a9743"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LookWithGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1054f2f-609f-45a0-963b-8f2707e23e68"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c2b2306-40e2-4fdb-97b0-00a97ded6704"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c65daca-a9cc-4a44-973f-d74c3014996f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53cd59f2-7f18-44e4-a5e4-7e3e6de26c60"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3b8a57f-56b3-4846-adcb-bb2358358577"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e5053b1-6e19-43c9-abb2-f74f2374e9f4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb102067-961c-468c-a458-e42701c95548"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""788166f4-622b-44f5-b7a0-90c42d69e3be"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32d1c93e-aa65-4cc2-9d74-45a7835c0f5a"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Select Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24b0fb21-7c50-4540-9484-21cbe276f550"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f76c562d-9295-46f2-b420-173cc6a47398"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Select Item 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce78c7e4-fe93-4c0f-a8fa-b10aa2e0df45"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Select Item 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8afabbf7-c2d2-4b49-8ef5-d2af2f2bcda8"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB & M"",
                    ""action"": ""Select Item 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB & M"",
            ""bindingGroup"": ""KB & M"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_LookWithMouse = m_Player.FindAction("LookWithMouse", throwIfNotFound: true);
        m_Player_LookWithGamepad = m_Player.FindAction("LookWithGamepad", throwIfNotFound: true);
        m_Player_HackMode = m_Player.FindAction("Hack Mode", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_SelectItem = m_Player.FindAction("Select Item", throwIfNotFound: true);
        m_Player_SelectItem1 = m_Player.FindAction("Select Item 1", throwIfNotFound: true);
        m_Player_SelectItem2 = m_Player.FindAction("Select Item 2", throwIfNotFound: true);
        m_Player_SelectItem3 = m_Player.FindAction("Select Item 3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_LookWithMouse;
    private readonly InputAction m_Player_LookWithGamepad;
    private readonly InputAction m_Player_HackMode;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_SelectItem;
    private readonly InputAction m_Player_SelectItem1;
    private readonly InputAction m_Player_SelectItem2;
    private readonly InputAction m_Player_SelectItem3;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @LookWithMouse => m_Wrapper.m_Player_LookWithMouse;
        public InputAction @LookWithGamepad => m_Wrapper.m_Player_LookWithGamepad;
        public InputAction @HackMode => m_Wrapper.m_Player_HackMode;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @SelectItem => m_Wrapper.m_Player_SelectItem;
        public InputAction @SelectItem1 => m_Wrapper.m_Player_SelectItem1;
        public InputAction @SelectItem2 => m_Wrapper.m_Player_SelectItem2;
        public InputAction @SelectItem3 => m_Wrapper.m_Player_SelectItem3;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @LookWithMouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithMouse;
                @LookWithMouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithMouse;
                @LookWithMouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithMouse;
                @LookWithGamepad.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithGamepad;
                @LookWithGamepad.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithGamepad;
                @LookWithGamepad.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLookWithGamepad;
                @HackMode.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHackMode;
                @HackMode.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHackMode;
                @HackMode.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHackMode;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @SelectItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem;
                @SelectItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem;
                @SelectItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem;
                @SelectItem1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem1;
                @SelectItem1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem1;
                @SelectItem1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem1;
                @SelectItem2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem2;
                @SelectItem2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem2;
                @SelectItem2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem2;
                @SelectItem3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem3;
                @SelectItem3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem3;
                @SelectItem3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectItem3;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LookWithMouse.started += instance.OnLookWithMouse;
                @LookWithMouse.performed += instance.OnLookWithMouse;
                @LookWithMouse.canceled += instance.OnLookWithMouse;
                @LookWithGamepad.started += instance.OnLookWithGamepad;
                @LookWithGamepad.performed += instance.OnLookWithGamepad;
                @LookWithGamepad.canceled += instance.OnLookWithGamepad;
                @HackMode.started += instance.OnHackMode;
                @HackMode.performed += instance.OnHackMode;
                @HackMode.canceled += instance.OnHackMode;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @SelectItem.started += instance.OnSelectItem;
                @SelectItem.performed += instance.OnSelectItem;
                @SelectItem.canceled += instance.OnSelectItem;
                @SelectItem1.started += instance.OnSelectItem1;
                @SelectItem1.performed += instance.OnSelectItem1;
                @SelectItem1.canceled += instance.OnSelectItem1;
                @SelectItem2.started += instance.OnSelectItem2;
                @SelectItem2.performed += instance.OnSelectItem2;
                @SelectItem2.canceled += instance.OnSelectItem2;
                @SelectItem3.started += instance.OnSelectItem3;
                @SelectItem3.performed += instance.OnSelectItem3;
                @SelectItem3.canceled += instance.OnSelectItem3;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KB & M");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLookWithMouse(InputAction.CallbackContext context);
        void OnLookWithGamepad(InputAction.CallbackContext context);
        void OnHackMode(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSelectItem(InputAction.CallbackContext context);
        void OnSelectItem1(InputAction.CallbackContext context);
        void OnSelectItem2(InputAction.CallbackContext context);
        void OnSelectItem3(InputAction.CallbackContext context);
    }
}
