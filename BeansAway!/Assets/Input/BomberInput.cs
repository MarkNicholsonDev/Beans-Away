//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/BomberInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @BomberInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BomberInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BomberInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9b8a7bd3-b7dd-407b-8c8f-1de240a5d1ef"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ac68d61a-d939-4d54-812f-8dafac4a8bad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""YawControl"",
                    ""type"": ""Value"",
                    ""id"": ""ad439190-7cd1-47b9-bd33-bb5f142b4195"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ThrottleControl"",
                    ""type"": ""Value"",
                    ""id"": ""0e6d2599-0cbf-408e-852d-e4d2025871bf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""BombRelease"",
                    ""type"": ""Button"",
                    ""id"": ""63370ad0-3225-409f-9711-8e57c15be3d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FireMachineguns"",
                    ""type"": ""Button"",
                    ""id"": ""62e7df52-8654-488b-809d-74bf1d497935"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e82de5c7-cbd0-43ba-964a-d44f593d525c"",
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
                    ""id"": ""8fd9a04e-a4df-4093-a8b4-4a3290bc2165"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ee523b29-3668-4ce0-be43-16c0ed1c342a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5907e7be-cfc2-4a91-ab68-ae64465e0e5d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6c460ffb-8fe7-4222-909f-6ed2577cd4e7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e9917202-1b98-4b74-a80f-9302d8ead361"",
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
                    ""id"": ""5eecdc9d-12ce-4ba3-b1d1-ce9492db84ef"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""909e937a-f79c-4387-aaa8-b1576482d01c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d5aa0091-f6e0-43ea-9ab1-b8478663b528"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""26aaa887-d973-42cf-804d-0185ab5f050e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Yaw Control (WASD)"",
                    ""id"": ""83364780-7a59-4015-80fd-1ee6fec5d002"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0aaf67d4-8b11-48d7-a426-d1f51a554ad6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aebc4fed-f795-45b8-9068-787ef231d2e2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Yaw Control (Arrow Keys)"",
                    ""id"": ""1599e626-37a4-4d9b-b06e-1f66c255c091"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f55b7e87-af5e-4b28-ab81-e429a197a800"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""99bf1e30-829a-425e-9368-3289be3b1132"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YawControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Throttle (WASD)"",
                    ""id"": ""3693ea54-6bf0-4c3f-bf72-8d81dd18d3d8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""63a1873a-56c0-4867-889b-e30daf4208e3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3eb5d0a1-91c0-4693-9c40-1bf686b70dcd"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Throttle (Arrow Keys)"",
                    ""id"": ""46953f2a-dae1-4d62-b1bc-6f55a2b74a5f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c27cf2ca-db88-4f18-addc-ed7651c737a2"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""09d7589a-b871-459e-b64b-e7b0bb5d17dc"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrottleControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a76a7244-2e72-4382-bbc7-6db51dd19478"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BombRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9e036cf-5788-45af-b566-49cd68450783"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BombRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3ca6418-db83-4cfc-94b8-d06484245d49"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireMachineguns"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b404fc0-9890-49b7-9424-c31e8933c091"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireMachineguns"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_YawControl = m_Player.FindAction("YawControl", throwIfNotFound: true);
        m_Player_ThrottleControl = m_Player.FindAction("ThrottleControl", throwIfNotFound: true);
        m_Player_BombRelease = m_Player.FindAction("BombRelease", throwIfNotFound: true);
        m_Player_FireMachineguns = m_Player.FindAction("FireMachineguns", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_YawControl;
    private readonly InputAction m_Player_ThrottleControl;
    private readonly InputAction m_Player_BombRelease;
    private readonly InputAction m_Player_FireMachineguns;
    public struct PlayerActions
    {
        private @BomberInput m_Wrapper;
        public PlayerActions(@BomberInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @YawControl => m_Wrapper.m_Player_YawControl;
        public InputAction @ThrottleControl => m_Wrapper.m_Player_ThrottleControl;
        public InputAction @BombRelease => m_Wrapper.m_Player_BombRelease;
        public InputAction @FireMachineguns => m_Wrapper.m_Player_FireMachineguns;
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
                @YawControl.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYawControl;
                @YawControl.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYawControl;
                @YawControl.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYawControl;
                @ThrottleControl.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottleControl;
                @ThrottleControl.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottleControl;
                @ThrottleControl.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrottleControl;
                @BombRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBombRelease;
                @BombRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBombRelease;
                @BombRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBombRelease;
                @FireMachineguns.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireMachineguns;
                @FireMachineguns.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireMachineguns;
                @FireMachineguns.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireMachineguns;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @YawControl.started += instance.OnYawControl;
                @YawControl.performed += instance.OnYawControl;
                @YawControl.canceled += instance.OnYawControl;
                @ThrottleControl.started += instance.OnThrottleControl;
                @ThrottleControl.performed += instance.OnThrottleControl;
                @ThrottleControl.canceled += instance.OnThrottleControl;
                @BombRelease.started += instance.OnBombRelease;
                @BombRelease.performed += instance.OnBombRelease;
                @BombRelease.canceled += instance.OnBombRelease;
                @FireMachineguns.started += instance.OnFireMachineguns;
                @FireMachineguns.performed += instance.OnFireMachineguns;
                @FireMachineguns.canceled += instance.OnFireMachineguns;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnYawControl(InputAction.CallbackContext context);
        void OnThrottleControl(InputAction.CallbackContext context);
        void OnBombRelease(InputAction.CallbackContext context);
        void OnFireMachineguns(InputAction.CallbackContext context);
    }
}