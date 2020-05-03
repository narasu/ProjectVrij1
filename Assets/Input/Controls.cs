// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""FirstPerson"",
            ""id"": ""6d3bdd0b-c5c3-4061-956a-aba6ff46ed76"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""6e752a4d-c36a-47f1-81c2-188b7b17703d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""09b7cdc4-0794-490d-a6d7-39d23ec2f3d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""18872148-b109-4a90-9f04-462b1e0d3c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""409557df-c4f9-4ef3-b19b-7c88e7f66c5d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f7cf7fcf-52c4-4071-8270-a557ac3ab95d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6c809b4d-f649-4ca6-bbd1-1cb59efa8b8f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""da85bc1b-ec38-42a4-81a0-cb41d3279eee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b2819bf5-0838-435b-9615-6ca09099eb1a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b28e803b-2c9e-4d87-9cf1-bfba1b82fcd9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f186a3a2-a690-4cc1-88e9-6f57f11f818e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cd86a5e-e235-4a76-bef2-1b47030e9380"",
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
                    ""id"": ""7232900d-5b92-48e8-8e4b-76896f03e2f0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Focus"",
            ""id"": ""e536f9c4-f940-41cb-bef0-7d3294d780ec"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""4cc54b8d-7adc-4de5-a38a-738865e42386"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa441bc6-c173-4f8b-8151-d32806c22cfb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""c37e3d75-c6e5-4ed7-ac88-be927b120122"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b7fa7a3b-253b-493e-ad0a-3445cca0f0ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""753991d7-915e-4903-b2a9-fe35685dd021"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FirstPerson
        m_FirstPerson = asset.FindActionMap("FirstPerson", throwIfNotFound: true);
        m_FirstPerson_Walk = m_FirstPerson.FindAction("Walk", throwIfNotFound: true);
        m_FirstPerson_Interact = m_FirstPerson.FindAction("Interact", throwIfNotFound: true);
        m_FirstPerson_Jump = m_FirstPerson.FindAction("Jump", throwIfNotFound: true);
        m_FirstPerson_Look = m_FirstPerson.FindAction("Look", throwIfNotFound: true);
        // Focus
        m_Focus = asset.FindActionMap("Focus", throwIfNotFound: true);
        m_Focus_Newaction = m_Focus.FindAction("New action", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Pause = m_Game.FindAction("Pause", throwIfNotFound: true);
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

    // FirstPerson
    private readonly InputActionMap m_FirstPerson;
    private IFirstPersonActions m_FirstPersonActionsCallbackInterface;
    private readonly InputAction m_FirstPerson_Walk;
    private readonly InputAction m_FirstPerson_Interact;
    private readonly InputAction m_FirstPerson_Jump;
    private readonly InputAction m_FirstPerson_Look;
    public struct FirstPersonActions
    {
        private @Controls m_Wrapper;
        public FirstPersonActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_FirstPerson_Walk;
        public InputAction @Interact => m_Wrapper.m_FirstPerson_Interact;
        public InputAction @Jump => m_Wrapper.m_FirstPerson_Jump;
        public InputAction @Look => m_Wrapper.m_FirstPerson_Look;
        public InputActionMap Get() { return m_Wrapper.m_FirstPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FirstPersonActions set) { return set.Get(); }
        public void SetCallbacks(IFirstPersonActions instance)
        {
            if (m_Wrapper.m_FirstPersonActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnWalk;
                @Interact.started -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnInteract;
                @Jump.started -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_FirstPersonActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_FirstPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public FirstPersonActions @FirstPerson => new FirstPersonActions(this);

    // Focus
    private readonly InputActionMap m_Focus;
    private IFocusActions m_FocusActionsCallbackInterface;
    private readonly InputAction m_Focus_Newaction;
    public struct FocusActions
    {
        private @Controls m_Wrapper;
        public FocusActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Focus_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Focus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FocusActions set) { return set.Get(); }
        public void SetCallbacks(IFocusActions instance)
        {
            if (m_Wrapper.m_FocusActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_FocusActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_FocusActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_FocusActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_FocusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public FocusActions @Focus => new FocusActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Pause;
    public struct GameActions
    {
        private @Controls m_Wrapper;
        public GameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Game_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IFirstPersonActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IFocusActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
