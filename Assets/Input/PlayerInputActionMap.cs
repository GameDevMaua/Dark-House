// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActionMap"",
    ""maps"": [
        {
            ""name"": ""Pause"",
            ""id"": ""e656e6e9-d7b4-4cc5-a599-509a9e3f45a5"",
            ""actions"": [
                {
                    ""name"": ""Esc"",
                    ""type"": ""Value"",
                    ""id"": ""2f3b5d0f-cd15-4e1d-b1d6-d4929e0d39e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66bd349d-982a-4c91-ab24-e4d57ab1e635"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Esc = m_Pause.FindAction("Esc", throwIfNotFound: true);
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

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Esc;
    public struct PauseActions
    {
        private @PlayerInputActionMap m_Wrapper;
        public PauseActions(@PlayerInputActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Esc => m_Wrapper.m_Pause_Esc;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Esc.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnEsc;
                @Esc.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnEsc;
                @Esc.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnEsc;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Esc.started += instance.OnEsc;
                @Esc.performed += instance.OnEsc;
                @Esc.canceled += instance.OnEsc;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);
    public interface IPauseActions
    {
        void OnEsc(InputAction.CallbackContext context);
    }
}
