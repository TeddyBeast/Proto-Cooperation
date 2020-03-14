// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""5d83a8de-11ea-457d-8f8e-82de7ba1db80"",
            ""actions"": [
                {
                    ""name"": ""Front"",
                    ""type"": ""Button"",
                    ""id"": ""e9728925-8739-49f2-a3a2-90a1c647ffd9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""46c44fb8-e33d-4523-8a26-ece0d7db6dfd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""4cbef344-f26f-45e7-bf4e-fcd11c39d50c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""af27bd15-7812-4af7-b386-b0ee522abd2e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""79650efb-0b38-4aa3-854e-7b3b099d8878"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""40a02ad5-199a-4524-81be-1e2aec76ddaf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db9a09db-b3b6-43f8-bfc1-eea1ef4430e8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2afb379-9d69-4359-a130-c5f796f8e5aa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e283fe4d-ca1d-4547-a3c4-efc090bf1ac9"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05e53fe8-9f61-435f-bdd4-373470c33613"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4265326b-e38c-4c83-ad24-f5e4cf3ece4e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96086899-4486-42f6-b1cc-2506a9d454c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dd2b7e9-b619-4756-9e6a-3a581b56bb5c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbd9b4db-4298-4549-8ae8-69c8897dbaf3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999f04cc-71d4-4dc2-973d-24925f538d2b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1235ccd-a8a7-4d9c-9c7b-fd2744667464"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b8babab-9e13-4f2d-a871-e6eb60f507c7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""baadc46a-f7ef-447b-9426-887017ef8846"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""0cc9cce3-85a6-487c-ac2f-c7ba790c0eee"",
            ""actions"": [
                {
                    ""name"": ""Front"",
                    ""type"": ""Button"",
                    ""id"": ""a39cb84d-998c-42e5-bf9d-90d0ff07f590"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""37c74f1d-45c5-4af8-99e0-b731575abfc9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""6a0d0203-c7ab-4c99-b906-4e0ee1c4fbf8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""b942eace-981a-48d1-b53a-c7b8b5475584"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bbaf108d-6bbf-47e9-b18f-401973ed0218"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""09a6a097-66a9-4dd9-952e-3feae0cee7ee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27fe9104-43c2-4e3a-912d-aef041016cad"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76b5730c-618d-460a-a415-495876cb1615"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f66f1463-1be0-4060-b636-6de7f2278445"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5af1ecc3-7bd5-4fe7-b562-71afd65aae53"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16f5dde0-1dfd-4029-9dab-b96c707bca6b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dde6d3ae-9e88-4fdf-b705-45ee8c15c93b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5aa2225-4919-4aae-b957-339e765a5fd0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5346069f-9f55-4865-acca-d0e87792c14f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93d5967c-2bb1-4eda-ba75-af3e3265a0b4"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95be6f45-359f-4f10-b6e6-fc02a3a1afd2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4012dbe-1816-44b3-8f2d-2cac208b5a1e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0c0dbeb-bd21-4787-82c0-34287b3a44bb"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Front = m_Player1.FindAction("Front", throwIfNotFound: true);
        m_Player1_Back = m_Player1.FindAction("Back", throwIfNotFound: true);
        m_Player1_Right = m_Player1.FindAction("Right", throwIfNotFound: true);
        m_Player1_Left = m_Player1.FindAction("Left", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Crouch = m_Player1.FindAction("Crouch", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Front = m_Player2.FindAction("Front", throwIfNotFound: true);
        m_Player2_Back = m_Player2.FindAction("Back", throwIfNotFound: true);
        m_Player2_Right = m_Player2.FindAction("Right", throwIfNotFound: true);
        m_Player2_Left = m_Player2.FindAction("Left", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Crouch = m_Player2.FindAction("Crouch", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Front;
    private readonly InputAction m_Player1_Back;
    private readonly InputAction m_Player1_Right;
    private readonly InputAction m_Player1_Left;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Crouch;
    public struct Player1Actions
    {
        private @PlayerControls m_Wrapper;
        public Player1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Front => m_Wrapper.m_Player1_Front;
        public InputAction @Back => m_Wrapper.m_Player1_Back;
        public InputAction @Right => m_Wrapper.m_Player1_Right;
        public InputAction @Left => m_Wrapper.m_Player1_Left;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player1_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Front.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnFront;
                @Front.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnFront;
                @Front.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnFront;
                @Back.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLeft;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Front.started += instance.OnFront;
                @Front.performed += instance.OnFront;
                @Front.canceled += instance.OnFront;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Front;
    private readonly InputAction m_Player2_Back;
    private readonly InputAction m_Player2_Right;
    private readonly InputAction m_Player2_Left;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Crouch;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Front => m_Wrapper.m_Player2_Front;
        public InputAction @Back => m_Wrapper.m_Player2_Back;
        public InputAction @Right => m_Wrapper.m_Player2_Right;
        public InputAction @Left => m_Wrapper.m_Player2_Left;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player2_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Front.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnFront;
                @Front.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnFront;
                @Front.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnFront;
                @Back.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnBack;
                @Right.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnLeft;
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Front.started += instance.OnFront;
                @Front.performed += instance.OnFront;
                @Front.canceled += instance.OnFront;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayer1Actions
    {
        void OnFront(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnFront(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
