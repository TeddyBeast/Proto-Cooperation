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
                    ""name"": ""MovementHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""db309929-1e17-45c7-8184-e6459cef4bec"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementVertical"",
                    ""type"": ""Value"",
                    ""id"": ""eaea07f9-0c7b-490e-bbd3-e78663d2892c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""b156bffd-780a-430b-8b36-34a23280681a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraVertical"",
                    ""type"": ""Value"",
                    ""id"": ""7c25c9dd-c273-4e58-b78e-3b0d588eef84"",
                    ""expectedControlType"": ""Axis"",
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
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""1eb582ed-fb7c-4bc4-9640-bb35c3c2f958"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddPortal"",
                    ""type"": ""Button"",
                    ""id"": ""eafc7b73-24e0-49b3-93a2-ae5b1293421a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchPortal"",
                    ""type"": ""Button"",
                    ""id"": ""aa24a4f4-550e-4dc5-a59b-1da2420c3e8a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4265326b-e38c-4c83-ad24-f5e4cf3ece4e"",
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
                    ""id"": ""96086899-4486-42f6-b1cc-2506a9d454c8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b8babab-9e13-4f2d-a871-e6eb60f507c7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""baadc46a-f7ef-447b-9426-887017ef8846"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""HorizontalKeyboard"",
                    ""id"": ""0ad8242f-0185-44e6-ac38-75ce82b89ef2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""20d45086-a54f-467b-86d0-9f2f2859e1cf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""34e4d61c-9dda-43c3-a178-9f424158d87a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HorizontalGamepad"",
                    ""id"": ""2ad2547c-a36f-4c7b-833e-7cf643c7ef10"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8257dc95-fec9-46bf-b49e-32988eac98d2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""30a3dbae-79ed-41c1-aeab-050a75babe34"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""VerticalKeyboard"",
                    ""id"": ""1d89be71-9d28-4640-ad9d-61d8f58cc7a9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""683cc79a-5084-4370-8d8c-c19c78339f7e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2cddbe66-a72d-4e49-bd92-fbb931ee237f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""VerticalGamepad"",
                    ""id"": ""2a27b1d7-9947-4e86-9504-e4869153f78d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6f2f585a-e0aa-4225-9bf0-7c7c873e4210"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ceafb8b7-a54b-4b82-83a8-d3816ea31ead"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamVerticalKeyboard"",
                    ""id"": ""0e9f95d7-f275-4df6-9765-a94551b471b5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bc965223-1676-402a-91d9-9ccf7bfb2758"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""85a1ae90-0f2d-4343-b527-61afe4309922"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamVerticalGamepad"",
                    ""id"": ""5454fff4-5c34-460d-bb0a-71fc1623e9a5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4889e3b0-bab8-4293-9019-647fc6a20fbe"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""76756958-6da1-44aa-8d49-4bc8c434aff5"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamHorizontalKeyboard"",
                    ""id"": ""83bae58d-e5eb-4d31-8232-898d2ef8271a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3a980d39-1e86-4ce1-b5b8-5402d7eccf0e"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5e19d1cc-edcc-475a-9995-747738ca5402"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamHorizontalGamepad"",
                    ""id"": ""d078d831-7acd-4206-8098-02e6a9925d7a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""565f231a-28dd-44ed-b0a1-7006936c958f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""107e982c-aeb4-416d-913b-abc01214b1da"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1c9dad00-74b8-446a-9af0-9b2cceee1bfd"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64372051-530e-40b7-b187-63106f771158"",
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
                    ""id"": ""74c5fd4a-4c9b-422b-82fd-84a5d003cfb8"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AddPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05e188bd-6e63-47d4-912e-0642fcde248b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AddPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa86b0d2-004c-4323-b578-b2c29f40e035"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b19cd0e-cde7-4eae-ba16-6abe528026a2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""d0a96630-cb3f-427d-a76c-dffe56904ade"",
            ""actions"": [
                {
                    ""name"": ""MovementHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""ae2e253a-4903-4984-81a1-f2eb862ff30d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovementVertical"",
                    ""type"": ""Value"",
                    ""id"": ""8fb8057f-0456-444a-b24d-e271d074c563"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraHorizontal"",
                    ""type"": ""Value"",
                    ""id"": ""da927cf1-cfad-4b0a-be0b-b173ced8a601"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraVertical"",
                    ""type"": ""Value"",
                    ""id"": ""6941ce6f-4a10-48cd-bac0-d9db74419cbd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c15a006d-286d-41ab-ba10-c4a9d9dbfb9b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""5840329a-db0f-46ee-ae9d-2f2aa7af2bef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""30104db7-8a40-4719-ad87-96f00598bc31"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddPortal"",
                    ""type"": ""Button"",
                    ""id"": ""c5d2f74f-903a-40f9-b0e5-74bad1cf4d38"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwitchPortal"",
                    ""type"": ""Button"",
                    ""id"": ""aa0a388b-748f-47d7-a523-98a3a9d56e4d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2e72455-f3db-422d-b3a2-79628c3a7c10"",
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
                    ""id"": ""54a8a5b4-dab0-4372-bba9-0f19c2c03221"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08d9c308-9d46-402c-b6f1-7c3a5c6d8c00"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd52ddeb-758d-4e29-8b0d-c6890af0fc12"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""VerticalKeyboard"",
                    ""id"": ""bc87b8b9-e062-4077-8e43-fe27d680fdf7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dac970b9-7439-4433-873a-2d3b3e9f005b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""acda7215-6223-44b4-81c9-785c78e7afdd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HorizontalKeyboard"",
                    ""id"": ""cba16157-a670-46da-83e1-d7d503bd6e4f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3e45dac8-b824-4976-9de5-785f4a4ebce6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""49a76e3e-766b-468e-9066-300ca3c96020"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""HorizontalGamepad"",
                    ""id"": ""23ed3082-fd13-45b5-9acc-86630ac72a3a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1e2c9348-a956-4d1a-874d-6248c37e7bc1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8996e1c2-8405-4432-9ee9-81076830fc35"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""VerticalGamepad"",
                    ""id"": ""f81e2a2f-b3e9-4f7b-813c-b6d3bb8713bd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5e939ce4-9f30-4b29-9290-e1a20f6e115e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aa52b4f7-e6ee-4a8b-acb8-6649bac8a5cb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovementVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MouseVertical"",
                    ""id"": ""804c0dcf-228b-46ab-af17-c8df93d170ff"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""33e6e6ba-0341-4f55-a6fd-2040aa546fe3"",
                    ""path"": ""<Mouse>/radius/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ff89fcd-8289-497a-a88c-0df0090036e2"",
                    ""path"": ""<Mouse>/radius/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamVerticalGamepad"",
                    ""id"": ""a8e39ca4-7ba7-4d9f-ae82-727c68a0a221"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""279e50ba-cd4e-44a8-b1f1-23d954c44f38"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d3bd72aa-f8ac-461d-822b-b4c539cf28e4"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Mouse"",
                    ""id"": ""61686627-9ae5-41a2-accb-2ecc58e1d436"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""18d5af78-eca9-4305-94d3-9f3d3a9ae17f"",
                    ""path"": ""<Mouse>/radius/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""556f326b-d2a2-40a4-bb69-ea414e3b3c63"",
                    ""path"": ""<Mouse>/radius/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""CamHorizontalGamepad"",
                    ""id"": ""4e47e549-446a-4092-bffb-df484fb1d749"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7dec7a46-7812-4160-ab38-64c0560008f7"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""faa86fdd-b34d-469e-a32f-01b511672140"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""75e14d26-ed71-47f1-b08d-2c1d50f058a1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""727f6153-82b2-4d09-91f4-2d3715f652cb"",
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
                    ""id"": ""b8d2f9ee-1cd8-4376-8d10-927675e904e1"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""AddPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2da8f5c7-edd7-4d67-8944-473567d65613"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AddPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b666c7e2-72ad-4038-a871-ae510e5e14cc"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SwitchPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7166d65f-9079-4577-b530-34f005b8272d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SwitchPortal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
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
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_MovementHorizontal = m_Player1.FindAction("MovementHorizontal", throwIfNotFound: true);
        m_Player1_MovementVertical = m_Player1.FindAction("MovementVertical", throwIfNotFound: true);
        m_Player1_CameraHorizontal = m_Player1.FindAction("CameraHorizontal", throwIfNotFound: true);
        m_Player1_CameraVertical = m_Player1.FindAction("CameraVertical", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Crouch = m_Player1.FindAction("Crouch", throwIfNotFound: true);
        m_Player1_Aim = m_Player1.FindAction("Aim", throwIfNotFound: true);
        m_Player1_AddPortal = m_Player1.FindAction("AddPortal", throwIfNotFound: true);
        m_Player1_SwitchPortal = m_Player1.FindAction("SwitchPortal", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_MovementHorizontal = m_Player2.FindAction("MovementHorizontal", throwIfNotFound: true);
        m_Player2_MovementVertical = m_Player2.FindAction("MovementVertical", throwIfNotFound: true);
        m_Player2_CameraHorizontal = m_Player2.FindAction("CameraHorizontal", throwIfNotFound: true);
        m_Player2_CameraVertical = m_Player2.FindAction("CameraVertical", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Crouch = m_Player2.FindAction("Crouch", throwIfNotFound: true);
        m_Player2_Aim = m_Player2.FindAction("Aim", throwIfNotFound: true);
        m_Player2_AddPortal = m_Player2.FindAction("AddPortal", throwIfNotFound: true);
        m_Player2_SwitchPortal = m_Player2.FindAction("SwitchPortal", throwIfNotFound: true);
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
    private readonly InputAction m_Player1_MovementHorizontal;
    private readonly InputAction m_Player1_MovementVertical;
    private readonly InputAction m_Player1_CameraHorizontal;
    private readonly InputAction m_Player1_CameraVertical;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Crouch;
    private readonly InputAction m_Player1_Aim;
    private readonly InputAction m_Player1_AddPortal;
    private readonly InputAction m_Player1_SwitchPortal;
    public struct Player1Actions
    {
        private @PlayerControls m_Wrapper;
        public Player1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementHorizontal => m_Wrapper.m_Player1_MovementHorizontal;
        public InputAction @MovementVertical => m_Wrapper.m_Player1_MovementVertical;
        public InputAction @CameraHorizontal => m_Wrapper.m_Player1_CameraHorizontal;
        public InputAction @CameraVertical => m_Wrapper.m_Player1_CameraVertical;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player1_Crouch;
        public InputAction @Aim => m_Wrapper.m_Player1_Aim;
        public InputAction @AddPortal => m_Wrapper.m_Player1_AddPortal;
        public InputAction @SwitchPortal => m_Wrapper.m_Player1_SwitchPortal;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @MovementHorizontal.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementHorizontal;
                @MovementVertical.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMovementVertical;
                @CameraHorizontal.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraHorizontal;
                @CameraVertical.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCameraVertical;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Aim.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAim;
                @AddPortal.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAddPortal;
                @AddPortal.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAddPortal;
                @AddPortal.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAddPortal;
                @SwitchPortal.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitchPortal;
                @SwitchPortal.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitchPortal;
                @SwitchPortal.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnSwitchPortal;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementHorizontal.started += instance.OnMovementHorizontal;
                @MovementHorizontal.performed += instance.OnMovementHorizontal;
                @MovementHorizontal.canceled += instance.OnMovementHorizontal;
                @MovementVertical.started += instance.OnMovementVertical;
                @MovementVertical.performed += instance.OnMovementVertical;
                @MovementVertical.canceled += instance.OnMovementVertical;
                @CameraHorizontal.started += instance.OnCameraHorizontal;
                @CameraHorizontal.performed += instance.OnCameraHorizontal;
                @CameraHorizontal.canceled += instance.OnCameraHorizontal;
                @CameraVertical.started += instance.OnCameraVertical;
                @CameraVertical.performed += instance.OnCameraVertical;
                @CameraVertical.canceled += instance.OnCameraVertical;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @AddPortal.started += instance.OnAddPortal;
                @AddPortal.performed += instance.OnAddPortal;
                @AddPortal.canceled += instance.OnAddPortal;
                @SwitchPortal.started += instance.OnSwitchPortal;
                @SwitchPortal.performed += instance.OnSwitchPortal;
                @SwitchPortal.canceled += instance.OnSwitchPortal;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_MovementHorizontal;
    private readonly InputAction m_Player2_MovementVertical;
    private readonly InputAction m_Player2_CameraHorizontal;
    private readonly InputAction m_Player2_CameraVertical;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Crouch;
    private readonly InputAction m_Player2_Aim;
    private readonly InputAction m_Player2_AddPortal;
    private readonly InputAction m_Player2_SwitchPortal;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementHorizontal => m_Wrapper.m_Player2_MovementHorizontal;
        public InputAction @MovementVertical => m_Wrapper.m_Player2_MovementVertical;
        public InputAction @CameraHorizontal => m_Wrapper.m_Player2_CameraHorizontal;
        public InputAction @CameraVertical => m_Wrapper.m_Player2_CameraVertical;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player2_Crouch;
        public InputAction @Aim => m_Wrapper.m_Player2_Aim;
        public InputAction @AddPortal => m_Wrapper.m_Player2_AddPortal;
        public InputAction @SwitchPortal => m_Wrapper.m_Player2_SwitchPortal;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @MovementHorizontal.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementHorizontal;
                @MovementHorizontal.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementHorizontal;
                @MovementVertical.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementVertical;
                @MovementVertical.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMovementVertical;
                @CameraHorizontal.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraHorizontal;
                @CameraHorizontal.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraHorizontal;
                @CameraVertical.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraVertical;
                @CameraVertical.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCameraVertical;
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnCrouch;
                @Aim.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAim;
                @AddPortal.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAddPortal;
                @AddPortal.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAddPortal;
                @AddPortal.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAddPortal;
                @SwitchPortal.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSwitchPortal;
                @SwitchPortal.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSwitchPortal;
                @SwitchPortal.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSwitchPortal;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementHorizontal.started += instance.OnMovementHorizontal;
                @MovementHorizontal.performed += instance.OnMovementHorizontal;
                @MovementHorizontal.canceled += instance.OnMovementHorizontal;
                @MovementVertical.started += instance.OnMovementVertical;
                @MovementVertical.performed += instance.OnMovementVertical;
                @MovementVertical.canceled += instance.OnMovementVertical;
                @CameraHorizontal.started += instance.OnCameraHorizontal;
                @CameraHorizontal.performed += instance.OnCameraHorizontal;
                @CameraHorizontal.canceled += instance.OnCameraHorizontal;
                @CameraVertical.started += instance.OnCameraVertical;
                @CameraVertical.performed += instance.OnCameraVertical;
                @CameraVertical.canceled += instance.OnCameraVertical;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @AddPortal.started += instance.OnAddPortal;
                @AddPortal.performed += instance.OnAddPortal;
                @AddPortal.canceled += instance.OnAddPortal;
                @SwitchPortal.started += instance.OnSwitchPortal;
                @SwitchPortal.performed += instance.OnSwitchPortal;
                @SwitchPortal.canceled += instance.OnSwitchPortal;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
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
    public interface IPlayer1Actions
    {
        void OnMovementHorizontal(InputAction.CallbackContext context);
        void OnMovementVertical(InputAction.CallbackContext context);
        void OnCameraHorizontal(InputAction.CallbackContext context);
        void OnCameraVertical(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAddPortal(InputAction.CallbackContext context);
        void OnSwitchPortal(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMovementHorizontal(InputAction.CallbackContext context);
        void OnMovementVertical(InputAction.CallbackContext context);
        void OnCameraHorizontal(InputAction.CallbackContext context);
        void OnCameraVertical(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAddPortal(InputAction.CallbackContext context);
        void OnSwitchPortal(InputAction.CallbackContext context);
    }
}
